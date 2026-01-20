using System;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[SerializeField] private float m_DoubleJumpForce = 400f;					// Amount of force added for the player's second jump.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private BoxCollider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching
	[SerializeField] private CircleCollider2D m_CrouchEnableCollider;			// A collider that will be enabled when crouching


	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
    public BoolEvent OnLadderingEvent;
    private bool m_wasCrouching = false;
    private bool m_wasLadding = false;
	private bool canDoubleJump;
	public bool allowDoubleJump;	//boolean to set in inspector to allow for double jump functionality
	
	
	private void Awake()
	{
		m_CrouchEnableCollider.enabled = false;

		//if double jump is turned off, set it's force value to 0
		if(!allowDoubleJump) {
			m_DoubleJumpForce = 0;
		}

		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();

        if (OnLadderingEvent == null)
            OnLadderingEvent = new BoolEvent();
    }

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			// Check if the collider is not a trigger and is not the player's own collider
			if (colliders[i].gameObject != gameObject && !colliders[i].isTrigger)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float horizontalMove, bool crouch, bool jump, bool ladder, float verticalMovement)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

                // Reduce the speed by the crouchSpeed multiplier
                horizontalMove *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
					m_CrouchEnableCollider.enabled = true;
			} else
			{
				// Ceiling check
				
				RaycastHit2D hit = Physics2D.Raycast(m_CeilingCheck.position, Vector2.up, k_CeilingRadius, m_WhatIsGround);

				bool ceilingCheck = hit.collider != null && !hit.collider.isTrigger;
				
                if (ceilingCheck)
                {
	                Debug.Log("ceiling");
					// Ceiling found
					m_wasCrouching = true;
					horizontalMove *= m_CrouchSpeed;
					OnCrouchEvent.Invoke(true);

				}
				else {
					// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
					m_CrouchEnableCollider.enabled = false;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
				}
				
			}
			m_Rigidbody2D.gravityScale = 3;
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(horizontalMove * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (horizontalMove > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (horizontalMove < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}


		// If the player should jump...
		if ((m_Grounded || canDoubleJump) && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			if(canDoubleJump) {
				m_Rigidbody2D.AddForce(new Vector2(0f, m_DoubleJumpForce));
			}else {
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}
			
			//if a double jump is perform, do not allow another jump right after
			canDoubleJump = !canDoubleJump;
		}

	

		if (ladder)
		{
            if (!m_wasLadding)
            {
                m_wasLadding = true;
                OnLadderingEvent.Invoke(true);
            }
            m_Rigidbody2D.gravityScale = 1;
            Vector2 velocity = m_Rigidbody2D.velocity;
            velocity.y = verticalMovement * 10f;
            velocity.x = horizontalMove * 10f;
            m_Rigidbody2D.velocity = velocity;
        }
		else
		{
            if (m_wasLadding)
            {
                m_wasLadding = false;
                OnLadderingEvent.Invoke(false);
            }
        }
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public bool getGrounded(){
		return m_Grounded;
	}

	//setter for playerMovement script
	public void setDoubleJump(Boolean doubleJump) {
		canDoubleJump = doubleJump;
	}

	public void allowPlayerDoubleJump() {
		allowDoubleJump = true;
		m_DoubleJumpForce = 400f;
	}
}
