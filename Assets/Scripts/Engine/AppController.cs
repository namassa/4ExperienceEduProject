using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// karol@4experience.co
// core controller of the app
public class AppController : MonoBehaviour {

	// app should know about platform but:) 
	public DeploymentPlatform CurrentPlatform { get; private set; }

	// simple event
	public System.Action onInitialized = delegate { };

	// half singleton
	public static AppController Instance { get; private set; }
	void Awake() {
		Instance = this;

		DetectCurrentPlatform ();
	}

	//
	void DetectCurrentPlatform() {
		CurrentPlatform = DeploymentPlatform.DEVELOPMENT;

		#if PLATFORM_GEARVR
		CurrentPlatform = DeploymentPlatform.GEARVR;
		#endif

		#if LOG_ENGINE
		Debug.Log("AppController : Detect CurrentPlatform ["+CurrentPlatform+"]");
		#endif
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
		Debug.Log("AppController : Load Platform Setup");
		#endif
		// load platform specific prefabs from scene just once as engine layer. Rest will be handled via game scene manager
		AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (1, UnityEngine.SceneManagement.LoadSceneMode.Additive);

		while (!async.isDone) {
			yield return new WaitForEndOfFrame ();
		}

		#if LOG_ENGINE
		Debug.Log("AppController : Load Additional Engine Setup");
		#endif

		// load engine components
		async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (2, UnityEngine.SceneManagement.LoadSceneMode.Additive);

		while (!async.isDone) {
			yield return new WaitForEndOfFrame ();
		}
	
		// 
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
