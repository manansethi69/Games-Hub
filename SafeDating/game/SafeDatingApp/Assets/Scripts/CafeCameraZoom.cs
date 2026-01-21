using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeCameraZoom : MonoBehaviour
{
    public Camera targetCamera;
    public float zoomSpeed = 2.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 60.0f;
    public static bool isSitting;
    public bool setCamera = false;

    void Start()
    {
        targetCamera.fieldOfView = 60.0f; // Set an appropriate initial FOV
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            float newFOV = targetCamera.fieldOfView - scroll * zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, minZoom, maxZoom);
            targetCamera.fieldOfView = newFOV;
        }

        if(isSitting)
        {
            
            if (!setCamera)
            {
                maxZoom = 100.0f;
                targetCamera.fieldOfView = 100.0f;
                setCamera = true;
            }
            
        }
    }

    public static void UpdateSitting(bool sitting)
    {
        isSitting = sitting;
    }
}
