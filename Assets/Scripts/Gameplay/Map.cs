using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com 09.07.2017
// Vector3 instead of Vector2
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
	public Vector3 GetRandomPoint()
	{
		return new Vector3(Random.Range(-mapLength / 2, mapLength / 2), 0f, Random.Range(-mapWidth / 2, mapWidth / 2));
	}

    //
	public Vector3 GetRandomPoint(Vector3 direction, Vector3 position)
    {
        if (direction.Equals(Vector3.zero))
        {
			return GetRandomPoint();
        }
        else
        {
			// TODO get a new point in the opposite direction
            return Vector3.zero;
        }
    }

    //
    public Vector3 GetRandomFreePoint()
    {
		Vector3 randomPoint;
        int freePointChecks = 0;
        do
        {
            freePointChecks++;
            if (freePointChecks == 200)
            {
                Debug.LogWarning("Can't find a free spot on the map! Returning Vector2.zero!");
                return Vector3.zero;
            }

			randomPoint = GetRandomPoint();
        } while (!IsTargetPointFree(randomPoint));

        return randomPoint;
    }
		
    //
    private bool IsTargetPointFree(Vector3 randomPoint)
    {
		Collider[] colliders = Physics.OverlapSphere(randomPoint, freePointCheckRadius);
        if (colliders.Length > 1)
            return false;
        else
            return true;
    }
}
