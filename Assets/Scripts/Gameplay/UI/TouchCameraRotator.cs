using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Uses TouchKit to allow rotating the camera's parent object
public class TouchCameraRotator : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraRotator;
    [SerializeField]
    [Range(1f, 100f)]
    private float rotationSpeed;

    //
    void Awake()
    {
        rotationSpeed = 50f;

        var recognizer = new TKPanRecognizer();

        recognizer.gestureRecognizedEvent += (r) =>
        {
            cameraRotator.transform.Rotate(new Vector3(0, recognizer.deltaTranslation.x * (rotationSpeed / 100f), 0));
        };

        TouchKit.addGestureRecognizer(recognizer);
    }
}
