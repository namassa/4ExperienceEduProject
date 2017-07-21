using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    [SerializeField] protected Character character;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    protected Vector3 direction;
    protected bool collision;
}