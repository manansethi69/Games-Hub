using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the script is for testing purposes but the settings functionality for the practise level is currently here. This issue is moved to the backLog
public class PlayerAnimationTesting : MonoBehaviour {
    public Animator animator;
    public Transform boss;
    public float moveSpeed = 5f;
    public Vector3 originalPosition;
    [SerializeField] public GameObject settings;

    void Start() {
        boss = GameObject.FindGameObjectWithTag("boss").transform;

        //transform is the current GameObeject the script is attached to by default.
        originalPosition = transform.position;
    }

    void Update() {
        //just for testing
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(MoveTowardsBoss());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settings.SetActive(true);
        }
    }

    //Separation of logic so that when a method is called another prograrmmer may want to implement a new feature such as a new attack animation or different damage values
    IEnumerator MoveTowardsBoss() {
        
        //move to the boss's position
        while (Vector3.Distance(transform.position, boss.position) > 1.0f) {
            transform.position = Vector2.MoveTowards(transform.position, boss.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            yield return null;
        }

        animator.SetBool("isMoving", false);

        //for future installation of attack animation for Gopit based on what is agreed upon by the team.
        // animator.SetTrigger("Attack");

        //for attack duration
        yield return new WaitForSeconds(1.5f);

        //move back
        transform.Rotate(0f, 180f, 0f);
        while(Vector3.Distance(transform.position, originalPosition) > 1.0f) {
            //when returning the hurt animation should not be playing due to delay from boss logic code
            animator.SetBool("Hurt", false);
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            yield return null;
        }
        transform.Rotate(0f, 180f, 0f);
        animator.SetBool("isMoving", false);
    }
}