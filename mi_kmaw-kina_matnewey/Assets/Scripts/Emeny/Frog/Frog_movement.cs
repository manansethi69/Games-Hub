using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator Anim;
    private Collider2D Coll;

    public Transform Leftpoint, Rightpoint;

    public float Speed, JumpForce;

    private float leftx, rightx;

    private bool Faceleft = true;

    public LayerMask Ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Coll = GetComponent<Collider2D>();
        
        leftx = Leftpoint.position.x;
        rightx = Rightpoint.position.x;
        Destroy(Leftpoint.gameObject);
        Destroy(Rightpoint.gameObject);
        Anim.speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }



    void Movement()
    {
        if (Faceleft)
        {
            if (Coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jump", true);
                rb.velocity = new Vector2(-Speed, JumpForce);
                if (transform.position.x < leftx)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    Faceleft = false;
                }
            }
        }
        else
        {
            if (Coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jump", true);
                rb.velocity = new Vector2(Speed, JumpForce);
                if (transform.position.x > rightx)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    Faceleft = true;
                }
            }
        }
    }

    void SwitchAnim()
    {
        if (Anim.GetBool("jump"))
        {
            if(rb.velocity.y < 0.1)
            {
                Anim.SetBool("jump", false);
                Anim.SetBool("fall", true);
            }
        }

        if (Coll.IsTouchingLayers(Ground) && Anim.GetBool("fall"))
        {
            Anim.SetBool("fall",false);
        }
    }
}
