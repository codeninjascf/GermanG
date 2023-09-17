using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.score++;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
