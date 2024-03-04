using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D playerRB;
    public float jumpForce;

    public Transform feetPosition;
    public float groundDistance = 0.25f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpTime = 0.5f;
    [SerializeField] private Animator animator;



    private bool isGrounded = true;
    private bool isJumping = false;
    private float jumpTimer; 




    // Update is called once per frame
    private void Update()
    {
        //Another way of writing how the jump works, just longer--------

       // if(Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer) == true)
       // {
       //     isGrounded = true;
      //  }
       // else
       // {
      //      isGrounded = false;
      //  }

        //--------------------------------

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer); 


        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            playerRB.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            isJumping = true;
            animator.SetBool("isJumping", true);
        }


        //this controls how long we are allowed to jump
        if(isJumping == true && Input.GetButton("Jump"))
        {
            if(jumpTimer < jumpTime)
            {
                playerRB.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;

                Debug.Log(jumpTimer + jumpTime);
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0f; 
        }

    }
}
