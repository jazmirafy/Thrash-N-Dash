using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCheckPoint : MonoBehaviour
{      
    public bool isTricking = false;
    public FirstCheckPoint firstCheckPoint;
    public GameObject player;
    public GameObject enemy;
    public SugarManager sugarManager;
    public float jumpDistance = 2f;
    public float incrementAmount = 10f;
    public Image nextBackground;
    private RectTransform rectTransform;
    private Vector2 originalSizeDelta;
    private Vector2 originalAnchoredPosition;
    private float stretchAmount;

    void Awake()
    {
        // Initialize variables
        rectTransform = nextBackground.GetComponent<RectTransform>();
        originalSizeDelta = rectTransform.sizeDelta;
        originalAnchoredPosition = rectTransform.anchoredPosition;
    }

    public void StretchTop(float amount)
    {
        // Increase the size of the background
        Vector2 newSize = rectTransform.sizeDelta;
        newSize.y += amount;  // increment the y size
        rectTransform.sizeDelta = newSize;

        // Recalculate the anchored position
        Vector2 newPosition = originalAnchoredPosition;
        float yOffset = (originalSizeDelta.y * (stretchAmount - 1)) / 2;  // adjust position based on the increment
        newPosition.y += yOffset;
        rectTransform.anchoredPosition = newPosition;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider was triggered by the player
        if (collider.tag == "Player")
        {
            Debug.Log("player triggered deactivator checkpoint");

            if (firstCheckPoint.accurateStop || sugarManager.sugarRushActive)
            {
                isTricking = true;
                // Deactivate slider at the second checkpoint
                firstCheckPoint.trickSlider.gameObject.SetActive(false);
                firstCheckPoint.sliderEnabled = false;
                Debug.Log("slider has been set INactive");

                // Start the jump
                player.GetComponent<JumpController>().StartJump(new Vector2(this.transform.position.x + jumpDistance, this.transform.position.y));
                Debug.Log("TRICK ANIMATION PLACE HOLDER");

                // After trick is done, set isTricking back to false
                isTricking = false;

                if (firstCheckPoint.accurateStop)
                {
                    firstCheckPoint.upperBound += incrementAmount; // Make the next trick easier by making the green area interval wider
                    StretchTop(incrementAmount);
                }

                // Refill the player's chances for the next obstacle
                firstCheckPoint.chances = 2;
                firstCheckPoint.accurateStop = false;
            }
            else if (!firstCheckPoint.accurateStop || !firstCheckPoint.buttonPressed)
            {
                // If the player didn't hit the "green" area of the meter or didn't press the button in time, respawn them at the first checkpoint
                player.transform.position = firstCheckPoint.checkPointPosition;
                Debug.Log("player should have respawned at activator checkpoint");

                // Respawn the enemy a few feet behind the player
                enemy.transform.position = new Vector2(firstCheckPoint.checkPointPosition.x - 5, firstCheckPoint.checkPointPosition.y);
                Debug.Log("enemy should have respawned behind player");

                // Take away health when they fail the trick
                // Subtract player's health here if needed

                firstCheckPoint.buttonPressed = false; // Reset first checkpoint so slider starts moving again
                firstCheckPoint.chances--; // Take away a chance
            }
        }
    }
}