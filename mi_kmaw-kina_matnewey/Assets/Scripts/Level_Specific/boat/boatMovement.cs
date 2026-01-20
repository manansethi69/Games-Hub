using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMovement : MonoBehaviour {
    public CharacterController2D controller;
    public Animator animator;
    private Rigidbody2D m_Rigidbody2D;

    public float moveSpeed = 40f;
    float deceleration = 3f;
    bool isHurt = false;
    public bool canMove = true;

    float horizontalMove = 0f;

    public PlayerSoundSystem playerSoundSystem;
    // Start is called before the first frame update
    void Start() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //If it collides with an enemy, the status changes to isHurt
        if (isHurt) {
            animator.SetBool("Hurt", true);   //Call Player_Hurt animation

            //Determine when the character's speed is reduced to 0.2f after being repelled
            if (m_Rigidbody2D.velocity.sqrMagnitude < 0.2f) {
                animator.SetBool("Hurt", false);  //Stop Call the Player_Hurt animation. Switch to call the Player_Idle animation.
                isHurt = false;
            }
        }
    }

    void FixedUpdate () {
        // Move our character
        if (!isHurt) {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, false, false, 0);
        }

        //If the status is no hurt
        if (isHurt) {
            //When the character is knockbacked the enemy, slow the character down.
            m_Rigidbody2D.velocity = Vector2.Lerp(m_Rigidbody2D.velocity, Vector2.zero, deceleration * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // If the character collides with an object with the "Enemy" tag
        if (collision.gameObject.tag == "Enemy") {
            // If the person collides on the left side of the object
            if (transform.position.x < collision.gameObject.transform.position.x) {
                playerSoundSystem.Damage();
                // The character is forced to shift 10 to the left
                m_Rigidbody2D.velocity = new Vector2(-10, m_Rigidbody2D.velocity.y);
                isHurt = true;
            }
            // If the person collides on the right side of the object
            else if (transform.position.x > collision.gameObject.transform.position.x) {
                playerSoundSystem.Damage();
                // The character is forced to shift 10 to the right
                m_Rigidbody2D.velocity = new Vector2(10, m_Rigidbody2D.velocity.y);
                isHurt = true;
            }
        }
    }
}
