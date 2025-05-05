using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipUI : BaseUI
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] Button startButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button exitBtn;

    private ShipGameManager shipGameManager;

    void Awake()
    {
        Init(UIManager.Instance);
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        uiManager.currentUI = this;
        shipGameManager = ShipGameManager.Instance;
        startButton.onClick.AddListener(ClickStartButton);
        restartButton.onClick.AddListener(ClickRestartButton);
        exitButton.onClick.AddListener(ClickExitButton);
        exitBtn.onClick.AddListener(ClickExitButton);
    }

    public override void SetGameOverUI()
    {
        finalScoreText.text = shipGameManager.Score.ToString();
        bestScoreText.text = shipGameManager.BestScore.ToString();

        gameOverUI.SetActive(true);
    }

    public override void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    void ClickStartButton()
    {
        startButton.transform.parent.gameObject.SetActive(false);
        shipGameManager.GameStart();
    }

    void ClickRestartButton()
    {
        shipGameManager.RestartGame();
    }

    void ClickExitButton()
    {
        shipGameManager.ExitGame();
    }
}
