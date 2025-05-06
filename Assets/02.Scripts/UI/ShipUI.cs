using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipUI : BaseUI
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI goalText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] Button startButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button exitBtn;

    public override void Init(GameManager gameManager, UIManager uiManager)
    {
        base.Init(gameManager, uiManager);

        // 버튼 이벤트 연결
        startButton.onClick.AddListener(ClickStartButton);
        restartButton.onClick.AddListener(ClickRestartButton);
        exitButton.onClick.AddListener(ClickExitButton);
        exitBtn.onClick.AddListener(ClickExitButton);

        // 목표 점수 UI 표시
        goalText.text = gameManager.ShipGame_Goal.ToString();
    }

    // 게임 오버 UI
    public override void SetGameOverUI()
    {
        finalScoreText.text = gameManager.MiniGameScore.ToString();
        bestScoreText.text = gameManager.MiniGameBestScore.ToString();

        gameOverUI.SetActive(true);
    }

    public override void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    void ClickStartButton()
    {
        startButton.transform.parent.gameObject.SetActive(false);
        gameManager.StartMiniGame();
    }

    void ClickRestartButton()
    {
        gameManager.RestartMiniGame();
    }

    void ClickExitButton()
    {
        gameManager.ExitMiniGame();
    }
}
