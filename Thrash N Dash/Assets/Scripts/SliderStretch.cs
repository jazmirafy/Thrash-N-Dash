using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderStretch : MonoBehaviour
{
    public Slider trickSlider;

    // declare variables
    private RectTransform rectTransform;
    private Vector2 originalSizeDelta;
    private Vector2 originalAnchoredPosition;
    private float stretchAmount;

    void Start()
    {
        // Initialize variables
        rectTransform = trickSlider.GetComponent<RectTransform>();
        originalSizeDelta = rectTransform.sizeDelta;
        originalAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void StretchTop(float amount)
    {
        stretchAmount = amount;

        // calculate new size
        Vector2 newSize = originalSizeDelta;
        newSize.y = stretchAmount;
        rectTransform.sizeDelta = newSize;

        // calculate new position
        Vector2 newPosition = originalAnchoredPosition;
        float yOffset = (originalSizeDelta.y * (stretchAmount - 1)) / 2;
        newPosition.y += yOffset;
        rectTransform.anchoredPosition = newPosition;
    }
}