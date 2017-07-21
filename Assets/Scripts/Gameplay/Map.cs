using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com 09.07.2017
// Vector3 instead of Vector2, GetRandomPoint(Vector3 direction, Vector3 position) implementation added, Bounds instead width and length
// jarekdc@gmail.com 20.07.2017
// Creates a map and can randomly populate it with chosen objects
public class Map : MonoBehaviour
{
    [SerializeField]
	private Bounds bounds;
    [SerializeField]
    private float freePointCheckRadius;
    [Header("Objects to Spawn")]
    public SpawnElements[] objectsToSpawn;

    [System.Serializable]
    public class SpawnElements
    {
        public GameObject elementToSpawn;
        public int numberOfObjects;
    }
    
    //
    void Awake()
    {
        GameObject createdMap = GameObject.CreatePrimitive(PrimitiveType.Plane); 
		createdMap.transform.position = bounds.center;
		createdMap.transform.localScale = new Vector3(bounds.extents.z*2f / 10, 1f, bounds.extents.x*2f / 10);

        foreach(SpawnElements obj in objectsToSpawn)
        {
            for(int i = 0; i < obj.numberOfObjects; i++)
            {
                Vector3 randomPosition = GetRandomFreePoint(2f);
                Vector3 spawnPosition = new Vector3(randomPosition.x, 
                    obj.elementToSpawn.GetComponent<MeshFilter>().sharedMesh.bounds.extents.y * obj.elementToSpawn.transform.localScale.y, 
                    randomPosition.z);

                Instantiate(obj.elementToSpawn, spawnPosition, Quaternion.Euler(0f, Random.Range(0f, 359f), 0f));
            }
        }
    }

	//
	public Vector3 GetRandomPoint(float borderMargin = 0f)
	{
		return new Vector3(Random.Range(-bounds.extents.z + borderMargin, bounds.extents.z - borderMargin) + bounds.center.z, 
            0f, Random.Range(-bounds.extents.x + borderMargin, bounds.extents.x - borderMargin) + bounds.center.x);
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
			direction.y = 0f;
			direction = Quaternion.Euler(0f, Random.Range(-15f, 15f), 0f) * direction;
			Ray ray = new Ray (position, -direction);

			float distance;
			if (bounds.IntersectRay (ray, out distance)) 
			{
				ray.direction *= -1f;
				return ray.GetPoint (Random.Range (0f, -distance));
			}
			return Vector3.zero;

        }
    }

    //
    public Vector3 GetRandomFreePoint(float borderMargin = 0f)
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

			randomPoint = GetRandomPoint(borderMargin);
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

	//
	#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube (bounds.center, bounds.extents * 2f);
	}
	#endif


}
