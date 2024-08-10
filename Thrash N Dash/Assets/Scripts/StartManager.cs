using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0) ||Input.GetKeyDown(KeyCode.A)){
            SceneManager.LoadScene("Choose");
        }
    }
}
