using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    protected UIManager uiManager;
    protected GameManager gameManager;

    public virtual void Awake()
    {
        GameManager.Instance.currentMiniGame = this;
    }

    public virtual void Init(GameManager gameManager, UIManager uiManager)
    {
        this.gameManager = gameManager;
        this.uiManager = uiManager;

        gameManager.MiniGameScore = 0;
        AddScore(gameManager.MiniGameScore);
        Time.timeScale = 0f;
    }

    public virtual void GameStart()
    {
        Time.timeScale = 1f;
    }

    public virtual void GameOver()
    {
        uiManager.SetGameOverUI();
    }

    public virtual void AddScore(int score)
    {
        gameManager.MiniGameScore += score;
        uiManager.UpdateScoreText(gameManager.MiniGameScore);
    }
}
