using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Move")]
public class Move : ScriptableObject
{
    public bool isMoving;

    public IEnumerator Moving(GameObject gameObject, Vector3 direction, float movementSpeed)
    {
        while (gameObject.transform.position != direction)
        {
            isMoving = true;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direction, movementSpeed * Time.deltaTime);
            yield return null;
        }
        if (gameObject.transform.position == direction)
        {
            isMoving = false;
        }
    }
}