using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithCamera : MonoBehaviour
{
    [SerializeField] Camera mainCamera; // Assign your camera in the Inspector

    void Start() {
        if (mainCamera.orthographic) {
            // Scale based on the camera's size
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float objectHeight = GetComponent<SpriteRenderer>().bounds.size.y;
            
            // Adjust the scale based on camera height
            float scaleFactor = cameraHeight / objectHeight;
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
        }
    }
}
