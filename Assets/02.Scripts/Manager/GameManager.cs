using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    SceneLoadManager sceneLoadManager;

    void Start()
    {
        sceneLoadManager = FindObjectOfType<SceneLoadManager>();
    }
    public void PlayShipGame()
    {
        sceneLoadManager.LoadScene("MiniGame_Ship");
    }

    
}
