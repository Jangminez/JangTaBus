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
        coin = PlayerPrefsHandler.GetCoin();
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
        shipGame_Goal = PlayerPrefsHandler.GetShipGoalScore();
        farmGame_Goal = PlayerPrefsHandler.GetFarmGoalScore();
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

    // 미니게임 관련 변수들 초기화
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

    // 미니게임 시작
    public void StartMiniGame()
    {
        currentMiniGame.GameStart();
    }

    // 미니게임 게임오버
    public void MiniGameOver()
    {
        currentMiniGame.GameOver();
    }

    // 미니게임 재시작
    public void RestartMiniGame()
    {
        sceneLoadManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 미니게임 나가기 (메인으로 돌아가기)
    public void ExitMiniGame()
    {
        sceneLoadManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    // 미니게임 점수 추가
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

    // 각 미니 게임 목표 점수 체크 및 보상 지급
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
                    PlayerPrefsHandler.SetShipGoalScore(shipGame_Goal);

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

                PlayerPrefsHandler.SetCoin(coin);
                break;

            case MiniGameType.Farm:
                rewardCoin = miniGameScore;
                if (miniGameScore >= farmGame_Goal)
                {
                    farmGame_Goal += 50;
                    PlayerPrefsHandler.SetFarmGoalScore(farmGame_Goal);

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

                PlayerPrefsHandler.SetCoin(coin);
                break;


            case MiniGameType.Dungeon:
                break;
        }

    }
    #endregion
}
