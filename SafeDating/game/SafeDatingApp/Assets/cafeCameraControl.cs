using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;
    public float zoomSpeed = 2.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 20.0f;

    void Update()
    {
        // Check if the mouse scroll wheel is moved
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            // Calculate the new zoom level
            float newZoom = mainCamera.orthographicSize - scroll * zoomSpeed;

            // Clamp the zoom level within the specified range
            newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

            // Update the camera's orthographic size
            mainCamera.orthographicSize = newZoom;
        }
    }
}
