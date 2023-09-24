using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject scoreCanvas;
    public GameObject spawner;
    void Start()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        spawner.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
    gameOverCanvas.SetActive(true);
    spawner.SetActive(false);
    Time.timeScale = 0;
    
    }
}
