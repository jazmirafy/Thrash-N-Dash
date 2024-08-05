using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DemoManager : MonoBehaviour
{
    public TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        timeManager.DoSlowDown(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
