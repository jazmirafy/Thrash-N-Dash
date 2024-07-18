using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirstCheckPoint : MonoBehaviour
{
    public float chances = 2f;
    public GameObject player;
    public GameObject enemy;
    public Vector2 checkPointPosition;
    public Slider trickSlider;
    public bool buttonPressed = false;
    public float sliderSpeed;
    public float fillAmount;
    private float elapsedTime = 0f; // Time elapsed since the start of the cycle
    private bool increasing = true; // Flag to indicate if the slider is increasing or decreasing
    public bool sliderEnabled = false; //bool to confirm slider is enabled and ready for Key Press
    public bool accurateStop; //bool to check that the slider was stopped within the correct range

    // OnEnable is called every time the game object is activated
    void OnEnable()
    {
        buttonPressed = false;
        Debug.Log("slider ping pong should have started"); //let us know slider ping pong should have started

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //check if the collider was triggered by the player
        if (collider.tag == "Player")
        {
            Debug.Log("player triggered checkpoint 1"); //let us know when the first checkpoint has been triggered
            //see if the player has chances left
            if (chances > 0)
            {
                //save the players position when they hit the checkpoint so we know where to respawn them later if they miss the trick
                checkPointPosition = new Vector2((player.transform.position.x-5), player.transform.position.y);
                trickSlider.gameObject.SetActive(true);//this activates the slider to ping pong
                sliderEnabled = true;
                Debug.Log("slider should be enabled"); //let us know slider should be enabled
            }
            else
            {
                //game over (idk how to do gameover or kill the player yet)
                Application.Quit(); //Quits application if player does not have chances left. Can change to switch to Lobby/mainMenu scene if needed
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        //if the user pressed the D button, stop the trick slider at the value they stopped it at
        if (Input.GetKeyDown(KeyCode.S) && !buttonPressed && sliderEnabled)
        {
            buttonPressed = true;
            fillAmount = trickSlider.value;
            trickSlider.value = fillAmount;
            if (fillAmount >= .5 && fillAmount <= .7)
                accurateStop = true;
            else
                accurateStop = false;
            return;
        }
        if (!buttonPressed)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / sliderSpeed;
            t = Mathf.Clamp01(t);

            if (increasing)
            {
                trickSlider.value = Mathf.Lerp(0f, 1f, t);
            }
            else
            {
                trickSlider.value = Mathf.Lerp(1f, 0f, t);
            }

            if (t >= 1f)
            {
                elapsedTime = 0f;
                increasing = !increasing;
            }
        }
    }
}
