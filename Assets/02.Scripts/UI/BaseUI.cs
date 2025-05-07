using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;
    protected GameManager gameManager;
    public GameObject gameOverUI;

    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected TextMeshProUGUI goalText;
    [SerializeField] protected TextMeshProUGUI finalScoreText;
    [SerializeField] protected TextMeshProUGUI bestScoreText;
    [SerializeField] protected Button startButton;
    [SerializeField] protected Button restartButton;
    [SerializeField] protected Button exitButton;
    [SerializeField] protected Button exitBtn;

    public virtual void Init(GameManager gameManager, UIManager uiManager)
    {
        this.gameManager = gameManager;
        this.uiManager = uiManager;

        // 버튼 이벤트 연결
        startButton.onClick.AddListener(ClickStartButton);
        restartButton.onClick.AddListener(ClickRestartButton);
        exitButton.onClick.AddListener(ClickExitButton);
        exitBtn.onClick.AddListener(ClickExitButton);
    }

    // 점수 UI 설정
    public virtual void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    // 게임 오버 UI 설정
    public virtual void SetGameOverUI()
    {
        finalScoreText.text = gameManager.MiniGameScore.ToString();
        bestScoreText.text = gameManager.MiniGameBestScore.ToString();

        gameOverUI.SetActive(true);
    }

    // 타이머 UI 설정 (필요시 사용)
    public virtual void SetTimer(float time)
    {

    }

    // 시작 버튼 클릭 시 
    protected virtual void ClickStartButton()
    {
        startButton.transform.parent.gameObject.SetActive(false);
        gameManager.StartMiniGame();
    }

    // 재시작 버튼 클릭 시 
    protected virtual void ClickRestartButton()
    {
        gameManager.RestartMiniGame();
    }

    // 나가기 버튼 클릭 시
    protected virtual void ClickExitButton()
    {
        gameManager.ExitMiniGame();
    }
}
