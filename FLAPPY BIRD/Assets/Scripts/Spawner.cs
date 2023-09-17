using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject spikes;
   public float height;

    void Start()
    {
        InvokeRepeating("InstantiateObjects" , 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(5, Random.Range(-height, height), 0);
    }
    void InstantiateObjects()
    {
        Instantiate(spikes, transform.position, transform.rotation);
    }
}
