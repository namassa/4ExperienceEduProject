using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// jarekdc@gmail.com
// registers actions(scene transitions) on menu buttons
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button loadFactorySceneBtn;

    //
    void Awake()
    {
        // ref do
        loadFactorySceneBtn.onClick.AddListener(LoadFactoryScene); 
    }

    //
    void LoadFactoryScene()
    {
        SceneLoadingController.Instance.LoadScene(GameScene.Factory, true);
    }
}
