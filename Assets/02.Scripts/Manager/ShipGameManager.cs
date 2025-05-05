using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipGameManager : MonoBehaviour
{
    static ShipGameManager instance;
    public static ShipGameManager Instance { get => instance; }
    private UIManager uiManager;
    [SerializeField] private BackGroundLoop backGroundLoop;
    int currentScore = 0;
    public int Score { get => currentScore; }
    int bestScore = 0;
    public int BestScore { get => bestScore; }
    void Awake()
    {
        instance = this;
        bestScore = PlayerPrefs.GetInt("SHIP_BESTSCORE", 0);

        Time.timeScale = 0f;
    }

    void Start()
    {
        uiManager = UIManager.Instance;
        backGroundLoop = FindObjectOfType<BackGroundLoop>();

        AddScore(currentScore);
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        uiManager.SetGameOverUI();
        backGroundLoop.isGameOver = true;
    }

    public void RestartGame()
    {
        SceneLoadManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        SceneLoadManager.Instance.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScoreText(currentScore);

        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("SHIP_BESTSCORE", currentScore);
        }
    }
}
