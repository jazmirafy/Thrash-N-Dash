using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LosingTransition : MonoBehaviour
{
   
   public Animator animator;
   public TransitionManager transitionManager;

    void Start()
    {
    //this is here just incase when the player loses they are still in the demo portion of the game (which is in slow motion and we dont want the bonk animation to be in slow motion also)
     Time.timeScale = 1; //1 is real time

    }
    void Update()
    {
        loadScene();

    }

    bool isPlaying()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BonkCutscene"))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    void loadScene()
    {
        if (isPlaying() == false)
        {
            if(SugarManager.healthAmount <= 0){
            SceneManager.LoadScene("LoseHealth");
            }
            else{
                SceneManager.LoadScene("LoseChances");
            }
            TransitionManager.ResetVariables();
        }
    }
}
