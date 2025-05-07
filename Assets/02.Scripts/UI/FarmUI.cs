using TMPro;
using UnityEngine;

public class FarmUI : BaseUI
{
    [SerializeField] TextMeshProUGUI timeText;

    public override void Init(GameManager gameManager, UIManager uiManager)
    {
        base.Init(gameManager, uiManager);

        // 목표 점수 UI 표시
        goalText.text = gameManager.FarmGame_Goal.ToString();
    }

    public override void SetTimer(float time)
    {
        timeText.text = Mathf.CeilToInt(time).ToString();
    }
}
