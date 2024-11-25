using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DemoActivator0 : MonoBehaviour
{
    public Image keyboardImage0;
    public Image controllerImage0;
    // Start is called before the first frame update
    void Start()
    {
        //start off with both images diasabled
        controllerImage0.gameObject.SetActive(false);
        keyboardImage0.gameObject.SetActive(false);
        StartCoroutine(ForwardDemo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ForwardDemo(){
        //enable the image that correlates with the input the user is on (controller or keyboard)
        if(InputManager.usingController){
            controllerImage0.gameObject.SetActive(true);
        }
        else if(InputManager.usingKeyboard){
            keyboardImage0.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        controllerImage0.gameObject.SetActive(false);
        keyboardImage0.gameObject.SetActive(false);
    }
}
