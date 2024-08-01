using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyIncreaser : MonoBehaviour
{
    public EnemyChase enemyChase;
    public SliderManager sliderManager;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player"){
            enemyChase.AIspeed ++; //increase the foes speed to make the game more difficult
            sliderManager.sliderSpeed -= .1f; //increase the speed the slider moves (the lower the slider speed the faster the slider moves)
        }
    }
}
