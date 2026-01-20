using UnityEngine;

public class idlePulsatingEffect : MonoBehaviour
{
    private Vector3 currentScale;
    private float minScale;
    private float maxScale;
    public float speed = 2f;
    private float targetScale;
    private float direction = 1f;

    void Start()
    {
        currentScale = transform.localScale;
        float scaleX = currentScale.x;
        minScale = scaleX - 0.1f;
        maxScale = scaleX + 0.1f;
        targetScale = maxScale;
    }

    void Update()
    {
        // Rescale
        float scale = Mathf.Lerp(transform.localScale.x, targetScale, Time.deltaTime * speed);
        transform.localScale = new Vector3(scale, scale, scale);

        // Check if the scale is within the threshold of the target scale
        if ((direction == 1f && Mathf.Abs(scale - maxScale) < 0.05f) ||
            (direction == -1f && Mathf.Abs(scale - minScale) < 0.05f))
        {
            // Reverse the direction
            direction *= -1f;
            targetScale = direction > 0 ? maxScale : minScale;
        }
    }
}