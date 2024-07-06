using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothingTime = .2f;
    private Vector3 _velocity;
    public Vector3 cameraOffset;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z) + cameraOffest;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos,
            ref _velocity, smoothingTime);
    }
}
