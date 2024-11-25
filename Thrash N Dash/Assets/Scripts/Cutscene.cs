using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public Animator animator;

    void Start(){
        Time.timeScale = 1;
    }
    void Update()
    {
        loadScene();

    }

    bool isPlaying()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Cutscene"))
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
            SceneManager.LoadScene("GO");
        }
    }
}
