using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Behaviour", order = 1)]
public class Move : ScriptableObject {

    public IEnumerator Moving(MoveRandomly moveRandomly, GameObject gameObject, Vector3 direction, float movementSpeed, bool collision)
    {        
        while (gameObject.transform.position != direction)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direction, movementSpeed * Time.deltaTime);
            yield return null;
        }

        moveRandomly.MoveRandomlyTo(gameObject, direction, movementSpeed, collision);
    }
}