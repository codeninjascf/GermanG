using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public float respawnDelay = 1.5f;
    public PlayerController player;
    public CameraFollow cam;
    public Vector3 spawnPosition;
    public Transform[] checkpoints;

    private int _currentCheckpoint;

    void Start()
    {
        _currentCheckpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillPlayer()
    {
        player.Disable();

        player.gameObject.SetActive(false);
        StartCoroutine(ResetPlayer());
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);

        Vector3 spawnPosition = checkpoints[_currentCheckpoint].position;

        player.Enable();
        player.gameObject.SetActive(true);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.transform.position = spawnPosition;
        cam.ResetView();
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        int checkpointNumber = Array.IndexOf(checkpoints, checkpoint);

        if (checkpointNumber > _currentCheckpoint)
        {
        _currentCheckpoint = checkpointNumber;
        }
    }
}
