using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss1AnimationTesting : MonoBehaviour {
    public Animator animator;
    public Animator playerAnimator;
    public Transform player;
    public float moveSpeed = 5f;
    //stores the starting position for the boss so that it can return to it
    public Vector3 originalPosition;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //transform is the current GameObeject the script is attached to by default.
        originalPosition = transform.position;
    }

    void Update() {
        //just for testing
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(MoveTowardsPlayer());
        }
    }

    //Separation of logic so that when a method is called another prograrmmer may want to implement a new feature such as a new attack animation or different damage values
    IEnumerator MoveTowardsPlayer() {
        //moves to the players position
        while (Vector3.Distance(transform.position, player.position) > 1.0f) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            yield return null;
        }
        animator.SetBool("isMoving", false);

        //attacks
        animator.SetTrigger("Attack");

        //give time for attack to start and then display the player hurt animation
        yield return new WaitForSeconds(0.8f);

        //for player hurt animation
        playerAnimator.SetBool("Hurt", true);

        //for attack duration
        yield return new WaitForSeconds(1.5f);

        playerAnimator.SetBool("Hurt", false);

        transform.Rotate(0f, 180f, 0f);
        //move back to original position
        while(Vector3.Distance(transform.position, originalPosition) > 1.0f) {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            yield return null;
        }
        transform.Rotate(0f, 180f, 0f);
        animator.SetBool("isMoving", false);
    }
}
