using TMPro;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;
    protected GameManager gameManager;
    public GameObject gameOverUI;

    public virtual void Init(GameManager gameManager, UIManager uiManager)
    {
        this.gameManager = gameManager;
        this.uiManager = uiManager;
    }

    public abstract void UpdateScoreText(int score);
    public abstract void SetGameOverUI();
}
