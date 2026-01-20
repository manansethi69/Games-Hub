using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_movement : MonoBehaviour
{
    [SerializeField] private GameObject fish;
    private Vector3 startPos = new Vector3(10f, -6f, 0);
    private Vector2 launchForce = new Vector2(-5.25f, 8.38f);
    private int colourCheckCount = 0;
    [SerializeField] private colourToCatch match;

    [SerializeField] private colourChange colourChange;
    [SerializeField] private string[] colours =  {"Red", "Pink", "Blue", "Yellow", "Orange", "Green", "Brown"};
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        if(fish.transform.position.y > -7 && fish.transform.position.y < -5){
        colourChange.SetColour(pickColour());
        fish.GetComponent<Rigidbody2D>().velocity = launchForce;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        
        //moving fish and placing it back at spawn point
        if(fish.transform.position.y < -10){
            fish.transform.position = startPos;
            fish.GetComponent<Rigidbody2D>().velocity = launchForce;
            string colour = pickColour();
            colourChange.SetColour(colour);
            colourCheckCount++;
        }
        if(fish.transform.position.y < -2.5){
            fish.GetComponent<Renderer>().enabled = false;
        }
        else{
            fish.GetComponent<Renderer>().enabled = true;
        }
        if(colourCheckCount > 5){
            colourCheckCount = 0;
            colourChange.SetColour(match.returnColourToMatch());
        }
        
        
        // rotate fish by changing value of rotation
        if(fish.transform.position.y > 3.15){
            fish.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
        }
        else if(fish.transform.position.x < -0.25 ){
            fish.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,50f));
        }
        else{
            fish.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,-50f));
        }
    }

    private string pickColour(){
        return colours[Random.Range(0,7)];
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("hookLine")) {
            fish.transform.position = startPos;
        }
    }
}
