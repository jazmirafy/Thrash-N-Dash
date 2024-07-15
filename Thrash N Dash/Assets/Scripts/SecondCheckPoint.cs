using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCheckPoint : MonoBehaviour
{      
    //dont forget to put the isTricking variable in the player controller so the player doesnt have control over the racoon when it does the trick animation
    public bool isTricking = false;
    public FirstCheckPoint firstCheckPoint;
    public GameObject player;
    public GameObject enemy;

    void OnTriggerEnter2D(Collider2D collider){
        //check if the collider was triggered by the player
        if(collider.tag == "Player"){
            //if the player hit the "green" area of the meter, execute the trick, refill their chances, and deactivate the slider
            if(firstCheckPoint.fillAmount >=.5 && firstCheckPoint.fillAmount<= .7 && firstCheckPoint.buttonPressed){
                isTricking = true;
                //insert trick animation
                firstCheckPoint.chances = 2;
                //deactivate slider at the second checkpoint
                firstCheckPoint.trickSlider.enabled = false; 
                firstCheckPoint.sliderSpeed --; //if they get the trick right, lower the slider speed to make the next trick easier 
                //dont forget to make the slider speed increase everytime they take sugar as a penalty for taking it
            //if the player didnt hit the "green" area of the meter or they didnt press the button in time, respawn them at the first checkpoint
            } 
            else {
                player.transform.position = firstCheckPoint.checkPointPosition; //respawn the player at the checkpoint
                //respawn the enemy a few feet behind the player
                enemy.transform.position = new Vector2(firstCheckPoint.checkPointPosition.x  - 5, firstCheckPoint.checkPointPosition.y);
                //dont forget to take away health when they fail the trick as well
            }
        }
    }
}
