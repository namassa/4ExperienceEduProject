using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



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
	public System.Action<GameScene> onLoadingComplete = delegate { };
	public System.Action<GameScene> onLoadingBegin = delegate { };

	//
	void Start() {
		IsLoading = false;
		Progress = 0f;
	}

	//
	public void LoadScene(GameScene scene) {
		StartCoroutine (LoadSceneCoroutine(scene));
	}

	//
	private IEnumerator LoadSceneCoroutine(GameScene scene) {

		bool unloadPrevious = AppController.Instance.Initialized;
		onLoadingBegin(scene);
		string sceneName = GetSceneName (scene);

		//Unload

		if (unloadPrevious) {
			AsyncOperation sceneUnloading = null;
			sceneUnloading = SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene ().name);
			yield return new WaitUntil (() => !sceneUnloading.isDone);
		}

		//Load
		AsyncOperation sceneLoading = SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
		IsLoading = true;
		while(!sceneLoading.isDone) {
			Progress = sceneLoading.progress;
			yield return new WaitForEndOfFrame ();
		}
		IsLoading = false;


		Scene loadedScene = SceneManager.GetSceneByName (sceneName);
		SceneManager.SetActiveScene(loadedScene);

		onLoadingComplete (scene);
	}

	//
	private string GetSceneName(GameScene scene) {
		switch (scene) {
		case GameScene.Menu:
			return "002_Menu";

		case GameScene.Game:
			return "003_Game";

            default:
			return string.Empty;
		}
	}
}
