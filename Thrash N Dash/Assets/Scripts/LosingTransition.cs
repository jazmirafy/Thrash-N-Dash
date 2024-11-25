using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LosingTransition : MonoBehaviour
{
   
   public Animator animator;
   public TransitionManager transitionManager;

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
