using UnityEngine;

public class LoadFactorySceneCommand : MonoBehaviour, ICommand
{
    public void ExecuteCommand()
    {
        FindObjectOfType<SceneLoadingController>().LoadScene(GameScene.Factory, true);
    }
}