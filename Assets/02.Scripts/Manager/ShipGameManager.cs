using UnityEngine;

public class ShipGameManager : MiniGameManager
{
    static ShipGameManager instance;
    public static ShipGameManager Instance { get => instance; }
    [SerializeField] private BackGroundLoop backGroundLoop;

    public override void Init(GameManager gameManager, UIManager uiManager)
    {
        base.Init(gameManager, uiManager);

        gameManager.MiniGameBestScore = PlayerPrefs.GetInt("SHIP_BESTSCORE", 0);
        goalScore = gameManager.ShipGame_Goal;
        backGroundLoop = FindObjectOfType<BackGroundLoop>();
    }

    public override void GameOver()
    {
        base.GameOver();
        backGroundLoop.isGameOver = true;
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
