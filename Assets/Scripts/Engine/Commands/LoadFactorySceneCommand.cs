using UnityEngine;

public class LoadFactorySceneCommand : MonoBehaviour, ICommand
{
    public void Execute()
    {
        FindObjectOfType<SceneLoadingController>().LoadScene(GameScene.Factory, true);
    }
}