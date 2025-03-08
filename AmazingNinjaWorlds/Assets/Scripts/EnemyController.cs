using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float jumpForce = 7f;

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); 
    }


    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);


    }
}
