using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dsiemienik@gmail.com 21.07.2017
// Allows to rotate camera using TouchKit Pan gesture recognize
public class CameraRotator : MonoBehaviour {

    [SerializeField] private float rotationSpeed = 10f;

    TKPanRecognizer recognizer = new TKPanRecognizer();

    private Vector3 planePosition = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        TouchKit.addGestureRecognizer(recognizer);
        recognizer.gestureRecognizedEvent += (r) =>
        {
            Camera.main.transform.RotateAround(planePosition, Vector3.up, recognizer.deltaTranslation.x / rotationSpeed);
        };
    }
}
