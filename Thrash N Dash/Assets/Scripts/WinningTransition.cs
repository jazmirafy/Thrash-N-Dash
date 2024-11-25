using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningTransition : MonoBehaviour
{
     public Animator animator;
     public TransitionManager transitionManager;
    void Update()
    {
        loadScene();

    }

    bool isPlaying()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("EndCutscene"))
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
            SceneManager.LoadScene("Win");
            TransitionManager.ResetVariables();
        }
    }
}

