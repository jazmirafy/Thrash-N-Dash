using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables
    public float maxSpeed;
    public Rigidbody2D myRB;
    public Animator myAnim;
    bool facingRight;

    //jumping variables
    bool grounded = false;
    float groundCheckerRadius = 0.5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true; //user starts off facing to the right


    }

    // Update is called once per frame, good for game logic that isnt tied to physics
    void Update(){

        //checks if the circle on the players feet is overlapping another collider (the platform collider), if its overlapping, that means the player is on the floor
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckerRadius, groundLayer);
        //if the user is grounded, and the user press the jump button, make them jump the dedicated jump height
        if(grounded && Input.GetAxis("Jump")>0){
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }
    //called consistently for things that involve rigidbody physics, movement, interaction etc
    void FixedUpdate()
    {

        //update animator controller parameters (for the jump animation)
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("VerticleSpeed", myRB.velocity.y);

        //handle horizaontal movement

        //this will return a value from -1 (negative means the player is moving left) to 1 (postitive means player is moving right) (0 means player isnt pressing a button to move)
        float moveDirection = Input.GetAxis("Horizontal"); 
        //takes the absolute value of the moveDirection value, then assigns it to the speed parameter so the sprite can go from the idle to skating animation and vise versa
        //we take the absolute value bc the speed parameter in the anim controller just needs to detect movement is happening, it doesnt need the direction though
        myAnim.SetFloat("speed", Mathf.Abs(moveDirection));
        //this is what makes the player actually go forward. this takes the direction and speed and makes that the vector x value but keeps the y value the same
        myRB.velocity = new Vector2(moveDirection * maxSpeed, myRB.velocity.y);

        //flip the character sprite if he switches directions
        if(moveDirection>0 && !facingRight){
            Flip();
        } else if(moveDirection<0 && facingRight){
            Flip();
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
