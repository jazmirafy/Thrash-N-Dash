using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarManager : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 6;
    public float healthAmount;
    public Image speedBar;
    //rushTime is how long the sugar rush lasts
    public float rushTime;
    public playerController playerController;
    //allows sugar rush cooldown
    public bool sugarRushActive;
    float initialSpeed;
    public FirstCheckPoint firstCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        //assigns the player controller script to the player controller variable
        healthAmount = maxHealth;
        sugarRushActive = false;
        initialSpeed = playerController.maxSpeed;
        

    }

    // Update is called once per frame
    void Update()
    {
        //if the player takes the sugar by pressing the Q key, they lose health and gain speed
        if(Input.GetKeyDown(KeyCode.W) && !sugarRushActive /*&& rushTime>=1*/){
            //Coroutine = allow to delay/modify methods and events until a time or condition is met
            StartCoroutine(SugarRush(rushTime));
            //make sure the upper bound doesn't go below .45
            firstCheckPoint.upperBound = Mathf.Max((firstCheckPoint.upperBound - .03f), .45f); //if they take sugar, make the next trick harder as penalty (lower the sliders target interval)
 
        }


    }
    //ienumerator is exclusively used for a coroutine
    IEnumerator SugarRush(float currentRushTime){
        //decrease player health and decrease the length of the green part of the health bar
        healthAmount -= 2; // if the player eats sugar their health goes down by 2
        healthBar.fillAmount = healthAmount/ maxHealth;
        if(healthAmount >0){
            sugarRushActive = true;
            playerController.maxSpeed += 2;
            //double the speed bar's size since the player's speed doubled
            speedBar.fillAmount *= 2;
            //yield return tells the code to do the above until condition is met (waitforseconds is the condtion) always put new before the condition
            yield return new WaitForSeconds(currentRushTime);
            //each time the player has a sugar rush, the next rush is gonna be 1 second slower to represent gaining tolerance to an addictive substance
            //rushTime is the duration of the sugar rush. the sugar rush duration goes down each time you take another sugar
            rushTime = Mathf.Max((rushTime-1), 1); //mathf.max makes sure rush time does not go below 1
            //decrease the speedbar length, speed, and set the sugar rush active back to false 
            playerController.maxSpeed -=3;
            speedBar.fillAmount = (playerController.maxSpeed/initialSpeed)/2;
            sugarRushActive = false;
        }
        //if the player runs out of health
        else{
            //game over (idk how to do gameover or kill the player yet)
        }
    }
}
