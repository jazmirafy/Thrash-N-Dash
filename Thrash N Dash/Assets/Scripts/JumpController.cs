using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Transform landingPosition; // Set this to the desired landing position in the inspector
    public float jumpHeight = 5f; // Maximum height of the jump
    public float jumpDuration = 1f; // Duration of the jump from start to finish

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private bool isJumping = false;
    private float jumpProgress = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartJump( Vector2 landingPos)
    {
        //landingPositon = gameObject.GetComponent<Transform>();


        startPosition = transform.position;
        targetPosition = landingPos;
        isJumping = true;
        jumpProgress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If currently jumping, update the jump
        if (isJumping)
        {
            UpdateJump();
        }
    }
        void UpdateJump()
    {
        jumpProgress += Time.deltaTime / jumpDuration;
        if (jumpProgress >= 1f)
        {
            jumpProgress = 1f;
            isJumping = false;
        }

        // Calculate the position using a parabolic equation
        float height = Mathf.Sin(Mathf.PI * jumpProgress) * jumpHeight;
        Vector2 currentPosition = Vector2.Lerp(startPosition, targetPosition, jumpProgress);
        currentPosition.y += height;

        transform.position = currentPosition;
    }
}
