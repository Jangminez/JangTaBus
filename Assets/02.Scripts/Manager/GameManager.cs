using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    SceneLoadManager sceneLoadManager;
    UIManager uiManager;
    public SoundManager SoundManager { private set; get; }

    private int coin;
    public int Coin
    {
        get => coin;
        set => coin = Math.Max(0, value);
    }

    public MiniGameManager currentMiniGame;
    private int miniGameScore;
    public int MiniGameScore { get => miniGameScore; set => miniGameScore = Math.Max(0, value); }
    private int miniGameBestScore;
    public int MiniGameBestScore { get => miniGameBestScore; set => miniGameBestScore = Math.Max(0, value); }
    private int shipGame_Goal;
    public int ShipGame_Goal { get => shipGame_Goal; }
    private int farmGame_Goal;
    public int FarmGame_Goal { get => farmGame_Goal; }

    protected override void Awake()
    {
        base.Awake();

        InitGoalScore();
        coin = PlayerPrefs.GetInt("Coin", 0);
    }

    void Start()
    {
        sceneLoadManager = GetComponentInChildren<SceneLoadManager>();
        uiManager = GetComponentInChildren<UIManager>();
        SoundManager = GetComponentInChildren<SoundManager>();

        // 씬 로딩 이벤트 연결
        if (sceneLoadManager != null)
            sceneLoadManager.onSceneLoaded += OnMiniGameLoaded;

        uiManager.SetCoinText(coin);
    }



    #region  미니게임 관련

    // 각 미니게임의 목표 점수 초기화
    void InitGoalScore()
    {
        shipGame_Goal = PlayerPrefs.GetInt("SHIPGAME_GOAL", 10);
        farmGame_Goal = PlayerPrefs.GetInt("FARMGAME_GOAL", 100);
    }

    // 미니게임 씬 로드 시 초기화
    void OnMiniGameLoaded(string sceneName)
    {
        if (sceneName == "MainScene")
        {
            uiManager.ActiveCoinCanvas(true);
            SoundManager.SetBasicBGM();
        }

        else
        {
            uiManager.ActiveCoinCanvas(false);

            miniGameScore = 0;
            miniGameBestScore = 0;

            InitMiniGame();
        }
    }

    void InitMiniGame()
    {
        currentMiniGame = FindObjectOfType<MiniGameManager>();
        uiManager.currentUI = FindObjectOfType<BaseUI>();

        if (currentMiniGame && uiManager)
        {
            uiManager.currentUI.Init(this, uiManager);
            currentMiniGame.Init(this, uiManager);
        }
    }

    public void StartMiniGame()
    {
        currentMiniGame.GameStart();
    }

    public void MiniGameOver()
    {
        currentMiniGame.GameOver();
    }

    public void RestartMiniGame()
    {
        sceneLoadManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitMiniGame()
    {
        sceneLoadManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void AddScoreMiniGame(int score)
    {
        currentMiniGame.AddScore(score);
    }

    /// <summary>
    /// Ship 미니게임 씬 로드
    /// </summary>
    public void PlayShipGame()
    {
        sceneLoadManager.LoadScene("MiniGame_Ship");
    }

    /// <summary>
    /// Farm 미니게임 씬 로드
    /// </summary>
    public void PlayFarmGame()
    {
        sceneLoadManager.LoadScene("MiniGame_Farm");
    }

    // 각 미니 게임 목표 점수 체크
    public void CheckGoal(MiniGameType type)
    {
        int rewardCoin = 0;

        switch (type)
        {
            case MiniGameType.Ship:
                rewardCoin = 10 * miniGameScore;

                if (miniGameScore >= shipGame_Goal)
                {
                    shipGame_Goal += 10;
                    PlayerPrefs.SetInt("SHIPGAME_GOAL", shipGame_Goal);

                    uiManager.SetGoalUI(true, rewardCoin * 2);
                    coin += rewardCoin * 2;
                    uiManager.SetCoinText(coin);
                }
                else
                {
                    uiManager.SetGoalUI(false, rewardCoin);
                    coin += rewardCoin;
                    uiManager.SetCoinText(coin);
                }

                PlayerPrefs.SetInt("Coin", coin);
                break;

            case MiniGameType.Farm:
                rewardCoin = miniGameScore;
                if (miniGameScore >= farmGame_Goal)
                {
                    farmGame_Goal += 50;
                    PlayerPrefs.SetInt("FARMGAME_GOAL", farmGame_Goal);

                    uiManager.SetGoalUI(true, rewardCoin * 2);
                    coin += rewardCoin * 2;
                    uiManager.SetCoinText(coin);
                }
                else
                {
                    uiManager.SetGoalUI(false, rewardCoin);
                    coin += rewardCoin;
                    uiManager.SetCoinText(coin);
                }

                PlayerPrefs.SetInt("Coin", coin);
                break;


            case MiniGameType.Dungeon:
                break;
        }

    }
    #endregion
}
