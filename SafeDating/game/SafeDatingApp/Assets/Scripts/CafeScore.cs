using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using TMPro;
using UnityEngine.UI;

public class CafeScore : MonoBehaviour
{
    public Flowchart flowchart;
    public int points;
  
    [SerializeField] public TMP_Text pointsText; // The TextMeshPro object to display
    [SerializeField] public TMP_Text cafepointsText;
   

    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if(SceneManager.GetActiveScene().name == "Cafe"){
          points = StaticPoints.valueToKeep;
          pointsText.SetText(StaticPoints.valueToKeep.ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {
        points = flowchart.GetIntegerVariable("Points");
        int cafepoints = points - StaticPoints.valueToKeep;
        int cpoints = flowchart.GetIntegerVariable("Cpoints");
        if(cpoints < 0){
            cafepoints = 0;
           pointsText.SetText(cpoints.ToString()); 
        }else{
        pointsText.SetText(cpoints.ToString());}
        
      
        
    }
}
