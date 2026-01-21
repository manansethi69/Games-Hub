using Fungus;
using UnityEngine;

public class PauseButtonManager : MonoBehaviour
{

    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject PlayButton;

    private static bool currentlyPaused;
    private static bool musicMuted;

    private MenuDialog menuDialog;
    private SayDialog sayDialog;

    void Start()
    {
        currentlyPaused = false;
        menuDialog = MenuDialog.GetMenuDialog(); // Get reference to MenuDialog
        sayDialog = SayDialog.GetSayDialog(); // Get reference to SayDialog
    }

    public void OnButtonPress()
    {

        if(currentlyPaused == false)
        {
            PauseGame();
            HidePauseButton();
            ShowPlayButton();


            
        }

        else
        {
            ResumeGame();
            HidePlayButton();
            ShowPauseButton();
            

        }
        
        UpdateMusic();
    }

    public void PauseGame()
    {
        currentlyPaused = true;
        Time.timeScale = 0;

        // Disable MenuDialog buttons
        if (menuDialog != null)
        {
            menuDialog.SetButtonsInteractable(false);
        }

        if (sayDialog != null)
        {
            // Assuming SayDialog has a similar method to disable buttons
            sayDialog.SetButtonsInteractable(false);
        }

    }

    public void ResumeGame()
    {
        currentlyPaused = false;
        Time.timeScale = 1;


        if (menuDialog != null)
        {
            menuDialog.SetButtonsInteractable(true);
        }

        if (sayDialog != null)
        {
            // Assuming SayDialog has a similar method to enable buttons
            sayDialog.SetButtonsInteractable(true);
        }
    }

    private void ShowPauseButton()
    {
        PauseButton.SetActive(true);
    }

    private void HidePauseButton()
    {
        PauseButton.SetActive(false);
    }

    private void ShowPlayButton()
    {
        PlayButton.SetActive(true);
    }

    private void HidePlayButton()
    {
        PlayButton.SetActive(false);
    }

    private void UpdateMusic()
    {
        CheckMusicMuteStatus();

        if (musicMuted == false)
        {
            if (currentlyPaused == true)
            {
                AudioListener.pause = true; // Pause the music
            }

            else
            {
                AudioListener.pause = false; // Resume playing the music
            }
        }
    }

    private void CheckMusicMuteStatus()
    {
        musicMuted = PlayerPrefs.GetInt("muted") == 1;
    }
}
