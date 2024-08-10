using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo2Activator : MonoBehaviour
{
    public Image controllerImage2;
    public Image keyboardImage2;
    public Demo1Activator demo1Activator;
    // Start is called before the first frame update
    void Start()
    {
        controllerImage2.gameObject.SetActive(false);
        keyboardImage2.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player"){
            //first, deactivate the first images
            demo1Activator.controllerImage1.gameObject.SetActive(false);
            demo1Activator.keyboardImage1.gameObject.SetActive(false);
            if(InputManager.usingController){
                controllerImage2.gameObject.SetActive(true);
            }
            else if(InputManager.usingKeyboard){
                keyboardImage2.gameObject.SetActive(true);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
