using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenuUI;

    private static bool settingsMenuActive;

    private void Start()
    {
        settingsMenuUI.SetActive(false);
        settingsMenuActive = false;
    }

    public void OnButtonPress()
    {

        // If the settings menu is already being displayed
        if (settingsMenuActive == true)
        {
            HideSettingsMenu();
            settingsMenuActive = false;
        }

        // If the settings menu is not currently active 
        else
        {
            ShowSettingsMenu();
            settingsMenuActive = true;
        }
    }

    private void ShowSettingsMenu()
    {
        settingsMenuUI.SetActive(true);
    }

    private void HideSettingsMenu()
    {
        settingsMenuUI.SetActive(false);
    }
}
