using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SecondCheckPoint : MonoBehaviour
{      
    //dont forget to put the isTricking variable in the player controller so the player doesnt have control over the racoon when it does the trick animation
    public bool isTricking = false;
    public FirstCheckPoint firstCheckPoint;
    public GameObject player;
    public GameObject enemy;
    public SugarManager sugarManager;

    void OnTriggerEnter2D(Collider2D collider){
        //check if the collider was triggered by the player
        if(collider.tag == "Player")
        {
        Debug.Log("player triggered checkpoint 2"); //let us know when the second checkpoint has been triggered
            //if the player hit the "green" area of the meter, execute the trick, refill their chances, and deactivate the slider
            if(firstCheckPoint.accurateStop)
            {
                isTricking = true;
                Debug.Log("TRICK ANIMATION PLACE HOLDER"); //let us know when the trick animation is supposed to happen since we dont have the animation for it yet
                //insert trick animation
                firstCheckPoint.chances = 2; //refill the players chances for the time obstacle
                //deactivate slider at the second checkpoint
                firstCheckPoint.trickSlider.gameObject.SetActive(false);
                firstCheckPoint.sliderSpeed ++; //if they get the trick right, change the slider speed to make the next trick easier 
                //dont forget to make the slider speed increase everytime they take sugar as a penalty for taking it
                player.GetComponent<JumpController>().StartJump(new Vector2(this.transform.position.x + 10, this.transform.position.y)); //get jump controller from player to initialize jump
            } 
            else if (!firstCheckPoint.accurateStop || !firstCheckPoint.buttonPressed)
            {
                //if the player didnt hit the "green" area of the meter or they didnt press the button in time, respawn them at the first checkpoint
                player.transform.position = firstCheckPoint.checkPointPosition; //respawn the player at the checkpoint
                Debug.Log("player should have respawned at checkpoint 1"); //let us know when/where the player should respawn
                //respawn the enemy a few feet behind the player
                enemy.transform.position = new Vector2(firstCheckPoint.checkPointPosition.x  - 5, firstCheckPoint.checkPointPosition.y);
                Debug.Log("enemy should have respawned behind player"); //let us know when/where the enemy should respawn
                //dont forget to take away health when they fail the trick as well

                firstCheckPoint.buttonPressed = false; //reset first checkpoint so slider starts moving again
                firstCheckPoint.chances --; //decrease chances for bad trick
                firstCheckPoint.accurateStop = false; //reset accurate stop bool for new attempt
                sugarManager.healthAmount--; //take one health away if they fail the trick one time
                //dont forget to implement a consequence for when the player's health goes to zero. 
            }
        }
    }
}