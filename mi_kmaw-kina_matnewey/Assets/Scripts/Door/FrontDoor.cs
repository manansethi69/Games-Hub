using UnityEngine.SceneManagement;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.T;
    public string nextSceneName;
    private int SceneChangetime;
    public GameObject door;

    private bool playerInRange = false;

    public static Vector3 playerPosition;

    private void Awake()
    {
        SceneChangetime = PlayerPrefs.GetInt("SceneChangetime", 0);
        if(SceneChangetime > 0)
        {
            door.SetActive(false);
            PlayerPrefs.DeleteKey("SceneChangetime");
        }
    }

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

            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneChangetime += 1;
                PlayerPrefs.SetInt("SceneChangetime",SceneChangetime);
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("Next Scene name is not assigned!");
            }
        }
    }
}