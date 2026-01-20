using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class boatMovement_noController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;

    public float moveSpeed = 0.1f;
    public float maxSpeed = 20f;
    public float deceleration = 0.1f;
    float horizontalMove = 0f;
    private bool m_FacingRight = true;
    public int coins;
    public GameObject coinUI;
    private boatMovement_noController player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        PlayerPrefs.GetInt("PortalActive", 1);
        PlayerPrefs.SetInt("PortalActive", 1);
        if(MainManager.Instance != null) {
            coins = MainManager.Instance.coinInventory;
        } else {
            coins = 0;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<boatMovement_noController>();
    }

    void Update()
    {   
        coinUI.GetComponent<TextMeshProUGUI>().text = "Coins: " + player.getCoinCount();

        if (Input.GetAxisRaw("Horizontal") != 0) {
            horizontalMove += Input.GetAxisRaw("Horizontal") * moveSpeed;
            horizontalMove = Mathf.Clamp(horizontalMove, -maxSpeed, maxSpeed);
        } else {
            horizontalMove -= horizontalMove * deceleration;
        }
        if (horizontalMove < 0 && m_FacingRight) {
            Flip();
        } else if (horizontalMove > 0 && !m_FacingRight) {
            Flip();
        }

        //this stops the player from going outside the screen's boundaries.
        if (transform.position.x <= -6.5f) {
	        transform.position = new Vector2(-6.5f, transform.position.y);
        } else if (transform.position.x >= 6.5f) {
	        transform.position = new Vector2(6.5f, transform.position.y);
        }

        if(MainManager.Instance != null) {
            MainManager.Instance.coinInventory = player.getCoinCount();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy")) {
            if(player.getCoinCount() == 1) {
                player.incrementPlayerCoins(-player.getCoinCount());
            } else {
                player.incrementPlayerCoins(-Mathf.RoundToInt(player.getCoinCount()/2));
            }
            player.GetComponentInParent<PlayerSoundSystem>().Damage();
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

    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(horizontalMove * Time.fixedDeltaTime, 0, 0);
    }

    public void incrementPlayerCoins(int coinsToAdjust){
        coins += coinsToAdjust;
    }

    public int getCoinCount() {
        return coins;
    }
 }
