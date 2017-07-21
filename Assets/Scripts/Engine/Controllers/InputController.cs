using UnityEngine;

public class InputController : MonoBehaviour
{
    protected FactoryController _factoryController;
    [SerializeField] protected int numberOfObjectsToRespawn = 1;

    private void Awake()
    {
        _factoryController = gameObject.AddComponent<FactoryController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _factoryController.RespawnMonstersByType(MonsterType.Orc, numberOfObjectsToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _factoryController.RespawnMonstersByType(MonsterType.Ogre, numberOfObjectsToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _factoryController.RespawnMonstersByType(MonsterType.Goblin, numberOfObjectsToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _factoryController.RespawnCharactersByType(CharacterType.Hero, numberOfObjectsToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _factoryController.RespawnCharactersByType(CharacterType.Villager, numberOfObjectsToRespawn);
        }
    }
}