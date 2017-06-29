using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInvoker : MonoBehaviour
{
    public void LoadFactory()
    {
        FindObjectOfType<SceneLoadingController>().LoadScene(GameScene.Factory, true);
    }

}
