using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;
    [Range(0f, 1f)]
    public float smoothingCoefficient = 0.01f;

    public float Height
    {
        set => _target.y = value;
    }

    private Vector3 _target;

    private void Start()
    {
        _target = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target, smoothingCoefficient);
        if (BlockMovement.GameOver)
        {
            cam.orthographicSize = 5 + _target.y;
        }
    }
}
