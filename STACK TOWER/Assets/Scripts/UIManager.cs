using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            scoreText.text = $"Score: {_score}";
        }
    }

    private int _score;

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (BlockMovement.GameOver)
        {
            gameOverText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
    }

    private static void Restart()
    {
        BlockMovement.CurrentBlock = null;
        BlockMovement.LastBlock = null;
        BlockMovement.GameOver = false;
        BlockMovement.XDirection = false;
        
        SceneManager.LoadScene(0);
    }
}
