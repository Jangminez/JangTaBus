using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{
    private CanvasGroup canvasGroup;
    public event Action<string> onSceneLoaded;

    protected override void Awake()
    {
        base.Awake();

        canvasGroup = GetComponentInChildren<CanvasGroup>();
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // 씬 비동기 로딩
    IEnumerator LoadSceneAsync(string sceneName)
    {
        OnLoadingScreen();

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        yield return new WaitUntil(() => asyncOperation.isDone);

        onSceneLoaded?.Invoke(sceneName);
        OffLoadingScreen();

        
    }

    void OnLoadingScreen()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    void OffLoadingScreen()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }
}
