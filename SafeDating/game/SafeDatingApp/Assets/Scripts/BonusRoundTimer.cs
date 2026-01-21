using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;

public class BonusRoundTimer : MonoBehaviour
{
    private float countdown = 30;
    private bool bonusFinished = false;
    public GameObject bonusRoundTipBox;
    public GameObject winningUI;
    private Flowchart flowchart;
    public TMP_Text mtext;
    private bool countdownCompleted;
    public GameObject[] npcsToHide; // Array of NPC game objects to hide

    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        bonusFinished = false;
        ShowOrHideNPCs(bonusFinished);
        Debug.Log("Bonus round started");

    }

    void Update()
    {

        if (countdown <= 0 && !countdownCompleted)
        {
            flowchart.ExecuteBlock("QuestionUnresolved");
            if (!countdownCompleted)
            {
                countdownCompleted = true;
            }

            // Hide the NPCs when the countdown reaches zero
            bonusFinished = true;
            ShowOrHideNPCs(bonusFinished);
        }

        if (!countdownCompleted && !winningUI.activeSelf && !bonusRoundTipBox.activeSelf)
        {
            if (flowchart.GetBooleanVariable("DialoguePlaying") == false)
            {
                Count();
            }
        }
    }

    void Count()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            double b = System.Math.Round(countdown);
            mtext.text = b.ToString();
        }
    }

    void ShowOrHideNPCs(bool show)
    {
        foreach (GameObject obj in npcsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(show);
                Debug.Log("NPC " + obj.name + " is now " + (show ? "visible" : "hidden"));
            }
        }
    }
}
