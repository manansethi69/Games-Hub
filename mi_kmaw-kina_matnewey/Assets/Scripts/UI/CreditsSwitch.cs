using UnityEngine;
using UnityEngine.UI;

public class CreditsSwitch : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    private bool showFirst = true;

    public void ToggleText()
    {
        showFirst = !showFirst;
        text1.SetActive(showFirst);
        text2.SetActive(!showFirst);
    }

    void Start()
    {
        text1.SetActive(true);
        text2.SetActive(false);
    }
}

