using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Playermove2 : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    private Rigidbody2D m_Rigidbody2D;

    public float runSpeed = 40f;
    float deceleration = 3f;   // The variable to reduce the speed

    float horizontalMove = 0f;
    float verticalMove = 0f;

    bool jump = false;
    bool crouch = false;
    bool canMove = true;   // The variablt to control whether the character can move.
    bool isHurt = false;
    bool ladder = false;

    public bool isLadder = false;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (!isLadder && canMove)
        {
            ladder = false;
            if (Input.GetButtonDown("Jump") && isLadder == false)
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
                animator.SetBool("IsCrouching", true);
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
                animator.SetBool("IsCrouching", false);
            }

            //If it collides with an enemy, the status changes to isHurt
            if (isHurt)
            {
                animator.SetBool("Hurt", true);   //Call Player_Hurt animation

                //Determine when the character's speed is reduced to 0.2f after being repelled
                if (m_Rigidbody2D.velocity.sqrMagnitude < 0.2f)
                {
                    animator.SetBool("Hurt", false);  //Stop Call the Player_Hurt animation. Switch to call the Player_Idle animation.
                    isHurt = false;
                }
            }
        }

        else if (isLadder)
        {
            verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(verticalMove));
            ladder = true;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void OnLadder(bool isLaddering)
    {
        Debug.Log("fwafa");
        animator.SetBool("IsLaddering", isLaddering);
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            //If the status is no hurt
            if (!isHurt)
            {
                // Move our character
                controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, ladder, verticalMove * Time.fixedDeltaTime);
                jump = false;
            }

            //If the status is no hurt
            if (isHurt)
            {
                //When the character is knockbacked the enemy, slow the character down.
                m_Rigidbody2D.velocity = Vector2.Lerp(m_Rigidbody2D.velocity, Vector2.zero, deceleration * Time.deltaTime);
            }
        }
    }


    // Determine whether the character is in contact with the boss
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boss"))
        {
            canMove = false;

        }
    }

    //knockback the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the character collides with an object with the "Enemy" tag
        if (collision.gameObject.tag == "Enemy")
        {
            if (transform.position.y >= collision.gameObject.transform.position.y + 0.5)
            {
                Destroy(collision.gameObject);
                //m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpforce * Time.deltaTime);
                jump = true;
                controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, ladder, verticalMove * Time.fixedDeltaTime);
                animator.SetBool("IsJumping", true);
            }
            else
            {
                // If the person collides on the left side of the object
                if (transform.position.x < collision.gameObject.transform.position.x)
                {
                    // The character is forced to shift 10 to the left
                    m_Rigidbody2D.velocity = new Vector2(-10, m_Rigidbody2D.velocity.y);
                    isHurt = true;
                }
                // If the person collides on the right side of the object
                else if (transform.position.x > collision.gameObject.transform.position.x)
                {
                    // The character is forced to shift 10 to the right
                    m_Rigidbody2D.velocity = new Vector2(10, m_Rigidbody2D.velocity.y);
                    isHurt = true;
                }
            }
        }

        if (collision.gameObject.tag == "GroundEnemy")
        {
            // If the person collides on the left side of the object
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                // The character is forced to shift 10 to the left
                m_Rigidbody2D.velocity = new Vector2(-10, m_Rigidbody2D.velocity.y);
                isHurt = true;
            }
            // If the person collides on the right side of the object
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                // The character is forced to shift 10 to the right
                m_Rigidbody2D.velocity = new Vector2(10, m_Rigidbody2D.velocity.y);
                isHurt = true;
            }
        }
    }
}
