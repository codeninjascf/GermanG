using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int levelNumber;
    public float respawnDelay = 1.5f;
    public string menuSceneName;
    public string nextLevelName;
    public bool shurikensEnabled;
    public string LevelMusicName;
    public float exitTime = 2f;

    public PlayerController player;
    public CameraFollow cam;
    public Vector3 spawnPosition;
    public Transform[] checkpoints;
    public Transform[] collectibles;
    public GameObject deathparticles;
    public GameObject levelCompleteMenu;
    public RubiesDisplay rubiesDisplay;
    public GameObject exitText;

    private int _currentCheckpoint;
    private bool[] _collectiblesCollected;
    private int _shuriken;
    private float _escapeTime;

    private AudioManager _audioManager;

    void Start()
    {
        _currentCheckpoint = 0;
        _collectiblesCollected = new bool [3];

        levelCompleteMenu.SetActive(false);
        rubiesDisplay.levelNumber = levelNumber;
        exitText.SetActive(false);

        _audioManager = FindObjectOfType<AudioManager>();

        _audioManager.FindAudio(LevelMusicName).loop = true;
        _audioManager.PlayAudio(LevelMusicName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            exitText.SetActive(true);
            _escapeTime += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            exitText.SetActive(false);
            _escapeTime = 0;
        }

        if(_escapeTime >= exitTime)
        {
            LoadMenu();
        }
    }

    public void KillPlayer()
    {
        player.Disable();

        player.gameObject.SetActive(false);

        GameObject particles = Instantiate(deathparticles, new
            Vector3(player.transform.position.x, player.transform.position.y),
            Quaternion.identity);
        Destroy(particles, 1f);

        StartCoroutine(ResetPlayer());
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);

        Vector3 spawnPosition = checkpoints[_currentCheckpoint].position;

        if(checkpoints [_currentCheckpoint].localScale.y == -1)
        {
            player.GravityFlipped = true;
            spawnPosition += new Vector3(0, -player.spriteHeight, 0);
        }
        else
        {
            player.GravityFlipped = false;
        }

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

    public void GotCollectible(Transform collectible)
    {
        int collectibleNumber = Array.IndexOf(collectibles, collectible);

        _collectiblesCollected[collectibleNumber] = true;
    }
    public void ReachedGoal()
    {
        player.Disable();

        PlayerPrefs.SetInt("Level" + levelNumber + "_Complete", 1);
        for (int i = 0; i < 3; i++)
        {
            if (_collectiblesCollected[i])
            {
                PlayerPrefs.SetInt("Level" + levelNumber + "_Gem" +
                    (i + 1), 1);
            }
        }

        levelCompleteMenu.SetActive(true);
        levelCompleteMenu.GetComponent<Animator>().SetTrigger("Activate");
        rubiesDisplay.UpdateRubies();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);      
        rubiesDisplay.UpdateRubies();
    }
}
    