using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D theRB;

    public Vector2 moveDir;

    public GameObject impactEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = moveDir * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (impactEffect != null)
        {
            Destroy(Instantiate(impactEffect, transform.position, Quaternion.identity),1f);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
