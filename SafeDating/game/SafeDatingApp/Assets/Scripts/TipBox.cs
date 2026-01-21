using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TipBox : MonoBehaviour
{

    public TMPro.TextMeshProUGUI instructionsText;
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        //instructionsText.text = "Your mission: You will come across 6 objects. ";


    }



    // Update is called once per frame
    void Update()
    {
        // Check for user movement input (e.g., using the arrow keys or WASD)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // If the user moves in any direction, destroy the game object
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            thing.SetActive(false);
        }
    }

    public void OnPress(InputAction.CallbackContext value){
        if (thing.activeInHierarchy) { 
            thing.SetActive(false); 
        }
        
    }
}
