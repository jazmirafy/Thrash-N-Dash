using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public static float lowerBound = .4f; //the lower bound of the slider range
    public static float upperBound = .6f; //the upper bound of the slider range that increases if the player gets the trick and decreases if they take sugar
    // Start is called before the first frame update
    public float sliderSpeed = .6f;
    public SugarManager sugarManager;
    public FirstCheckPoint firstCheckPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       public void StretchTop(GameObject nextSlider, float stretchAmount)
    {
        
        Vector3 scale = nextSlider.transform.localScale;
        scale.y += stretchAmount;
        nextSlider.transform.localScale = scale;
        

    }
    

}
