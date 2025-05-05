using System;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public BaseUI currentUI;

    void Start()
    {
        currentUI.Init(this);
    }

    public void UpdateScoreText(int score)
    {
        currentUI.UpdateScoreText(score);
    }

    public void SetGameOverUI()
    {
        currentUI.SetGameOverUI();
    }

}
