using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public BaseUI currentUI;
    [SerializeField] private GameObject goalCanvas;
    [SerializeField] private Button okButton;
    [SerializeField] private GameObject successTitle;
    [SerializeField] private GameObject failTitle;
    [SerializeField] private TextMeshProUGUI rewardCoinText;
    [SerializeField] private GameObject coinCanvas;
    private TextMeshProUGUI coinText;

    protected override void Awake()
    {
        base.Awake();
        okButton.onClick.AddListener(ClickOkButton); 
        coinText = coinCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }  

    public void UpdateScoreText(int score)
    {
        currentUI.UpdateScoreText(score);
    }

    public void SetGameOverUI()
    {
        currentUI.SetGameOverUI();
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

    void ClickOkButton()
    {
        goalCanvas.SetActive(false);
    }
    
    public void ActiveCoinCanvas(bool isActive)
    {
        coinCanvas.SetActive(isActive);
    }
    
    public void SetCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }
}
