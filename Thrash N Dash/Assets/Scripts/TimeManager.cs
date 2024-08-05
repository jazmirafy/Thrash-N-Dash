using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor; //the lower this number is, the slower we will move
    public float slowDownLength = 2f; //how long the slow down will occur
    float incrementer;
    float originalDeltaTime;
    float iterationLength = 1f;

    public void DoSlowDown()
    {
        //time scale determines the scale time is passing. a timescale value of 1 is real time.
        Time.timeScale = slowDownFactor; //set the time scale value to our slowdown factor value
        incrementer = ((1- Time.timeScale)/ slowDownLength);
        //fixed delta time is the amount of time in between each fixed update frame. we change this so when we slow the game down it doesnt look choppy
        Time.fixedDeltaTime = Time.timeScale * 0.02f; 
        Debug.Log($"DoSlowDown called. Time.timeScale: {Time.timeScale}, Time.fixedDeltaTime: {Time.fixedDeltaTime}");
        StartCoroutine(SpeederUpper());
    }
    IEnumerator SpeederUpper(){
        while(Time.timeScale < 1f)
        {
            //slowly raises the time scale so it will gradually transition to realtime (realtime is when the timescale = 1)
            //we use time.unscaled delta time because time.deltaTime is affected when we change the time scale.
            Time.timeScale += incrementer;
            //the clamp makes sure the time scale doesnt slowly start to speed up past real time.
            //this means the game will slowly speed up but once the time scale hits one (realtime) it stays there
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            // Debug output to check values
            Debug.Log($"Time.timeScale: {Time.timeScale}, Time.fixedDeltaTime: {Time.fixedDeltaTime}");
            yield return new WaitForSeconds(iterationLength);
        }
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}