using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float moveDistance = 5f;
    public bool moveLeft;
    public Sprite img1;
    public Sprite img2;
    private SpriteRenderer sr;
    private Vector2 leftBound;
    private Vector2 rightBound;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        //sets the left bound to -moveDistance, and the right bound to +moveDistance
        leftBound = transform.position - new Vector3(moveDistance, 0f);
        rightBound = transform.position + new Vector3(moveDistance, 0f);

        //lets the enemy move in different directions on start
        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else
        {
            sr.flipX = true;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        FlipBug();
    }

    //checks if the enemy has hit the left or right boundary and moves in the opposite direction
    void FixedUpdate()
    {
        //check if the enemy has reached the left or right boundary
        if (transform.position.x <= leftBound.x)
        {
            ChangeDirection();
        }
        else if (transform.position.x >= rightBound.x)
        {
            ChangeDirection();
        }
    }

    //checks if the enemy is colliding with a tilemap, and if so moves in the other direction
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }

    /*changes the direction of the enemy
    *swaps the value of moveLeft, then moves the enemy based on what moveleft is
    *also flips the animation based on if its moving left or right
    */
    void ChangeDirection()
    {
        moveLeft = !moveLeft;
        rb.velocity = new Vector2(moveLeft ? -moveSpeed : moveSpeed, rb.velocity.y);
        sr.flipX = !moveLeft;
    }

    //flips the sprite for the enemy
    public void FlipBug()
    {
        sr.sprite = img1;
        StartCoroutine(Animate());
    }

    //animates the sprite
    IEnumerator Animate()
    {
        yield return new WaitForSeconds(0.175f);
        sr.sprite = img2;
        yield return new WaitForSeconds(0.175f);
        FlipBug();
    }
}
