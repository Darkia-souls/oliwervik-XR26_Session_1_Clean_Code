using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public bool gameOver = false;
    public float gameTime = 0f;

    [Header("Win Condition")]
    [SerializeField] private int winScore = 30;

    private int currentScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (!gameOver)
        {
            gameTime += Time.deltaTime;

            // Manual restart input
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }

            // Check win condition
            if (currentScore >= winScore)
            {
                WinGame();
            }
        }
    }

    // Called by PlayerScore when score changes
    public void ReportScore(int score)
    {
        currentScore = score;
    }

    // Called by PlayerHealth when player dies
    public void PlayerDied()
    {
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            Invoke(nameof(RestartGame), 2f);
        }
    }

    private void WinGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log($"You Win! Final Score: {currentScore}");
            Invoke(nameof(RestartGame), 2f);
        }
    }

    private void RestartGame()
    {
        Debug.Log("Restarting Game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}