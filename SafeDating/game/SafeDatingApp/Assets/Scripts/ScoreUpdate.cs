using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using TMPro;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
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
        var flowChartPoints = flowchart.GetIntegerVariable("Points");
        if (flowChartPoints < 0)
        {
            flowChartPoints = 0;
            flowchart.SetIntegerVariable("Points", flowChartPoints);
        }
        points = flowChartPoints;
        pointsText.SetText(points.ToString());
    }
}
