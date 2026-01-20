using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//random guy in comments of collect and count items video from coding in flow thanks bro
using TMPro;
public class enemyCollision : MonoBehaviour
{

    //ref to movement
    //public movementTest movement;

    //ref to game manager
    //public GameManager gameManager;

    //ref to item collector
    public coinCollector collector;

    //variable for lives
    public int lives = 3;

    //video and unity api coding thing
    //collect and count items coding in flow also random guy
    [SerializeField] private TextMeshProUGUI scoreUI;
    //coding in flow videos
    //colliding method
    void OnTrigger2DEnter(Collider2D collision){
        //if the object they collide with has enemy tag
        if(collision.gameObject.CompareTag("enemy")){
            Debug.Log("ow");
            lives--;
            if(lives < 1){
                //begin the die method
                Die();
            }
            //if not
            else{
                //lives decrease
                //ui called scoreUI text method is changed to update coins and health
                scoreUI.text = "Points: " + collector.score + " Health: " + lives;
            }            
        }
    }
    //brackeys 3d collision video
    void OnCollisionEnter2D(Collision2D collisionInfo){
        //if the object they collide with has enemy tag
        if(collisionInfo.transform.CompareTag("enemy")){
            //testing it with a debug
            Debug.Log("ow");
            lives--;
            //if lives are less than 1
            if(lives < 1){
                //begin the die method wait that sounds weird
                Die();
            }
            //else decrease lives and change the ui text
            else{
                scoreUI.text = "Points: " + collector.score + " Health: " + lives;
            }               
        }
    }
    //die method
    private void Die(){
        //change the scene to the active one and begin it aka restarting the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
