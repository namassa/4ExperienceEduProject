using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// karol@4experience.co
// core controller of the app
public class AppController : MonoBehaviour {
	
	// simple event
	public System.Action onInitialized = delegate { };

	// half singleton
	public static AppController Instance { get; private set; }
	void Awake() {
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}


	// Use this for initialization
	void Start () {
		//
		LoadSetup ();
	}


	//
	void LoadSetup() {
		#if LOG_ENGINE
		Debug.Log("AppController : Load Specific Setup");
		#endif

		//
		StartCoroutine (LoadSetupCoroutine ());
	}

	//
	IEnumerator LoadSetupCoroutine() {

		#if LOG_ENGINE
		Debug.Log("AppController : Load Async Setup");
		#endif

		// TU POWINNO SIE CALY ASYNC TRZYMAC W LADOWANIU
		AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (1, UnityEngine.SceneManagement.LoadSceneMode.Single);

		while (!async.isDone) {
			yield return new WaitForEndOfFrame ();
		}

	
		// 
		async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (2, UnityEngine.SceneManagement.LoadSceneMode.Additive);

		while (!async.isDone) {
			yield return new WaitForEndOfFrame ();
		}

		OnInitialized ();

		#if LOG_ENGINE
		Debug.Log("AppController : Load Menu Scene");
		#endif
	
		SceneLoadingController.Instance.LoadScene(GameScene.Menu);
	}
		
	//
	void OnInitialized() {
		#if LOG_ENGINE
		Debug.Log("AppController : Call OnInitialized Event");
		#endif

		onInitialized ();
	}
}
