using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Demo1Activator : MonoBehaviour
{
    public Image keyboardImage1;
    public Image controllerImage1;

    // Start is called before the first frame update
    void Start()
    {
        controllerImage1.gameObject.SetActive(false);
        keyboardImage1.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player"){
            Debug.Log("player triggered checkpoint");

            if(InputManager.usingController){
                controllerImage1.gameObject.SetActive(true);
            }
            else if(InputManager.usingKeyboard){
                keyboardImage1.gameObject.SetActive(true);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
