using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    SceneLoadManager sceneLoadManager;
    UIManager uiManager;
    public MiniGameManager currentMiniGame;
    private int miniGameScore;
    public int MiniGameScore { get => miniGameScore; set => miniGameScore = Math.Max(0, value); }
    private int miniGameBestScore;
    public int MiniGameBestScore { get => miniGameBestScore; set => miniGameBestScore = Math.Max(0, value); }
    private int shipGame_Goal;
    public int ShipGame_Goal { get => shipGame_Goal; }

    protected override void Awake()
    {
        base.Awake();

        InitGoalScore();
    }
    void Start()
    {
        sceneLoadManager = FindObjectOfType<SceneLoadManager>();
        uiManager = FindObjectOfType<UIManager>();

        if (sceneLoadManager != null)
            sceneLoadManager.onSceneLoaded += OnMiniGameLoaded;
    }

    // 각 미니게임의 목표 점수 초기화
    void InitGoalScore()
    {
        shipGame_Goal = PlayerPrefs.GetInt("SHIPGAME_GOAL", 10);
    }

    // 미니게임 씬 로드 시 초기화
    void OnMiniGameLoaded()
    {
        currentMiniGame = FindObjectOfType<MiniGameManager>();
        uiManager.currentUI = FindObjectOfType<BaseUI>();

        miniGameScore = 0;
        miniGameBestScore = 0;
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
        SceneLoadManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitMiniGame()
    {
        SceneLoadManager.Instance.LoadScene("MainScene");
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

    // 각 미니 게임 목표 점수 체크
    public void CheckGoal(MiniGameType type)
    {
        int rewardCoin = 10 * miniGameScore;

        switch (type)
        {
            case MiniGameType.Ship:
                if (miniGameScore >= shipGame_Goal)
                {
                    shipGame_Goal += 10;
                    PlayerPrefs.SetInt("SHIPGAME_GOAL", shipGame_Goal);

                    uiManager.SetGoalUI(true, rewardCoin * 2);
                }
                else
                    uiManager.SetGoalUI(false, rewardCoin);
                break;

            case MiniGameType.Dungeon:
                break;
        }

    }
}
