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

    // Update is called once per frame
    void Update(){
        if(grounded && Input.GetAxis("Jump")>0){
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }
    void FixedUpdate()
    {
        //check if player is on the ground (otherwise the player is falling)
        //if player is intersecting the ground "grounded" will be true, otherwise, false.
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckerRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("VerticleSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if(move>0 && !facingRight){
            Flip();
        } else if(move<0 && facingRight){
            Flip();
        }
    }
    //this flips the character to the right orientation when they switch the direction they are moving
    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
