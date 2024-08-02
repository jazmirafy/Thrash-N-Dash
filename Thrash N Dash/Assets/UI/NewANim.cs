using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewANim : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        loadScene();

    }

    bool isPlaying()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Countdown"))
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
            SceneManager.LoadScene("SampleScene");
        }
    }
}