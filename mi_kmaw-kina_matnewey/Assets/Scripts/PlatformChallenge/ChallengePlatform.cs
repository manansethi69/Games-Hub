using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengePlatform : MonoBehaviour
{

    public ChallengePlatformImage image; 
    public string assignedWord;
    public bool isCorrect;
    public Sprite assignedImage;
    [SerializeField] private healthcontrol health; 
    public string sceneAfterDone;

    public int count;
    // Start is called before the first frame update
    void Start()
    {   
        health = GameObject.Find("healthasset").GetComponent<healthcontrol>();
        image.img.sprite = assignedImage;
        //scene to load after the bonus level is over
        sceneAfterDone = GameObject.Find("Platforms").GetComponent<levelInfo>().levelName;

    }


    void OnCollisionEnter2D(Collision2D colObj)
    {   

        //if the player touches the wrong word tile, player is damage
        if(!isCorrect && colObj.gameObject.tag.Equals("Player")) {
            //<-- below if the commented out code for teleporting the player to the bottom -->
            // Debug.Log("Collision");
            // Vector3 teleportPos = GameObject.FindGameObjectWithTag("frontDoorBonusHouse").transform.position;
            // teleportPos.x -= 13f;
            // colObj.gameObject.transform.position = (teleportPos);

            Damage();
        }
    }

    //damage script that exits the bonus level when when they have 0 hp and also decrements health when damaged
    public void Damage()
    {   
        Debug.Log("player is damaged");
        health.playerHealth = health.playerHealth - 1;
        health.UpdateHealth();
        if(health.playerHealth <= 0) {
            SceneManager.LoadScene(sceneAfterDone);
        }
    }


}
