using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void LoadExample1(){
		SceneLoadingController.Instance.LoadScene (GameScene.ExampleScene1);
		Debug.Log ("e1");
	}
	public void LoadExample2(){
		SceneLoadingController.Instance.LoadScene (GameScene.ExampleScene2);
		Debug.Log ("e2");
	}
}
