using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D Coll;
    private Animator Anim;

    public Transform Leftpoint, Rightpoint;

    public float Speed;

    private float leftx, rightx;

    private bool Faceright= true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Coll = GetComponent<Collider2D>();
        Anim = GetComponent<Animator>();
        Anim.Play("Fox_idle", -1, 0f);

        leftx = Leftpoint.position.x;
        rightx = Rightpoint.position.x;
        Destroy(Leftpoint.gameObject);
        Destroy(Rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Faceright)
        {
            rb.velocity = new Vector2(Speed,rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                Faceright = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                Faceright = true;
            }
        }
    }
}
