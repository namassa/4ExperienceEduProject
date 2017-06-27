using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// FEEDBACK:
// karol.ryt@gmail.com
//  1. wywal enuma;) fajne ze jest ale bedziemy tylko robic coroutine
//  2. popraw kod tak by enumow nie bylo
//  3. to aktywowanie scen na spacji tez bym olal:)
//  4. jak masz takie cos jak w 42 lini z System.Action<> nazwaeventa = delegate { }; to nie potrzeba sprawdzac w twoich funkacjach
//	   czy istnieja eventy a po prosty wolac onLoadingBegin(scena); To tez wiec sobie skoryguj i daj do coroutyny:) tak by o 2 funkcje mniej miec.


// karol@4experience.co
// responsible for changing scenes and broadcasting progress and isDone events
public class SceneLoadingController : MonoBehaviour {

    enum SceneLoadingMode {
        Unity_LoadSceneSingle,
        Unity_LoadSceneAdditive,
        Unity_LoadSceneAsyncSingle,
        Unity_LoadSceneAsyncAdditive,
        Custom_AsyncLoad
    }

	// karol
	// z racji wyzej tego nam nie potrzeba
    [SerializeField]
    private SceneLoadingMode sceneLoadingMode = SceneLoadingMode.Custom_AsyncLoad;

	// half singleton
	public static SceneLoadingController Instance { get; private set; }
	void Awake() {
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

    //
	public bool IsLoading { get; private set; }
	public float Progress { get; private set; }
	public System.Action<GameScene> onLoadingComplete = delegate { };
	public System.Action<GameScene> onLoadingBegin = delegate { };

	//
	void Start() {
		IsLoading = false;
		Progress = 0f;
	}
		
	//
	public void LoadScene(GameScene scene, bool unloadCurrent) {
        // TODO Code scene loading with unloading current scene

        if (IsLoading) {
            Debug.Log("Already loading a scene!");
        } else {
            switch (sceneLoadingMode)
            {
                case SceneLoadingMode.Unity_LoadSceneSingle:
                    SceneManager.LoadScene(GetSceneName(scene), LoadSceneMode.Single);
                    break;

                case SceneLoadingMode.Unity_LoadSceneAdditive:
                    SceneManager.LoadScene(GetSceneName(scene), LoadSceneMode.Additive);
                    break;

                case SceneLoadingMode.Unity_LoadSceneAsyncSingle:
                    SceneManager.LoadSceneAsync(GetSceneName(scene), LoadSceneMode.Single);
                    break;

                case SceneLoadingMode.Unity_LoadSceneAsyncAdditive:
                    SceneManager.LoadSceneAsync(GetSceneName(scene), LoadSceneMode.Additive);
                    break;

                case SceneLoadingMode.Custom_AsyncLoad:
                    StartCoroutine(Custom_AsyncLoadCor(scene, unloadCurrent));
                    break;
            }
        }        
	}

	//
	private string GetSceneName(GameScene scene) {
		switch (scene) {
	        case GameScene.Menu:
		        return "002_Menu";

            default:
			return string.Empty;
		}
	}

    //
    IEnumerator Custom_AsyncLoadCor(GameScene scene, bool unloadCurrent)
    {
        yield return new WaitForSeconds (1f);

        Scene currScene = SceneManager.GetActiveScene();
        Debug.Log(currScene.name);

        AsyncOperation asyncLoadOp;

        if (unloadCurrent) {
            AsyncOperation asyncUnloadOp = SceneManager.UnloadSceneAsync(currScene);
            
            while (!asyncUnloadOp.isDone) {
                yield return new WaitForEndOfFrame();
            }
        }

       
        asyncLoadOp = SceneManager.LoadSceneAsync(GetSceneName(scene), LoadSceneMode.Additive);
        asyncLoadOp.allowSceneActivation = false;

        HandleLoadingStart(scene);

        while (!asyncLoadOp.isDone) {
            // unity's loading progress is clamped between 0-0.9
            // value of 1 means completion
            
            // convert progress value to 0-1 
            Progress = Mathf.Clamp01(asyncLoadOp.progress / 0.9f);
            Debug.Log("Loading progress: " + (Progress * 100) + "%");

            if (asyncLoadOp.progress == 0.9f) {
                Debug.Log("Press space to activate loaded scene");
                if (Input.GetKeyDown(KeyCode.Space)) {
                    asyncLoadOp.allowSceneActivation = true;

                    HandleLoadingFinished(scene);
                }
            }

            yield return null;
        }
    }

    //
    void HandleLoadingStart(GameScene scene)
    {
        if (onLoadingBegin != null)
        {
            onLoadingBegin(scene);
        }

        IsLoading = true;
    }

    //
    void HandleLoadingFinished(GameScene scene)
    {
        if (onLoadingComplete != null)
        {
            onLoadingComplete(scene);
        }

        IsLoading = false;
    }
}
