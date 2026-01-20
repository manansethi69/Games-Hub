using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static WordCollection;

public class WordCounter : MonoBehaviour
{
    GameObject Img;
    GameObject Num;
    GameObject alertBox;
    GameObject alertText;
    // Start is called before the first frame update
    void Start()
    {
        //sets Img and Num gameobjects to their respective objects
        Img = GameObject.Find("WordImg");
        Num = GameObject.Find("WordNum");
        alertBox = GameObject.Find("AlertBox");

        if (alertBox == null)
        {
            Debug.LogError("Alert Box Tile Not Found!!!");
        }
        
        alertText = GameObject.Find("AlertText");
    }

    // Update is called once per frame
    void Update()
    {
        //updates the counter with how many words are left to find
        Num.GetComponent<Text>().text = WordCollection.totalWords.ToString();

        //if there are no more words left to collect, the counter is removed and a text indicating that all words have been collected appears
        if (totalWords <= 0)
        {
            Img.SetActive(false);
            Num.SetActive(false);
            alertBox.SetActive(false);
            alertText.SetActive(false);
        }
    }
}
