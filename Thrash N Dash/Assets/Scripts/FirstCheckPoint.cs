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

    // OnEnable is called every time the game object is activated
    void OnEnable()
    {
        //this determines how fast the slider moves and the range of numbers it goes between (sorta?)
        trickSlider.value = Mathf.PingPong(sliderSpeed, 1);
        buttonPressed = false;


    }

    void OnTrigger2D(Collider2D collider){
        //check if the collider was triggered by the player
        if(collider.tag == "Player"){
        //see if the player has chances left
         if(chances > 0){
            //save the players position when they hit the checkpoint so we know where to respawn them later if they miss the trick
            checkPointPosition = player.transform.position;
            trickSlider.enabled = true; //this activates the slider to ping pong

         }
         else{
            //game over (idk how to do gameover or kill the player yet)
         }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && !buttonPressed){
            buttonPressed = true;
            fillAmount = trickSlider.value;
        }
    }
}
