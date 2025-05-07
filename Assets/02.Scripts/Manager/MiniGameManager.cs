using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    protected UIManager uiManager;
    protected GameManager gameManager;
    protected SoundManager soundManager;

    public virtual void Awake()
    {
        // 미니게임 씬이 시작되면 GameManager에 currentMiniGame 설정
        GameManager.Instance.currentMiniGame = this;
    }

    protected virtual void Update()
    {

    }

    // 미니게임 매니저 초기화
    public virtual void Init(GameManager gameManager, UIManager uiManager)
    {
        this.gameManager = gameManager;
        this.uiManager = uiManager;
        soundManager = gameManager.SoundManager;

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
        // 점수가 최고 점수보다 높다면 최고 점수 변경
        if(gameManager.MiniGameScore > gameManager.MiniGameBestScore)
            gameManager.MiniGameBestScore = gameManager.MiniGameScore;

        uiManager.SetGameOverUI();
    }

    // 점수 추가
    public virtual void AddScore(int score)
    {
        gameManager.MiniGameScore += score;
        uiManager.UpdateScoreText(gameManager.MiniGameScore);
    }
}
