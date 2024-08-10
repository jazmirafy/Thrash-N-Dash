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
        if(Input.GetKeyDown(KeyCode.Return) ){
            Debug.Log("Return key or X has been pressed.");
            SceneManager.LoadScene("GO");
            usingKeyboard = true;
        }
        else if(Input.GetKeyDown(KeyCode.JoystickButton2)){
            SceneManager.LoadScene("GO");
            usingController = true;
        }
    }
}
