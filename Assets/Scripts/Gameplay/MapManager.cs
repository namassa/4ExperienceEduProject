using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmial.com
// Object holds an reference to the Map object present at current scene
public class MapManager : MonoBehaviour {


	public static MapManager Instance { get; private set;}
	public Map Map { get; private set; }

	//
	void Awake()
	{
		Instance = this;
		DontDestroyOnLoad (gameObject);
		SceneLoadingController.Instance.onLoadingComplete += OnSceneLoadingCompleteHandler;
	}

	//
	void OnDisable ()
	{
		SceneLoadingController.Instance.onLoadingComplete -= OnSceneLoadingCompleteHandler;
	}

	//
	private void OnSceneLoadingCompleteHandler(GameScene scene)
	{
		Map = FindObjectOfType<Map> ();
	}

}
