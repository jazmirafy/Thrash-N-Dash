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
       //distance = Vector2.Distance(transform.position, target.transform.position);

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
        //rb.AddForce(new Vector2(0, jumpHeight));
        rb.AddForce(Vector2.up * jumpHeight); //this way of making the enemy jump can be more memory and performance efficient because it doesnt have to create a new vector 2 instance for each jump
        }
    }
  
    //switches the bool value of whatever facing right currently is, looks are the orientation of the sprite, and then multiplying it by -1 is what flips the sprite the other way
    void Flip(){
        facingRight = !facingRight; //switches whatever the current boolean value to the opposite (from false to true, or from true to false)
        Vector3 theScale = transform.localScale; //gets the local scale the sprite has now, and assigns it to a variable
        theScale.x *= -1; //multiplies the x value of the scale to -1 (flip the x coordinate because you want to flip it horizontally)
        transform.localScale = theScale; // takes the value of theScale variable (the flipped variable) and assigns it to the sprites actual local scale
    }
}
