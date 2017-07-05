using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
//
public class EnemyBehaviourController : MonoBehaviour
{
    public static EnemyBehaviourController Instance { get; private set; }

    [SerializeField]
    private Map map;

    //
    private void Awake()
    {
        Instance = this;
    }

    //
    public void PassRandomizePositionCommand(RandomizePosititonCommand cmd)
    {
		Vector2 newPoint = map.GetRandomPoint(cmd.collisionDirection, cmd.sender.transform.transform.position);

        if (cmd.collisionDirection == Vector3.zero)
        {
            // cmd.sender. moveTo(newPoint)
        }
        else
        {
			// cmd.sender. greet ()
			// cmd.sender. moveTo(newPoint)
        }
    }
}
