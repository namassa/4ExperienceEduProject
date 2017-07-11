using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// jarekdc@gmail.com 27.06.2017
// removed unnecessary enum and functions, put debug into #if Log_Engine

// karol@4experience.co
// responsible for changing scenes and broadcasting progress and isDone events
public class SceneLoadingController : MonoBehaviour
{

    // half singleton
    public static SceneLoadingController Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //
    public bool IsLoading { get; private set; }
    public float Progress { get; private set; }
    public System.Action<GameScene> onLoadingComplete = delegate { };
    public System.Action<GameScene> onLoadingBegin = delegate { };

    //
    void Start()
    {
        IsLoading = false;
        Progress = 0f;
    }

    //
    public void LoadScene(GameScene scene, bool unloadCurrent)
    {
        if (IsLoading)
        {
            Debug.LogWarning("Already loading a scene!");
        }
        else
        {
            StartCoroutine(Custom_AsyncLoadCor(scene, unloadCurrent));
        }
    }

    //
    private string GetSceneName(GameScene scene)
    {
        switch (scene)
        {
            case GameScene.Menu:
                return "002_Menu";

            case GameScene.Factory:
                return "003_Factory";

            default:
                return string.Empty;
        }
    }

    //
    IEnumerator Custom_AsyncLoadCor(GameScene scene, bool unloadCurrent)
    {
        yield return new WaitForSeconds(1f);

        Scene currScene = SceneManager.GetActiveScene();
        #if LOG_ENGINE
        Debug.Log("Current scene: " + currScene.name);
        #endif

        AsyncOperation asyncLoadOp;

        if (unloadCurrent)
        {
            AsyncOperation asyncUnloadOp = SceneManager.UnloadSceneAsync(currScene);

            while (!asyncUnloadOp.isDone)
            {
                yield return new WaitForEndOfFrame();
            }
        }


        asyncLoadOp = SceneManager.LoadSceneAsync(GetSceneName(scene), LoadSceneMode.Additive);
        asyncLoadOp.allowSceneActivation = false;

        onLoadingBegin(scene);
        IsLoading = true;

        while (!asyncLoadOp.isDone)
        {
            // unity's loading progress is clamped between 0-0.9
            // value of 1 means completion

            // convert progress value to 0-1
            Progress = Mathf.Clamp01(asyncLoadOp.progress / 0.9f);
            #if LOG_ENGINE
            Debug.Log("Loading progress: " + (Progress * 100) + "%");
            #endif

            if (asyncLoadOp.progress == 0.9f)
            {
                asyncLoadOp.allowSceneActivation = true;
                IsLoading = false;
            }

            yield return null;
        }

        Scene loadedScene = SceneManager.GetSceneByName(GetSceneName(scene));
        SceneManager.SetActiveScene(loadedScene);
		onLoadingComplete(scene);
    }
}
