using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static bool usingController;
    public static bool usingKeyboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.A)){
            SceneManager.LoadScene("Cutscene");
            usingKeyboard = true;
            usingController = false;
        }
        else if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.JoystickButton3)){
            SceneManager.LoadScene("Cutscene");
            usingController = true;
            usingKeyboard = false;
        }
    }
}
