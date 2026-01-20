using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] BirdImages;
    public GameObject[] LocksImages;
    public int Current_Level;
    public int previous_Level;
    public bool show_Lock;

    public void Start()
    {
        Current_Level = 0;
        show_Lock = false;
    }
    public void Update()
    {
        if (show_Lock)
        {
            remove_lock();
        }
    }
    //public void Level_Selection(int level)
    //{
    //    Current_Level = level;
    //    if (level > 1)
    //    {
    //        BirdImages[previous_Level].gameObject.SetActive(false);
    //    }
    //    previous_Level = level;
    //    BirdImages[level].gameObject.SetActive(true);
    //}
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        Destroy(gameObject);
    }
    public void remove_lock()
    {
        for(int i = 0; i < LocksImages.Length; i++)
        {
            LocksImages[i].gameObject.SetActive(false);
        }
    }
    public void Active_lock()
    {
        for (int i = 0; i < LocksImages.Length; i++)
        {
            LocksImages[i].gameObject.SetActive(true);
        }
    }
}
