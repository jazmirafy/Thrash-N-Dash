using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public SliderManager sliderManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void ResetVariables(){
        SecondCheckPoint.totalIncrement = 0f;
        SliderManager.lowerBound = .4f;
        SliderManager.upperBound = .6f;
        SugarManager.healthAmount = 6f;
        FirstCheckPoint.chances = 2f;
        EnemyChase.AIspeed = 8f;
        playerController.maxSpeed = 8f;
        SugarManager.rushTime = 5f;


    }

    // Update is called once per frame
    void Update()
    {
        ResetVariables();
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.JoystickButton0)){
            SceneManager.LoadScene("GO");
        }
        else if(Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.JoystickButton1)){
            SceneManager.LoadScene("START");
        }

    }

}
