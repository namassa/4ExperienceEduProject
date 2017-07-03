using UnityEngine;

public class RespawnMonsterCommand : MonoBehaviour, ICommand
{
    public GameObject MonsterPrefab { private get; set; }
    public Vector3 Position { private get; set; }

    public void ExecuteCommand()
    {
        Instantiate(MonsterPrefab, Position, Quaternion.identity);
    }
}