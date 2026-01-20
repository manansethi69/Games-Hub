using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;


public class colourToCatch : MonoBehaviour
{
    [SerializeField] private string[] coloursEnglish =  {"Red", "Pink", "Blue", "Yellow", "Orange", "Green", "Brown"};
    [SerializeField] private string[] colours =  {"Mekwe’k", "Nijinjewamu’k", "Musqunamu’k", "Wataptek", "Nikjawiknejewamu’k", "Stoqnamu’k", "Tupkwanamu’k"};
    private string[] pickedColours = {"Mekwe’k", "Nijinjewamu’k", "Musqunamu’k", "Wataptek", "Nikjawiknejewamu’k", "Stoqnamu’k", "Tupkwanamu’k"};
    private Color pink = new Color(1.0f, 0.4f, 0.6f);
    private Color blue = new Color(0.6f, 0.6f, 1.0f);
    private Color red = new Color(1.0f, 0.1f, 0.2f);
    private Color green = new Color(0.3f, 1.0f, 0.2f);
    private Color orange = new Color(1.0f, 0.6f, 0.3f);
    private Color yellow = new Color(1.0f, 0.9f, 0.2f);
    private Color brown = new Color(0.6f, 0.3f, 0.1f);
    [SerializeField] public GameObject fish1;
    [SerializeField] public GameObject fish2;
    [SerializeField] public GameObject panel;
    private int count = 0;

    public TMP_Text colourText;
    [SerializeField] public TextMeshProUGUI colourOfString;

    private string colour;
    private string colourToMatch;


    // Start is called before the first frame update
    void Start()
    {
        setTextColour();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTextColour(){
        int index;

        
        while (true){
        index = Random.Range(0,7);
        colour = colours[index];
        colourToMatch = coloursEnglish[index];
        colourText.text = colour;
        if(pickedColours[index] != coloursEnglish[index]){
            count++;
            break;
        }
        else if(count > 6){
            Destroy(fish1);
            Destroy(fish2);
            Destroy(panel);
            break;
        }
        }
        switch(colourToMatch){
            case "Pink":
            colourOfString.color = pink;
            break;
             case "Blue":
            colourOfString.color = blue;
            break;
             case "Red":
            colourOfString.color = red;
            break;
             case "Green":
            colourOfString.color = green;
            break;
             case "Orange":
            colourOfString.color = orange;
            break;
             case "Yellow":
            colourOfString.color = yellow;
            break;
             case "Brown":
             colourOfString.color = brown;
            break;
    }
    pickedColours[index] = colourToMatch;

    
}

    public string returnColourToMatch() {
        return colourToMatch;
    }

    public string returnColourToCatch() {
        return colour;
    }
    
 }
