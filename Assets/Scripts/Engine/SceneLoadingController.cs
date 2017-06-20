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
		// TODO Code scene loading with unloading current scene
	}

	//
	private string GetSceneName(GameScene scene) {
		switch (scene) {
		case GameScene.Menu:
			return "010_Menu";

            default:
			return string.Empty;
		}
	}
}
