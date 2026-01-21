using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonCafeScript : MonoBehaviour
{
    [SerializeField] private GameObject CafeSceneInfoUI;
    private Flowchart flowchart;
    private static bool DisplayingUI;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        CafeSceneInfoUI.SetActive(true);
        DisplayingUI = true;
    }

    // Update is called once per frame
    public void OnButtonPress()
    {
        if (DisplayingUI == false)
        {
            CafeSceneInfoUI.SetActive(true);
            DisplayingUI = true;
        }
        else
        {
            CafeSceneInfoUI.SetActive(false);
            DisplayingUI = false;
        }
    }
}
