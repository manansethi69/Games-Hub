using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimingScript : MonoBehaviour
{   
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject hookLine;
    public Transform hookLineTransform;
    public Boolean canFire;
    private float timer;
    public float timeBetweenFiring;
    public colourToCatch panelToAttach;
    [SerializeField] private healthcontrol healthController; 



    // Start is called before the first frame update
    void Start()
    {   
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {   
        //get mouse position of user
        mousePos = mainCam.WorldToScreenPoint(Input.mousePosition);
        // set the rotation of the projectile to the direction of the mouse pointer
        Vector3 rotation = mousePos - transform.position;
        float rotZ = MathF.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //boolean value to dictate the interval in time between each of the player's shots
        if(!canFire) {
            timer += Time.deltaTime;
            if(timer >= timeBetweenFiring) {
                //set can fire back to true and time back to 0
                canFire = true;
                timer = 0;
            }
        }

        //checks mouse input and can fire to dictate frequency of shots
        if(Input.GetMouseButton(0) && canFire) {
            canFire = false;
            // set the correct color for the projectile to check when the projectile collides
            hookLine.GetComponent<hookLineScript>().setColour(panelToAttach);
            // the health controller so the health at the top can be decremented
            hookLine.GetComponent<hookLineScript>().attachHealth(healthController);
            hookLine.GetComponent<boatLevelCoinManager>().attachPanel(panelToAttach);
            hookLine.GetComponent<boatLevelCoinManager>().attachHealth(healthController);
            //instantiates the projectile
            GameObject o = Instantiate(hookLine, hookLineTransform.position, Quaternion.identity);
        }
    }


    
}
