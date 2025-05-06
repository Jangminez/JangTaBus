using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public BaseUI currentUI;

    public void UpdateScoreText(int score)
    {
        currentUI.UpdateScoreText(score);
    }

    public void SetGameOverUI()
    {
        currentUI.SetGameOverUI();
    }

}
