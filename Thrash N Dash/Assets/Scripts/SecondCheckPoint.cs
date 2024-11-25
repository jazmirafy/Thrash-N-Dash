using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCheckPoint : MonoBehaviour
{      
    public bool isTricking = false;
    public static bool isFalling  = false;
    public FirstCheckPoint firstCheckPoint;
    public GameObject player;
    public GameObject enemy;
    public SugarManager sugarManager;
    public SliderManager sliderManager;
    public TrickJudgerController trickJudgerController;
    public float jumpDistance = 2f;
    float incrementAmount = 0.005f;
    public GameObject nextSlider;
    public static float totalIncrement = 0f;
    float speedIncreaser = .005f;
    public Animator animator;

    void Start()
    {
        animator  = player.GetComponent<Animator>();
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider was triggered by the player
        if (collider.tag == "Player")
        {
            Debug.Log("player triggered deactivator checkpoint");

            if (firstCheckPoint.accurateStop || sugarManager.sugarRushActive)
            {
                isTricking = true;
                //reset the current trick sliders size
                sliderManager.StretchTop(firstCheckPoint.currentBackground, -totalIncrement);
                // Deactivate slider at the second checkpoint
                firstCheckPoint.trickSlider.gameObject.SetActive(false);
                firstCheckPoint.sliderEnabled = false;
                Debug.Log("slider has been set INactive");
                StartCoroutine(trickJudgerController.ShowGoodTrick());
                if(firstCheckPoint.clickedOllie){
                player.GetComponent<JumpController>().StartJump(new Vector2(this.transform.position.x + jumpDistance, this.transform.position.y), "doingOllie");
                firstCheckPoint.clickedOllie = false;
                StartCoroutine(ResetIsTricking());
                
                }
                else if(firstCheckPoint.clickedKickFlip || sugarManager.sugarRushActive){
                player.GetComponent<JumpController>().StartJump(new Vector2(this.transform.position.x + jumpDistance, this.transform.position.y), "doingKickflip");
                firstCheckPoint.clickedKickFlip = false;
                StartCoroutine(ResetIsTricking());
                }
                isTricking = false;
                EnemyChase.AIspeed += speedIncreaser; //increase the enemy speed after the player passes an obstacle
                Debug.Log("AIspeed value: " + EnemyChase.AIspeed);
                if (firstCheckPoint.accurateStop)
                {
                    //give the incentive for doing the trick as expanding the target area

                    SliderManager.upperBound = Mathf.Min((SliderManager.upperBound + (incrementAmount/2)), .85f); 
                    SliderManager.lowerBound = Mathf.Max((SliderManager.lowerBound - (incrementAmount/2)), .20f);
                    totalIncrement += incrementAmount;
                    sliderManager.StretchTop(nextSlider, totalIncrement);
                    
                }
                if(sugarManager.sugarRushActive)
                {
                    //give a penalty for taking sugar by decreasing the target area
                    SliderManager.upperBound = Mathf.Max((SliderManager.upperBound - (incrementAmount/2)), .45f); 
                    SliderManager.lowerBound = Mathf.Min((SliderManager.lowerBound + (incrementAmount/2)), .40f);
                    totalIncrement -= incrementAmount;
                    sliderManager.StretchTop(nextSlider, totalIncrement);
                }

                // Refill the player's chances for the next obstacle
                FirstCheckPoint.chances = 2;
                firstCheckPoint.accurateStop = false;
            }
            else if (!firstCheckPoint.accurateStop || !firstCheckPoint.buttonPressed)
            {
                //player stumble animation
                StartCoroutine(trickJudgerController.ShowBadTrick());
                StartCoroutine(FallAndSpawn());
                firstCheckPoint.buttonPressed = false; // Reset first checkpoint so slider starts moving again
                FirstCheckPoint.chances--; // Take away a chance


            }
        }   
    }
    IEnumerator FallAndSpawn()
    {
        //disable the players collider here
        //actually the players collider isnt the trigger, the checkpoints are the trigger so i have to disable those triggers ( bring this up to mondae to think of how to go about doing this)
        isFalling = true;
        animator.SetTrigger("playerFell"); //do the fall animation
        yield return new WaitForSeconds(1); //wait one second and then repawn the player and enemy
        isFalling = false;
        // If the player didn't hit the "green" area of the meter or didn't press the button in time, respawn them at the first checkpoint
        player.transform.position = new Vector2(firstCheckPoint.checkPointPosition.x - 3, firstCheckPoint.checkPointPosition.y);
        Debug.Log("player should have respawned at activator checkpoint");

        // Respawn the enemy a few feet behind the player
        enemy.transform.position = new Vector2(firstCheckPoint.checkPointPosition.x - 10, firstCheckPoint.checkPointPosition.y);
        Debug.Log("enemy should have respawned behind player");
        //enable the players collider again here
    }
    IEnumerator ResetIsTricking(){
        yield return new WaitForSeconds(1);
        animator.SetBool("isTricking", false);
    }

}