using Fungus;
using UnityEngine;

public class InfoButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject MainSceneInfoUI;
    [SerializeField] private GameObject BonusRoundInfoUI;
    private Flowchart flowchart;
    private static bool DisplayingUI;

    private void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        MainSceneInfoUI.SetActive(false);
        BonusRoundInfoUI.SetActive(false);
        DisplayingUI = false;
    }

    public void OnButtonPress()
    {
        if (DisplayingUI)
        {
            MainSceneInfoUI.SetActive(false);
            BonusRoundInfoUI.SetActive(false);
            DisplayingUI = false;
        }
        else
        {
            if (flowchart.GetBooleanVariable("BonusRoundActive") == true)
            {
                BonusRoundInfoUI.SetActive(true);
                MainSceneInfoUI.SetActive(false);
                DisplayingUI = true;
            }

            else
            {
                MainSceneInfoUI.SetActive(true);
                BonusRoundInfoUI.SetActive(false);
                DisplayingUI = true;
            }
        }
    }
}