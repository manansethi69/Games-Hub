using UnityEngine;
using System.Collections;

public class playerpush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    public float pushForce = 50f; // Adjust the force according to your needs
    public float damping = 0.15f; // Adjust the damping factor

    GameObject box;
    Rigidbody2D boxRigidbody;

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable")
        {
            box = hit.collider.gameObject;
            boxRigidbody = box.GetComponent<Rigidbody2D>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Apply an initial force to start pushing the box
                boxRigidbody.AddForce(Vector2.right * transform.localScale.x * pushForce);
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                // Gradually reduce the velocity (simulate damping) when the key is released
                boxRigidbody.velocity *= damping;
            }
        }
    }
}
