using UnityEngine;

// dsiemienik@gmail.com
// command creating character objects
public class RespawnCharacterCommand : MonoBehaviour, ICommand
{

    public GameObject CharacterPrefab { private get; set; }
    public Vector3 Position { private get; set; }

    public void ExecuteCommand()
    {
        var character = Instantiate(CharacterPrefab, Position, Quaternion.identity);
        //UIController.monsters.Add(character);
    }
}
