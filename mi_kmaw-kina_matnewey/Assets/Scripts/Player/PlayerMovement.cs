using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    private Rigidbody2D m_Rigidbody2D;
    private CircleCollider2D m_CrouchHeadTrigger;

    public float runSpeed = 40f;
    float deceleration = 3f;   // The variable to reduce the speed

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool ladder = false;
    public bool canMove = true;
    public bool canStand = true;
    bool isHurt = false;
    public bool isLadder = false;

    private float hurtAnimationDuration = 0.5f;
    


    //new
    bool isClimbing = false;


    public PlayerSoundSystem playerSoundSystem;
    public DynamicJoystick joystick;


    [SerializeField] public GameObject settings;

    private void Awake()
    {
        settings = GameObject.Find("Settings");

        if (settings == null)
        {
            Debug.LogError("PlayerMovement could NOT find Settings!");
        }

        joystick = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();

    }

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }





    public void OnJumpButtonPressed()
    {
        if (isLadder)
        {
            isClimbing = true;
            verticalMove = runSpeed;  // Climb up.
            jump = false;              // No jumping at all.
        }
        else
        {
            jump = true;                // Normal ground jump.
            if (controller.getGrounded())
            {
                playerSoundSystem.Jump();
            }
            animator.SetBool("IsJumping", true);
        }
    }



    public void OnCrouchButtonPressed()
    {
        if (isLadder)
        {
            isClimbing = true;
            verticalMove = -runSpeed; // Climb down.
        }
        else
        {
            crouch = true;
            playerSoundSystem.Crouch();
        }
    }


    public void OnCrouchButtonReleased()
    {
        if (isLadder)
        {
            verticalMove = 0; // Stop climbing.
        }
        else
        {
            crouch = false;
            playerSoundSystem.stopCrouch();
        }
    }






    // Update is called once per frame
    void Update()
    {

        float joystickInput = (joystick != null && !settings.activeSelf) ? joystick.Horizontal : 0f;
        float keyboardInput = Input.GetAxisRaw("Horizontal");

        // Always allow keyboard input, regardless of joystick state
        horizontalMove = (keyboardInput != 0 ? keyboardInput : joystickInput) * runSpeed;






        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        //new
        if (!isLadder && isClimbing)
        {
            isClimbing = false;
            verticalMove = 0;
        }




        if (!isLadder && canMove)
        {
            ladder = false;
            if (Input.GetButtonDown("Horizontal"))
            {
                playerSoundSystem.Walk();
            }
            else if (Input.GetButtonUp("Horizontal"))
            {
                playerSoundSystem.stopWalk();
            }

            if (Input.GetButtonDown("Jump") && isLadder == false)
            {
                jump = true;
                if (controller.getGrounded())
                {
                    playerSoundSystem.Jump();
                }

                animator.SetBool("IsJumping", true);
            }

            if (controller.getGrounded() && !Input.GetButtonDown("Jump"))
            {
                //if a player is on the ground before jump is pressed, allow the player to make a normal and jump and not double jump
                controller.setDoubleJump(false);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                playerSoundSystem.Crouch();
                crouch = true;
            }

            else if (Input.GetButtonUp("Crouch") && canStand)
            {
                playerSoundSystem.stopCrouch();
                crouch = false;
            }

            //If it collides with an enemy, the status changes to isHurt
            if (isHurt)
            {
                animator.SetBool("Hurt", true);   //Call Player_Hurt animation



                //Determine when the character's speed is reduced to 0.2f after being repelled
                Invoke("endHurtAnimation", hurtAnimationDuration);
            }

            // The settings is shown when you press escape
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }

        }

        else if (isLadder)
        {
            //verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

            float keyboardVertical = Input.GetAxisRaw("Vertical");

            if (keyboardVertical != 0)
            {
                verticalMove = keyboardVertical * runSpeed;
            }





            animator.SetFloat("Speed", Mathf.Abs(verticalMove));
            ladder = true;
            isHurt = false;
            animator.SetBool("Hurt", false);
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
        animator.SetBool("IsLaddering", isLaddering);
    }

    // This method is used in boss to enable player movement after boss is defeated
    public void SetCanMove(int boolVal)
    {
        if (boolVal == 1)
        {
            canMove = true;
        }
        else if (boolVal == 0)
        {
            canMove = false;
        }
    }

    void FixedUpdate()
    {
        // Move our character
        if (canMove)
        {
            if (!isHurt)
            {
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
        if (collision.gameObject.CompareTag("Wall"))
        {
            canStand = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canStand = true;
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
                playerSoundSystem.KillEnemy();
            }
            else
            {
                // If the person collides on the left side of the object
                if (transform.position.x < collision.gameObject.transform.position.x)
                {
                    playerSoundSystem.Damage();
                    // The character is forced to shift 10 to the left
                    m_Rigidbody2D.velocity = new Vector2(-10, m_Rigidbody2D.velocity.y);
                    isHurt = true;
                }
                // If the person collides on the right side of the object
                else if (transform.position.x > collision.gameObject.transform.position.x)
                {
                    playerSoundSystem.Damage();
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
        if (collision.gameObject.tag == "bouncePad")
        {
            if (transform.position.y >= collision.gameObject.transform.position.y + 0.5 && !jump)
            {
                jump = true;
                controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, ladder, verticalMove * Time.fixedDeltaTime);
                animator.SetBool("IsJumping", true);
                playerSoundSystem.Jump();
            }
        }
    }

    void endHurtAnimation(){
        animator.SetBool("Hurt", false);
        isHurt = false;
    }

    public void TogglePause()
    {
        settings.SetActive(!settings.activeSelf);
    }

}

