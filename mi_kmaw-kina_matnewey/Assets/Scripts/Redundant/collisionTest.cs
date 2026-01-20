using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    public colourToCatch panel;
    
     void OnTriggerEnter2D(Collider2D col)
    {
        // Check for fish tag
        if (col.gameObject.tag == "Fish")
        {
            
            if (col.GetComponent<colourChange>().getColour() == panel.GetComponent<colourToCatch>().returnColourToMatch()){
            panel.setTextColour();
            }
            
        }
    }
     
}
