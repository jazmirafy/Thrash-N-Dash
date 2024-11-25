using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyIncreaser : MonoBehaviour
{
    public SliderManager sliderManager;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player"){
            playerController.maxSpeed += .05f;
            sliderManager.sliderSpeed -= .05f; //increase the speed the slider moves (the lower the slider speed the faster the slider moves)
        }
    }
}
