using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public ParticleSystem poof;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Coin"))
    {
        GameManager.Score++;
        other.gameObject.SetActive(false);
        poof.Play();
    }
}
}
