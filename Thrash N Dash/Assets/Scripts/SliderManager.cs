using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public float lowerBound = .4f; //the lower bound of the slider range
    public float upperBound = .6f; //the upper bound of the slider range that increases if the player gets the trick and decreases if they take sugar
    // Start is called before the first frame update
    public float sliderSpeed = .7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       /* public void StretchTop(Image nextBackground, float stretchAmount)
    {
        // declare/Initialize variables
        RectTransform rectTransform = nextBackground.GetComponent<RectTransform>();
        Vector2 originalSizeDelta = rectTransform.sizeDelta;
        Vector2 originalAnchoredPosition = rectTransform.anchoredPosition;

        // Increase the size of the background
        Vector2 newSize = rectTransform.sizeDelta;
        newSize.y += stretchAmount;  // increment the y size
        rectTransform.sizeDelta = newSize;

        // Recalculate the anchored position
        Vector2 newPosition = originalAnchoredPosition;
        float yOffset = (originalSizeDelta.y * (stretchAmount - 1)) / 2;  // adjust position based on the increment
        newPosition.y += yOffset;
        rectTransform.anchoredPosition = newPosition;
    }*/
}
