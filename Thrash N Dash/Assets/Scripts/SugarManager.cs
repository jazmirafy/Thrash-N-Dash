using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SugarManager : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 6;
    public static float healthAmount;
    public Image speedBar;
    //rushTime is how long the sugar rush lasts
    public static float rushTime = 5;
    public playerController playerController;
    //allows sugar rush cooldown
    public bool sugarRushActive;
    float initialSpeed;
    public SliderManager sliderManager;

    public Image sugarImage;
    public Image controllerButton;
    public Image keyboardButton;
    public TransitionManager transitionManager;
    public Animator myAnim;


    // Start is called before the first frame update
    void Start()
    {
        //assigns the player controller script to the player controller variable
        healthAmount = maxHealth;
        sugarRushActive = false;
        initialSpeed = playerController.maxSpeed;
         if(InputManager.usingController){
                controllerButton.gameObject.SetActive(true);
                keyboardButton.gameObject.SetActive(false);
            }
        else if(InputManager.usingKeyboard){
                keyboardButton.gameObject.SetActive(true);
                controllerButton.gameObject.SetActive(false);
            }       

    }

    // Update is called once per frame
    void Update()
    { 

        //if the player takes the sugar by pressing the Q key, they lose health and gain speed
        //did they click w or Y
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.JoystickButton3)) && !sugarRushActive /*&& rushTime>=1*/){
            //Coroutine = allow to delay/modify methods and events until a time or condition is met
            StartCoroutine(SugarRush(rushTime));
        }
        //if their health is not full, but greater than half, do the player tired animation
        if(healthAmount < 6 && healthAmount > 3)
        {
            myAnim.SetBool("isTired", true);
        }
        //if their health is at half or less (but they arent dead) do the mega tired animation
        if(healthAmount <= 3 && healthAmount > 0)
        {
            myAnim.SetBool("isMegaTired", true);
        }


    }
    //ienumerator is exclusively used for a coroutine
    IEnumerator SugarRush(float currentRushTime){
        //decrease player health and decrease the length of the green part of the health bar
        healthAmount -= 1; // if the player eats sugar their health goes down by 2
        healthBar.fillAmount = healthAmount/ maxHealth;
        sugarImage.color = Color.magenta;
        if(healthAmount >0){
            sugarRushActive = true;
            //if the sugar rush is active, set the sugar rush animation bool to true and make the tired states false
            myAnim.SetBool("isSugarRushing", true);
            myAnim.SetBool("isTired", false);
            myAnim.SetBool("isMegaTired", false);
            playerController.maxSpeed *= 2;
            //double the speed bar's size since the player's speed doubled
            speedBar.fillAmount *= 2;
            //yield return tells the code to do the above until condition is met (waitforseconds is the condtion) always put new before the condition
            yield return new WaitForSeconds(currentRushTime);
            myAnim.SetBool("isSugarRushing", false);
            sugarImage.color = Color.white;
            //each time the player has a sugar rush, the next rush is gonna be 1 second slower to represent gaining tolerance to an addictive substance
            //rushTime is the duration of the sugar rush. the sugar rush duration goes down each time you take another sugar
            rushTime = Mathf.Max((rushTime-1), 1); //mathf.max makes sure rush time does not go below 1
            //decrease the speedbar length, speed, and set the sugar rush active back to false 
            playerController.maxSpeed = (playerController.maxSpeed/2) - 1;
            speedBar.fillAmount = (playerController.maxSpeed/initialSpeed)/2;
            sugarRushActive = false;
        }
        //if the player runs out of health
        else{
            //TransitionManager.ResetVariables();
            SceneManager.LoadScene("BonkCutscene");
            //game over (idk how to do gameover or kill the player yet)
        }
    }
}
