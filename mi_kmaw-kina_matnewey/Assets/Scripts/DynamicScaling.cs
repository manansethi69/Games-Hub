using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicScaling : MonoBehaviour
{
    private float initialWidth;
    private float initialHeight;

    // Start is called before the first frame update
    void Start()
    {
        initialWidth = transform.localScale.x;
        initialHeight = transform.localScale.y;

        ScaleObject();
    }

    // Re-scale current object using transformation
    void ScaleObject()
    {
        float scaleFactor = 1.5f;
        float newWidth = initialWidth * scaleFactor;
        float newHeight = initialHeight * scaleFactor;

        transform.localScale = new Vector3(newWidth, newHeight, 1.0f);
    }
}
