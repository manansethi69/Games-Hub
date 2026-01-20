using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[RequireComponent(typeof(Rigidbody2D))]
public class piranha_movement : MonoBehaviour
{
    public Transform playerLocation;
    private Vector3 startPos = new Vector3(-12f, -4.75f, 0f);
    public Rigidbody2D piranhaRb;
    public float speed;
    [SerializeField] private healthcontrol health;
    private bool chasingPlayer;

    private Vector2 piranhaFirstJump;
    //private bool trackPlayer;

    // Start is called before the first frame update
    void Start()
    {   
        //trackPlayer = true;
        piranhaFirstJump = new Vector2(-3f, 3f);
        gameObject.transform.position = startPos;
        chasingPlayer = false;
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        piranhaRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector2 rotDirection;
        
        //sets the homing point here to make the piranha first go up and then to the player
        if(chasingPlayer) {
            rotDirection = (Vector2)playerLocation.position - piranhaRb.position;
        } else {
            rotDirection = piranhaFirstJump - piranhaRb.position;
        }

        if(gameObject.transform.position.y >= 3) {
            chasingPlayer = true;
        }
 
        //normalizes the length of the vector to 1
        rotDirection.Normalize();
        //gets the cross value to set rotation value for the piranha's homing
        float rotationValue = -Vector3.Cross(rotDirection, transform.right).z;

        //adjust the value here to control how intense the piranha's chase is
        if(chasingPlayer && transform.position.y  < 2) {
            piranhaRb.angularVelocity = 0;
        } else {
            piranhaRb.angularVelocity = rotationValue * 200f;
        }
        
        piranhaRb.velocity = transform.right * speed;

        if(gameObject.transform.position.y < -2.5){
            gameObject.GetComponent<Renderer>().enabled = false;
            if(chasingPlayer) {
                resetPosition();
            }

        } else {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    //respawns the piranha and flips the spawn location 
    public void resetPosition() {
        piranhaFirstJump.x = -piranhaFirstJump.x;
        startPos.x = -startPos.x;
        gameObject.transform.position = startPos;
        Vector3 piranhaScale = transform.localScale;
		piranhaScale.y *= -1;
		transform.localScale = piranhaScale;
        chasingPlayer = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {   
        if(col.gameObject.tag.Equals("Player")) {
            resetPosition();
            Damage();
        }
        
    }

      //damage script that eliminates the player when they lose hp and also decrements health when damaged
    public void Damage()
    {   
        Debug.Log("player is damaged");
        health.playerHealth = health.playerHealth - 1;
        health.UpdateHealth();
        health.levelChange("Level4");
    }
}
