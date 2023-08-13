using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    public PlayerController player;
    public Transform mainCamera;
    public GameObject platform;

    [Header("UI")] 
    public TextMeshProUGUI scoreText;
    public GameObject gameOverMenu;

    [Header("Other Settings")] 
    public int jumpRangeFactor = 4;
    
    private float _highestPlatform;
    private float _jumpRange;
    private float _height;
    private bool _gameOver;

    public static Vector2 ScreenBounds { get; private set; }
    private float _platformHeight;
    private float _playerHeight;
    
    private void Start()
    {
        _gameOver = false;
        
        _height = 0;
        _jumpRange = (int) (player.jumpForce / jumpRangeFactor);
        
        gameOverMenu.SetActive(false);
        
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _platformHeight = platform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        _playerHeight = player.gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void Update()
    {
        if (!_gameOver && player.transform.position.y > _height)
        {
            scoreText.text = $"{Math.Round(_height * 10)}";
            _height = player.transform.position.y;
        }

        if (!_gameOver && _highestPlatform < _height + ScreenBounds.y * 4)
        {
            float newHeight = _highestPlatform + Random.Range(_platformHeight, _jumpRange);
            float newX = Random.Range(-ScreenBounds.x / 2, ScreenBounds.x / 2);

            Instantiate(platform, new Vector3(newX, newHeight), Quaternion.identity);

            _highestPlatform = newHeight;
        }

        if (!_gameOver && player.transform.position.y + _playerHeight < mainCamera.position.y - ScreenBounds.y)
        {
            _gameOver = true;
            gameOverMenu.SetActive(true);
            player.gameObject.SetActive(false);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
