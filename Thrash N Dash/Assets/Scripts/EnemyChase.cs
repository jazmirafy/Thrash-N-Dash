using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{   
    public GameObject target;
    public float AIspeed;
    public float jumpHeight;
    float distance;
    bool facingRight;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //gets the distance between the AI enemy and the targeted player it wants to follow
       distance = Vector2.Distance(transform.position, target.transform.position);

       //determines the distance and direction the enemy needs to move to reach the target. im using this to determine where the AIenemy is in relation to the target
        Vector2 direction = target.transform.position - transform.position;
        //if the x value of the direction vector is positive, that means the player is in front of the AIenemy(to the right). this code means if the player is in front the enemy but the enemy sprite is facing left, flip the enemy sprite (and vise versa)
        if(direction.x>0 && !facingRight){
            Flip();
        } else if(direction.x<0 && facingRight){
            Flip();
        }
        //gets the AI enemy to move towards the targets postion at a particular speed. (the Time.deltaTime portion is there to make sure the speed is consistent at any framerate/ speed isnt framerate dependent. generally needed in the update method but not fixed update)
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, AIspeed * Time.deltaTime);


    }
    //if the enemy's collider trigger gets trigged by an object with a game obstacle tag, jump over it
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Obstacle"){
        Debug.Log("Enemy triggered");
        rb.AddForce(Vector2.up * jumpHeight);
        }
    }
    //check the current orientation of the play and multiply it by -1 to change it to the opposite direction
    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
