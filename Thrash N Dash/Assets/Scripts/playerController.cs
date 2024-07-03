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

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if(move>0 && !facingRight){
            Flip();
        } else if(move<0 && facingRight){
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
