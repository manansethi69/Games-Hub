using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class ButtonControl : MonoBehaviour
{

    private Flowchart flowchart;
    private string bonusScene = "Bonus (dark)";
    private string bonusTimer = "Timer Bonus";
    private int currentModule; 
    private GameObject character;
    private GameObject winningUI;

    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        character = GameObject.FindGameObjectWithTag("Player");
        winningUI = GameObject.Find("WinningUI");
        currentModule = flowchart.GetIntegerVariable("CurrentScene");
    }
    public void Restart()
    {
        if(SceneManager.GetActiveScene().name == "Cafe"){
            flowchart.SetIntegerVariable("Points", StaticPoints.valueToKeep);
            flowchart.SetIntegerVariable("Cpoints", 0);
            SceneManager.LoadScene(2);
        }else{
            flowchart.SetIntegerVariable("Points", 100);
            flowchart.SetIntegerVariable("Cpoints", 0);
            SceneManager.LoadScene(1);
        }
        
        Time.timeScale = 1;
    }

    public void Home()
    {
        flowchart.SetIntegerVariable("Points", 100);
        flowchart.SetIntegerVariable("Cpoints", 0);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        
    }

    public void Back(){ //added so the back button also unpauses the game
        Time.timeScale = 1;

    }

    public void Next()
    {
        if (flowchart.GetBooleanVariable("HasBonus"))
        {
            ContinueBonusScene();
        }
		else if(flowchart.GetBooleanVariable("BonusCompleted")){
            currentModule = currentModule + 1;
            int pointstokeep = flowchart.GetIntegerVariable("Points");
            StaticPoints.valueToKeep = pointstokeep;
			SceneManager.LoadScene(currentModule);
		}
        else{
            int pointstokeep = flowchart.GetIntegerVariable("Points");
            StaticPoints.valueToKeep = pointstokeep;
            SceneManager.LoadScene(currentModule);
        }
    }

    void ContinueBonusScene()
    {
        // Turn off the end game screen UI if it exists
        winningUI.SetActive(false);
        Time.timeScale = 1f;  // Resume time scale to restore normal gameplay speed
        character.transform.position = new Vector3(8.44f, -0.01f, -3.69f);    
        character.transform.rotation = Quaternion.identity;
        flowchart.ExecuteBlock(bonusScene);
        flowchart.ExecuteBlock(bonusTimer);
    }
    public void BacktoScene1()
    { 
        SceneManager.LoadScene(0);
    }
    public void pointReset(){
        flowchart.SetIntegerVariable("Points", 100); //resets points when the game ends
        flowchart.SetIntegerVariable("Cpoints", 0);
    }

}

