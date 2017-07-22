using UnityEngine;

[CreateAssetMenu(fileName = "Orc")]
public class Orc : Character
{
    [SerializeField] int level;
    protected override int Level
    {
        get { return level; }
        set { level = value; }
    }

    [SerializeField] public int fullHP;
    public override int FullHP
    {
        get { return fullHP; }
        set { fullHP = value; }
    }
}