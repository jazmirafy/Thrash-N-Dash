using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //movement variables
    public float maxSpeed;
    Rigidbody2D myRB;
    Animator myAnim;
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
        facingRight = true;

    }

    // Update is called once per frame, food for game logic that isnt tied to physics
    void Update(){

        //checks if circle is overlapping another colliders, if its overlapping, the player is on the floor
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckerRadius, groundLayer);
        if(grounded && Input.GetAxis("Jump")>0){
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }
    //called consistently for things that involve physiscs, movement, interaction etc
    void FixedUpdate()
    {

        //update animator controller parameters
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("VerticleSpeed", myRB.velocity.y);

        //handle horizaontal movement

        //this will return a value from -1 (negative means the player is moving left) to 1 (postitive means player is moving right) (0 means player isnt pressing a button to move)
        float moveDirection = Input.GetAxis("Horizontal"); 
        
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
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
