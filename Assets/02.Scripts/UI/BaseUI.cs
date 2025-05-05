using TMPro;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;
    public GameObject gameOverUI;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public abstract void UpdateScoreText(int score);
    public abstract void SetGameOverUI();
}
