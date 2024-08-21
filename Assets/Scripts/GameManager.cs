using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI AIScoreText;
    [SerializeField] private TextMeshProUGUI playerWinText;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Ball ballScript;

    private int playerScore = 0;
    private int AiScore = 0;
    private int maxLimitScore = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1;
    }

    public void UpdateScore(bool isPlayer)
    {
        if (isPlayer)
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        } else
        {
            AiScore++;
            AIScoreText.text = AiScore.ToString();
        }
        if (playerScore >= maxLimitScore || AiScore >= maxLimitScore)
        {
            GameOver();
        }
        ballScript.ReplaceBall();
    }
    private void GameOver()
    {
        gameOverCanvas.SetActive(true);
        if (playerScore >= 5)
        {
            playerWinText.text = "You Win";
        } else if (AiScore >= 5)
        {
            playerWinText.text = "You Lose";
        }
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
