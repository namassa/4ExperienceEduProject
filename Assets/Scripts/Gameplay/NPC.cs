using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] public int Health;
    [SerializeField] public int Damage;
    [SerializeField] protected float Speed;
    protected bool Collision;
}