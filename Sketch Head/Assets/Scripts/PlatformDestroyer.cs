using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private static PlatformDestroyer _instance;
    private static float _platformHeight;
    private static Transform _camera;

    private void Awake()
    {
        if (_instance != null) return;
        _instance = this;
        _platformHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        _camera = Camera.main.transform;
    }

    private void Update()
    {
        if (transform.position.y + _platformHeight <  _camera.position.y - GameManager.ScreenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}
