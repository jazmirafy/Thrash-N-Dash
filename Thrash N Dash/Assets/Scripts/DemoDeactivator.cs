using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoDeactivator : MonoBehaviour
{
    public Demo2Activator demo2Activator;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player"){
            //deactivate demo images
           demo2Activator.controllerImage2.gameObject.SetActive(false);
            demo2Activator.keyboardImage2.gameObject.SetActive(false);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
