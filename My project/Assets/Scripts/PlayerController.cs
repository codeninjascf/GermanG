using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D theRB;

   public float moveSpeed;
   public float jumpForce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

            if(Input.GetButtonDown("Jump"))
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
        }

    }
}
