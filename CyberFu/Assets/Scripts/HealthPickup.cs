using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 2;
    public float rotateSpeed = 50f;

    void Start()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Add(healAmount);

            Destroy(gameObject);
        }
    }
}
