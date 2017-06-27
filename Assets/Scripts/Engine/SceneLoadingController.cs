using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// FEEDBACK:
// karol.ryt@gmail.com
// 1. wywalic logi albo poprawic pod Log_ENgine

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
		// TODO Code scene loading with unloading current scene
		StartCoroutine (LoadSceneCoroutine (scene, true));
	}


	private IEnumerator LoadSceneCoroutine(GameScene scene, bool withUnload = false) {

		#if LOG_ENGINE
		Debug.Log("SceneLoadingController : Start Loading Scene ["+scene+"]");
		#endif

		//
		onLoadingBegin (scene);

		string sceneToLoad = GetSceneName (scene);

		if (withUnload) {
			Scene currentLoadedScene = SceneManager.GetActiveScene ();
			AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync (currentLoadedScene.name);
			Debug.Log ("Unload " + currentLoadedScene.name);
			// loop
			while (!asyncUnload.isDone) {
				yield return new WaitForEndOfFrame ();
			}
		}

		// start loading
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad,LoadSceneMode.Additive);
		// change flags
		IsLoading = true;

		// loop
		while (!async.isDone) {
			Progress = async.progress;
			yield return new WaitForEndOfFrame ();
		}

		// clear flags
		IsLoading = false;

		Scene loadedScene = SceneManager.GetSceneByName (sceneToLoad);
		SceneManager.SetActiveScene (loadedScene);

		#if LOG_ENGINE
		Debug.Log("SceneLoadingController : Loading Complete Scene ["+scene+"]");
		#endif

		// call event
		onLoadingComplete (scene);
	}
	//
	private string GetSceneName(GameScene scene) {
		switch (scene) {
		case GameScene.Menu:
			return "002_Menu";
		case GameScene.ExampleScene1:
			return "011_ExampleScene";
		case GameScene.ExampleScene2:
			return "012_ExampleScene";

            default:
			return string.Empty;
		}
	}

}
