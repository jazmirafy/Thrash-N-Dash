using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FirstCheckPoint : MonoBehaviour
{
    public float chances = 2f;
    public GameObject player;
    public GameObject enemy;
    public SliderManager sliderManager;
    public Vector2 checkPointPosition;
    public Slider trickSlider;
    public Image backgroundImage;
    public bool buttonPressed = false;
    public float fillAmount;
    private float elapsedTime = 0f; // Time elapsed since the start of the cycle
    private bool increasing = true; // Flag to indicate if the slider is increasing or decreasing
    public bool sliderEnabled = false; //bool to confirm slider is enabled and ready for Key Press
    public bool accurateStop; //bool to check that the slider was stopped within the correct range
    public bool clickedOllie = false;
    public bool clickedKickFlip = false;


    // OnEnable is called every time the game object is activated
    void OnEnable()
    {
        clickedOllie = false;
        clickedKickFlip = false;
        buttonPressed = false;
        //Debug.Log("slider has been enabled, lerp should have started"); //let us know slider lerp should have started

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //check if the collider was triggered by the player
        if (collider.tag == "Player")
        {
            Debug.Log("player triggered activator checkpoint"); //let us know when the checkpoint has been triggered
            //see if the player has chances left
            if (chances > 0)
            {
                //save the players position when they hit the checkpoint so we know where to respawn them later if they miss the trick
                checkPointPosition = new Vector2((player.transform.position.x), player.transform.position.y);
                trickSlider.gameObject.SetActive(true);//this activates the slider to lerp
                sliderEnabled = true;
                //Debug.Log("slider has been set active"); //let us know slider should been set active
            }
            else
            {
                SceneManager.LoadScene("LoseChances");
                //game over (idk how to do gameover or kill the player yet)

                //Application.Quit(); //Quits application if player does not have chances left. Can change to switch to Lobby/mainMenu scene if needed
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

        if (!buttonPressed)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / sliderManager.sliderSpeed;
            t = Mathf.Clamp01(t);

            if (increasing)
            {
                //Debug.Log("slider has been enabled, lerp has started"); //let us know slider lerp started
                trickSlider.value = Mathf.Lerp(0f, 1f, t);
            }
            else
            {
                trickSlider.value = Mathf.Lerp(1f, 0f, t);
            }
            //if the handle is over the target area make the slider turn green
            /*if(trickSlider.value >= sliderManager.lowerBound &&  trickSlider.value <= sliderManager.upperBound)
            {

                backgroundImage.color = Color.green;
            }
            else
            {
                backgroundImage.color = Color.blue;
            }*/

            if (t >= 1f)
            {
                elapsedTime = 0f;
                increasing = !increasing;
            }
            //check to see if the user clicked a button that is assigned to a trick, and then stop the trick meter and changes the bool accordingly
            CheckTrick(KeyCode.Q, KeyCode.JoystickButton1, ref clickedOllie);
            CheckTrick(KeyCode.Z, KeyCode.JoystickButton2, ref clickedKickFlip);
        }


    }
    void CheckTrick(KeyCode key, KeyCode joystickKey, ref bool clickedTrick)
    {
        if ((Input.GetKeyDown(key) || Input.GetKeyDown(joystickKey)) && !buttonPressed && sliderEnabled)
        {
            clickedTrick = true;
            buttonPressed = true;
            fillAmount = trickSlider.value; 
            trickSlider.value = fillAmount;//stop the trick slider at the value it currently is when they pressed the button

            //determine if the user stopped accurately (within the "green area" bounds)
            if (fillAmount >= sliderManager.lowerBound && fillAmount <= sliderManager.upperBound)
            {
                accurateStop = true;
            }
            else
            {
                accurateStop = false;
            }
        }
    }
}
