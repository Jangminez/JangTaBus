using UnityEngine;

public static class PlayerPrefsHandler
{
    const string SHIP_BESTSCORE = "SHIP_BESTSCORE";
    const string SHIP_GOAL = "SHIP_GOAL";
    const string FARM_BESTSCORE = "FARM_BESTSCORE";
    const string FARM_GOAL = "FARM_GOAL";
    const string DUNGEON_BESTSCORE = "DUNGEON_BESTSCORE";
    const string DUNGEON_GOAL = "DUNGEON_GOAL";
    const string COIN = "COIN";

    public static int GetShipBestScore()
    {
        int best = PlayerPrefs.GetInt(SHIP_BESTSCORE, 0);
        return best;
    }

    public static void SetShipBestScore(int score)
    {
        PlayerPrefs.SetInt(SHIP_BESTSCORE, score);
    }

    public static int GetShipGoalScore()
    {
        int goal = PlayerPrefs.GetInt(SHIP_GOAL, 0);
        return goal;
    }

    public static void SetShipGoalScore(int score)
    {
        PlayerPrefs.SetInt(SHIP_GOAL, score);
    }

    public static int GetFarmBestScore()
    {
        int best = PlayerPrefs.GetInt(FARM_BESTSCORE, 0);
        return best;
    }

    public static void SetFarmBestScore(int score)
    {
        PlayerPrefs.SetInt(FARM_BESTSCORE, score);
    }

    public static int GetFarmGoalScore()
    {
        int goal = PlayerPrefs.GetInt(FARM_GOAL, 0);
        return goal;
    }

    public static void SetFarmGoalScore(int score)
    {
        PlayerPrefs.SetInt(FARM_GOAL, score);
    }

    public static int GetDungeonBestScore()
    {
        int best = PlayerPrefs.GetInt(DUNGEON_BESTSCORE, 0);
        return best;
    }

    public static void SetDungeonBestScore(int score)
    {
        PlayerPrefs.SetInt(DUNGEON_BESTSCORE, score);
    }
    public static int GetDungeonGoalScore()
    {
        int goal = PlayerPrefs.GetInt(DUNGEON_GOAL, 0);
        return goal;
    }

    public static void SetDungeonGoalScore(int score)
    {
        PlayerPrefs.SetInt(DUNGEON_GOAL, score);
    }

    public static int GetCoin()
    {
        int coin = PlayerPrefs.GetInt(COIN, 0);
        return coin;
    }

    public static void SetCoin(int coin)
    {
        PlayerPrefs.SetInt(COIN, coin);
    }

}
