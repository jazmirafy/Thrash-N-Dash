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
        Debug.Log("player triggered deactivator checkpoint"); //let us know when the second checkpoint has been triggered
        //dont forgt to add: if sugar rush is active, then do the trick (make this the first if statement condition being check and make the other two else if)
        //if the sugar rush is active, the get to "bypass" the trick
            //if the player hit the "green" area of the meter, execute the trick, refill their chances, and deactivate the slider
            //or if the player is currently in a sugar rush, let them bypass the trick
            if(firstCheckPoint.accurateStop || sugarManager.sugarRushActive)
            {
                isTricking = true;
                //deactivate slider at the second checkpoint
                firstCheckPoint.trickSlider.gameObject.SetActive(false);
                Debug.Log("slider has been set INactive"); //let us know slider should been set inactive
                player.GetComponent<JumpController>().StartJump(new Vector2(this.transform.position.x + 10, this.transform.position.y)); //get jump controller from player to initialize jump
                Debug.Log("TRICK ANIMATION PLACE HOLDER"); //let us know when the trick animation is supposed to happen since we dont have the animation for it yet
                //insert trick animation
                //after trick is done set is tricking back to false
                isTricking = false;
                if(firstCheckPoint.accurateStop){
                    firstCheckPoint.upperBound += .03f; //if they get the trick right, make the next trick easier by making the green area interval wider
                }
                firstCheckPoint.chances = 2; //refill the players chances for the next obstacle
                firstCheckPoint.accurateStop = false; //reset accurate stop bool for new attempt
            } 
            else if (!firstCheckPoint.accurateStop || !firstCheckPoint.buttonPressed)
            {
                //if the player didnt hit the "green" area of the meter or they didnt press the button in time, respawn them at the first checkpoint
                player.transform.position = firstCheckPoint.checkPointPosition; //respawn the player at the checkpoint
                Debug.Log("player should have respawned at activator checkpoint"); //let us know when/where the player should respawn
                //respawn the enemy a few feet behind the player
                enemy.transform.position = new Vector2(firstCheckPoint.checkPointPosition.x  - 5, firstCheckPoint.checkPointPosition.y);
                Debug.Log("enemy should have respawned behind player"); //let us know when/where the enemy should respawn
                //dont forget to take away health when they fail the trick as well

                firstCheckPoint.buttonPressed = false; //reset first checkpoint so slider starts moving again
                firstCheckPoint.chances --; //take away a chance
            }
        }

    }
}
