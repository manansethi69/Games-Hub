using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChange : MonoBehaviour
{
    //get the fish object and it's renderer
    [SerializeField] public GameObject fish;
    [SerializeField] public string colourOfFish;
    public Renderer rend;

    //initialize all colours
    private Color pink = new Color(1.0f, 0.4f, 0.6f);
    private Color blue = new Color(0.6f, 0.6f, 1.0f);
    private Color red = new Color(1.0f, 0.1f, 0.2f);
    private Color green = new Color(0.3f, 1.0f, 0.2f);
    private Color orange = new Color(1.0f, 0.6f, 0.3f);
    private Color yellow = new Color(1.0f, 0.9f, 0.2f);
    private Color brown = new Color(0.6f, 0.3f, 0.1f);
    
    // Start is called before the first frame update
    void Start()
    {
        rend = fish.GetComponent<Renderer>();
    }

    public void SetColour(string colour){
        switch(colour){
            case "Pink":
            rend.material.SetColor("_main_color", pink);
            colourOfFish = colour;
            break;
             case "Blue":
            rend.material.SetColor("_main_color", blue);
            colourOfFish = colour;
            break;
             case "Red":
            rend.material.SetColor("_main_color", red);
            colourOfFish = colour;
            break;
             case "Green":
            rend.material.SetColor("_main_color", green);
            colourOfFish = colour;
            break;
             case "Orange":
            rend.material.SetColor("_main_color", orange);
            colourOfFish = colour;
            break;
             case "Yellow":
            rend.material.SetColor("_main_color", yellow);
            colourOfFish = colour;
            break;
             case "Brown":
             rend.material.SetColor("_main_color", brown);
            colourOfFish = colour;
            break;
        }
    }
    public string getColour(){
        return colourOfFish;
    }
}
