using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScenes { Menu } 

// karol@4experience.co
// responsible for changing scenes and broadcasting progress and isDone events
public class SceneLoadingController : MonoBehaviour {

	// half singleton
	public static SceneLoadingController Instance { get; private set; }

	void Awake() {
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

	//
	public bool IsLoading { get; private set; }
	public float Progress { get; private set; }
	public System.Action<GameScenes> onLoadingComplete = delegate { };
	public System.Action<GameScenes> onLoadingBegin = delegate { };

	//
	void Start() {
		IsLoading = false;
		Progress = 0f;
	}
		
	//
	public void LoadMainScene(GameScenes scene) {
        // TODO Code scene loading with unloading current scene
        StartCoroutine(SceneLoad(GameScenes.Menu));
	}
    public void LoadScene(GameScenes scene, bool withUnload)
    {
        StartCoroutine(SceneLoad(scene, withUnload));
    }

    IEnumerator SceneLoad(GameScenes scene, bool withUnload = false)
    {
        if(withUnload)
        {
            Scene sceneToUnload = SceneManager.GetActiveScene();
            AsyncOperation unloadScene = SceneManager.UnloadSceneAsync(sceneToUnload.name);
            while (!unloadScene.isDone)
            {
                yield return new WaitForEndOfFrame();
            }
        }
        
        string sceneToLoad = GetSceneName(scene);

        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while(!loading.isDone)
        {
            Progress = loading.progress;
            yield return new WaitForEndOfFrame();
        }

        Scene loadedScene = SceneManager.GetSceneByName(sceneToLoad);
        SceneManager.SetActiveScene(loadedScene);
    }

	//
	private string GetSceneName(GameScenes scene) {
		switch (scene) {
		case GameScenes.Menu:
			return "002_Menu";
            default:
			return string.Empty;
		}
	}
}
