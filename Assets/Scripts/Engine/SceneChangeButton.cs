using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// jarekdc@gmail.com
// on click: load menu level
public class SceneChangeButton : MonoBehaviour {

    SceneLoadingController _sceneLoadingCtrl;
    [SerializeField]
    private GameScene targetScene;

	void Start () {
        _sceneLoadingCtrl = FindObjectOfType<SceneLoadingController>();
    }

    public void LoadMenuLevel () {
        _sceneLoadingCtrl.LoadScene(targetScene);
    }
}
