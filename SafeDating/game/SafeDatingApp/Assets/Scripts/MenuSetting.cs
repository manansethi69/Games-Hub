using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class MenuSetting : MonoBehaviour
{
    [SerializeField] private GameObject winningUI, exitUI;

    private Flowchart flowchart;
    private int modulesCompleted;
    private int modulesRequired;
    private GameObject player;
    private bool paused = false; 
    private string bonusScene = "Bonus (dark)";
    private string bonusTimer = "Timer Bonus";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        modulesCompleted = flowchart.GetIntegerVariable("ModulesCompleted");
        modulesRequired = flowchart.GetIntegerVariable("ModulesRequired");

        if (modulesCompleted == modulesRequired)
        {
            //cleaning (closing) up regular round
            flowchart.SetIntegerVariable("ExecutingModuleCount", 0);
            AudioListener.pause = true;
            // bonus round setting up (starting)
            if(flowchart.GetBooleanVariable("HasBonus")){
                flowchart.ExecuteBlock(bonusScene);
                flowchart.ExecuteBlock(bonusTimer);
                player.transform.position = new Vector3(8.44f, -0.01f, -3.69f);
                player.transform.rotation = Quaternion.identity;
            }
            // prompt to next module if doesn't have bonus round
            else{
                winningUI.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //pauses game completely
        {
            if(paused == false || Time.timeScale == 1){
                exitUI.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }else{
                exitUI.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
           
        }

    }
}
