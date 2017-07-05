using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Creates a plane for the level's ground and holds methods that return a random or a random free point from it
public class Map : MonoBehaviour
{
    [SerializeField]
    private float mapLength;
    [SerializeField]
    private float mapWidth;
    [SerializeField]
    private float freePointCheckRadius;

    //
    void Awake()
    {
        GameObject createdMap = GameObject.CreatePrimitive(PrimitiveType.Plane); 
        createdMap.transform.localScale = new Vector3(mapLength / 10, 1f, mapWidth / 10);
    }

	//
	public Vector2 GetRandomPoint()
	{
		return new Vector2(Random.Range(-mapLength / 2, mapLength / 2), Random.Range(-mapWidth / 2, mapWidth / 2));
	}

    //
	public Vector2 GetRandomPoint(Vector3 direction, Vector3 currPosition)
    {
        if (direction.Equals(Vector3.zero))
        {
			return GetRandomPoint();
        }
        else
        {
			// TODO get a new point in the opposite direction
            return Vector2.zero;
        }
    }

    //
    public Vector2 GetRandomFreePoint()
    {
		Vector2 randomPoint;
        int freePointChecks = 0;
        do
        {
            freePointChecks++;
            if (freePointChecks == 200)
            {
                Debug.LogWarning("Can't find a free spot on the map! Returning Vector2.zero!");
                return Vector2.zero;
            }

			randomPoint = GetRandomPoint();
        } while (!IsTargetPointFree(randomPoint));

        return randomPoint;
    }
		
    //
    private bool IsTargetPointFree(Vector2 randomPoint)
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(randomPoint.x, 0f, randomPoint.y), freePointCheckRadius);
        if (colliders.Length > 1)
            return false;
        else
            return true;
    }
}
