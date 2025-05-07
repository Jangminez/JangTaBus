using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipUI : BaseUI
{
    public override void Init(GameManager gameManager, UIManager uiManager)
    {
        base.Init(gameManager, uiManager);

        // 목표 점수 UI 표시
        goalText.text = gameManager.ShipGame_Goal.ToString();
    }
}
