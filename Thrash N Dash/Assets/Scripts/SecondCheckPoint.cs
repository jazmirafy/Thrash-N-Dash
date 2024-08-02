using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCheckPoint : MonoBehaviour
{      
    public bool isTricking = false;
    public FirstCheckPoint firstCheckPoint;
    public GameObject player;
    public GameObject enemy;
    public SugarManager sugarManager;
    public SliderManager sliderManager;
    public TrickJudgerController trickJudgerController;
    public float jumpDistance = 2f;
    public float incrementAmount;
    public GameObject nextSlider;
    public static float totalIncrement = 0f;



    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider was triggered by the player
        if (collider.tag == "Player")
        {
            Debug.Log("player triggered deactivator checkpoint");

            if (firstCheckPoint.accurateStop || sugarManager.sugarRushActive)
            {
                isTricking = true;
                // Deactivate slider at the second checkpoint
                firstCheckPoint.trickSlider.gameObject.SetActive(false);
                firstCheckPoint.sliderEnabled = false;
                Debug.Log("slider has been set INactive");
                StartCoroutine(trickJudgerController.ShowGoodTrick());
                // Start the jump
                //playerController.myAnim.SetFloat("Ollie", 1f);
                player.GetComponent<JumpController>().StartJump(new Vector2(this.transform.position.x + jumpDistance, this.transform.position.y));
                Debug.Log("TRICK ANIMATION PLACE HOLDER");
                // After trick is done, set isTricking back to false
                isTricking = false;
                //playerController.myAnim.SetFloat("Ollie", -1f);

                if (firstCheckPoint.accurateStop)
                {
                    //give the incentive for doing the trick as expanding the target area

                    sliderManager.upperBound = Mathf.Min((sliderManager.upperBound + (incrementAmount/2)), .85f); 
                    sliderManager.lowerBound = Mathf.Max((sliderManager.lowerBound - (incrementAmount/2)), .20f);
                    totalIncrement += incrementAmount;
                    sliderManager.StretchTop(nextSlider, totalIncrement);
                    
                }
                if(sugarManager.sugarRushActive)
                {
                    //give a penalty for taking sugar by decreasing the target area
                    sliderManager.upperBound = Mathf.Max((sliderManager.upperBound - (incrementAmount/2)), .45f); 
                    sliderManager.lowerBound = Mathf.Min((sliderManager.lowerBound + (incrementAmount/2)), .40f);
                    totalIncrement -= incrementAmount;
                    sliderManager.StretchTop(nextSlider, totalIncrement);
                }

                // Refill the player's chances for the next obstacle
                firstCheckPoint.chances = 2;
                firstCheckPoint.accurateStop = false;
            }
            else if (!firstCheckPoint.accurateStop || !firstCheckPoint.buttonPressed)
            {
                //player stumble animation
                StartCoroutine(trickJudgerController.ShowBadTrick());
                // If the player didn't hit the "green" area of the meter or didn't press the button in time, respawn them at the first checkpoint
                player.transform.position = firstCheckPoint.checkPointPosition;
                Debug.Log("player should have respawned at activator checkpoint");

                // Respawn the enemy a few feet behind the player
                enemy.transform.position = new Vector2(firstCheckPoint.checkPointPosition.x - 3, firstCheckPoint.checkPointPosition.y);
                Debug.Log("enemy should have respawned behind player");

                // Take away health when they fail the trick
                // Subtract player's health here if needed

                firstCheckPoint.buttonPressed = false; // Reset first checkpoint so slider starts moving again
                firstCheckPoint.chances--; // Take away a chance
            }
        }
    }
}