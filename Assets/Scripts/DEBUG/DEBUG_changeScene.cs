using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_changeScene : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) && !SceneLoadingController.Instance.IsLoading)
			SceneLoadingController.Instance.LoadScene (GameScene.Game);
	}
}
