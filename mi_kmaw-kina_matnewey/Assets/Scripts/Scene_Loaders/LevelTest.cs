using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pass(int level)
    {
        LevelSystem.Instance.PassLevel(level);
        SceneManager.LoadScene("StartScene");
    }
    public void Reset()
    {
        LevelSystem.Instance.ResetLevel();
        SceneManager.LoadScene("StartScene");
    }
}
