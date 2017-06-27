﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Wojciech Sęk
// knotidm@gmail.com
// 26.06.2017
// responsible for changing scenes and broadcasting progress and isDone events
public class SceneLoadingController : MonoBehaviour
{
    private bool IsLoading { get; set; }
    private float Progress { get; set; }
    private Action<GameScene> OnLoadingComplete = delegate { };
    private Action<GameScene> OnLoadingBegin = delegate { };

    public static SceneLoadingController Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        IsLoading = false;
        Progress = 0f;
    }

    public void LoadScene(GameScene gameScene)
    {
        StartCoroutine(LoadSceneAsync(gameScene));
    }

    private IEnumerator LoadSceneAsync(GameScene gameScene)
    {
        OnLoadingBegin(gameScene);

        AsyncOperation unloadSceneAsync = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        while (unloadSceneAsync != null && !unloadSceneAsync.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(GetSceneName(gameScene), LoadSceneMode.Additive);

        IsLoading = true;

        while (loadSceneAsync != null && !loadSceneAsync.isDone)
        {
            Progress = loadSceneAsync.progress;
            yield return new WaitForEndOfFrame();
        }

        IsLoading = false;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(GetSceneName(gameScene)));

        OnLoadingComplete(gameScene);
    }

    private string GetSceneName(GameScene scene)
    {
        switch (scene)
        {
            case GameScene.Menu:
                return "002_Menu";
            case GameScene.Stage1:
                return "003_Stage1";
            case GameScene.Stage2:
                return "004_Stage2";
            default:
                return string.Empty;
        }
    }
}