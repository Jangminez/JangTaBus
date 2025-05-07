using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public BaseUI currentUI;
    [SerializeField] private GameObject goalCanvas;
    [SerializeField] private Button okButton;
    [SerializeField] private GameObject successTitle;
    [SerializeField] private GameObject failTitle;
    [SerializeField] private TextMeshProUGUI rewardCoinText;
    [SerializeField] private GameObject coinCanvas;
    private TextMeshProUGUI coinText;

    void Awake()
    {
        okButton.onClick.AddListener(ClickOkButton); 
        coinText = coinCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }  

    // 점수 UI 설정
    public void UpdateScoreText(int score)
    {
        currentUI.UpdateScoreText(score);
    }

    // 게임오버 UI 설정
    public void SetGameOverUI()
    {
        currentUI.SetGameOverUI();
    }

    // 타이머 UI 설정
    public void SetTimer(float time)
    {
        currentUI.SetTimer(time);
    }

    /// <summary>
    /// 보상 UI 띄우기
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="rewardCoin"></param>
    public void SetGoalUI(bool isSuccess, int rewardCoin)
    {
        goalCanvas.SetActive(true);

        successTitle.SetActive(isSuccess);
        failTitle.SetActive(!isSuccess);

        rewardCoinText.text = rewardCoin.ToString();
    }

    // 보상 UI 확인 버튼 클릭
    void ClickOkButton()
    {
        goalCanvas.SetActive(false);
    }
    
    // 코인 캔버스 활성화 여부 설정 (MainScene일 때만 활성화)
    public void ActiveCoinCanvas(bool isActive)
    {
        coinCanvas.SetActive(isActive);
    }

    // 코인 UI 설정
    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }
}
