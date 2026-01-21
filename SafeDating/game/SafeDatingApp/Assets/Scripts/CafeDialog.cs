using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CafeDialog : MonoBehaviour

{
    private Flowchart flowchart;
    
    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    void Update()
    {
        if(!flowchart.HasExecutingBlocks() && !flowchart.GetBooleanVariable("questionsResolved"))
                flowchart.ExecuteBlock("Question1");  
    }
}
