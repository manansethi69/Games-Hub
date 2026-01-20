using UnityEngine.SceneManagement;
using UnityEngine;

public class BackDoor : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.T;

    public string targetScene;

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            RestoreSceneState();
            SceneManager.LoadScene(targetScene);
        }
    }

    public void RestoreSceneState()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = FrontDoor.playerPosition;
    }
}

