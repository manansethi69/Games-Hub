using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCControl : MonoBehaviour
{
    public string ChatName;

    private int ExecutingModuleCount;
    
    private bool canChat = false; 
    
    private bool answered = false;

    private Flowchart flowChart;

    void Start(){
        flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && ExecutingModuleCount == 0)
            canChat = true; 
            Say(); 
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Player" && ExecutingModuleCount == 0)
            canChat = false; 
            flowChart.SetIntegerVariable("ExecutingModuleCount", 0);
    }

    void Update()
    {
        ExecutingModuleCount = flowChart.GetIntegerVariable("ExecutingModuleCount"); 
    }

    void Say() 
    {
        if (canChat && !answered)
        {
            if(flowChart.HasBlock(ChatName) && ExecutingModuleCount == 0) 
            {
                flowChart.SetIntegerVariable("ExecutingModuleCount", 1);
                flowChart.ExecuteBlock(ChatName);
                answered = true;
            }
        }
    }

    public void SwitchToBonus(string bonusName)
    {
        ChatName = bonusName;
        answered = false; 
    }
}

