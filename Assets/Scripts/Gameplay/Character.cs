using UnityEngine;

public abstract class Character : ScriptableObject
{
    protected abstract int Level { get; set; }
    public abstract int FullHP { get; set; }
}