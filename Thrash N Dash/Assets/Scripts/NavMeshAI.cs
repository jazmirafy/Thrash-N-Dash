using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAI : MonoBehaviour
{
    //fields are serialized so they can be seen in the unity editor (similar to making a variable public) but the differece is serialized variables arent directly exposed to external code
    [SerializeField] Transform target;
    UnityEngine.AI.NavMeshAgent enemy;
    bool facingRight;
    

    // Start is called before the first frame update
    void Start()
    {
       
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //since this is a 2D sidescroller, we dont need the up axis (this is for 3d) and we dont need the enemy to rotate (2d sidescroller will need an enemy to flip, not rotate)
        enemy.updateRotation = false;
        enemy.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //this gets the enemy to go to the targets position/follow the target
        enemy.SetDestination(target.position);
        //looks at the direction the enemy is facing and flips him the right way
        if(enemy.velocity.x>0 && !facingRight){
            Flip();
        } else if(enemy.velocity.x<0 && facingRight){
            Flip();
        }

    }
    
    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
