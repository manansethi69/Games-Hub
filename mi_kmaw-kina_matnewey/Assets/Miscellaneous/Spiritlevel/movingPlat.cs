using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 0.5f;

    int direction = 1;

    private void Update() {
        Vector2 target = getTarget();
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Mathf.Sin(Time.deltaTime));
        float distance = (target - (Vector2)transform.position).magnitude;
        if (distance <= 0.1f) { direction *= -1; }
    }

    private Vector2 getTarget() {
        // returns whichever point the platform should move to next
        // 1 = start, -1 = end
        if (direction == 1) { return start.position; } 
        return end.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // sets the player to be a child of the platform so they stay on the platform
        if (collision.gameObject.tag == "Player") {
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        // sets player's parent to null so they fall off the platform
        if (collision.gameObject.tag == "Player") {
            collision.transform.parent = null;
        }
    }
}
