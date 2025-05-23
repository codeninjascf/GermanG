using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D theRB;

   public float moveSpeed;
   public float jumpForce;
   public Transform groundPoint;
   private bool isOnGround;
   public LayerMask whatIsGround;

   public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

            if (theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            } else if(theRB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }

            isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

            if(Input.GetButtonDown("Jump") && isOnGround)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
        }

        anim.SetBool("isOnGround", isOnGround);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));

    }
}
