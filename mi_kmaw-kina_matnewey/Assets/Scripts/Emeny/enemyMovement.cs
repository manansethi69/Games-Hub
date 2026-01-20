using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyMovement : MonoBehaviour
{
    //refer to rigidbody and the float 
    public Rigidbody2D rb;
    float horizontalMovement = 2f;
    public GameObject bug;
    public Sprite img1;
    public Sprite img2;
    public SpriteRenderer sr;
    public bool track; 
    
    //floats to assign which will be used later
    public float A1 = 1;
    public float A2 = 10;
    float dir = 1f;

    //idea from alexander zotovs video enemy walks from 1 wall to another
    //also unity video from coin collecting video
    private void OnTriggerEnter2D(Collider2D collision){
        //if what is colliding has the tag coins
        if(collision.gameObject.CompareTag("hiddenWall")){
            float a1 = A1+10;
            float a2 = A2 - 4f;
            //Debug.Log("Bounce");
            dir = dir * -1f;
            move(a1, a2, dir);
            sr.flipX = !track;
            track = !track;

        }
    }    
    // Start is called before the first frame update
    void Start()
    {
        track = true;
        sr = gameObject.GetComponent<SpriteRenderer>();
        FlipBug();
    }

    // Update is called once per frame
    void Update()
    {
        //2 positions to make them more
        float a1 = A1+10;
        float a2 = A2 - 4f;
        
        //move method that gets the target location and direction
        move(a1, a2, dir);
        

    }
    //idea from alexander zotovs video enemy walks from 1 wall to another
    //no return method that is public and moves
    public void move(float a1, float a2, float dir){
        //moves by direction times the speed and all that
        rb.velocity = new Vector2(dir * horizontalMovement, rb.velocity.y);
    }
    public void FlipBug(){
        sr.sprite = img1;
        StartCoroutine(Animate());
    }
    IEnumerator Animate(){
        yield return new WaitForSeconds(0.175f);
        sr.sprite = img2;
        yield return new WaitForSeconds(0.175f);
        FlipBug();
    }
}
