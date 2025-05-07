using UnityEngine;

public class FarmGameManager : MiniGameManager
{
    [SerializeField] private CropsGenerator cropsGenerator;
    [SerializeField] private AudioClip bgmClip;
    [SerializeField] private float limitTime = 60f;
    public override void Init(GameManager gameManager, UIManager uiManager)
    {
        base.Init(gameManager, uiManager);

        gameManager.MiniGameBestScore = PlayerPrefsHandler.GetFarmBestScore();
        cropsGenerator = GetComponentInChildren<CropsGenerator>();
        cropsGenerator.Init();

        soundManager.ChangeBgm(bgmClip);
    }

    public override void GameOver()
    {
        base.GameOver();

        cropsGenerator.isGameOver = true;
        gameManager.CheckGoal(MiniGameType.Farm);
        Time.timeScale = 0f;
    }

    public override void AddScore(int score)
    {
        base.AddScore(score);

        if (gameManager.MiniGameScore > gameManager.MiniGameBestScore)
        {
            PlayerPrefsHandler.SetFarmBestScore(gameManager.MiniGameScore);
        }
    }

    protected override void Update()
    {
        base.Update();

        if (limitTime > 0)
        {
            limitTime -= Time.deltaTime;
            uiManager?.SetTimer(limitTime);
        }
        else if(!cropsGenerator.isGameOver)
        {
            GameOver();
        }
    }
}
