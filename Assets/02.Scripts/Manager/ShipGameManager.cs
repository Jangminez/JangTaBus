using UnityEngine;

public class ShipGameManager : MiniGameManager
{
    [SerializeField] private BackGroundLoop backGroundLoop;
    [SerializeField] private AudioClip bgmClip;
    public override void Init(GameManager gameManager, UIManager uiManager)
    {
        base.Init(gameManager, uiManager);

        gameManager.MiniGameBestScore = PlayerPrefs.GetInt("SHIP_BESTSCORE", 0);
        backGroundLoop = FindObjectOfType<BackGroundLoop>();
        soundManager.ChangeBgm(bgmClip);
    }

    public override void GameOver()
    {
        base.GameOver();
        backGroundLoop.isGameOver = true;
        gameManager.CheckGoal(MiniGameType.Ship);
    }

    public override void AddScore(int score)
    {
        base.AddScore(score);

        if (gameManager.MiniGameScore > gameManager.MiniGameBestScore)
        {
            PlayerPrefs.SetInt("SHIP_BESTSCORE", gameManager.MiniGameScore);
        }
    }
}
