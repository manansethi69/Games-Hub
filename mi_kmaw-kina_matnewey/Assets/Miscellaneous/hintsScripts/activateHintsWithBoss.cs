using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class activateHintsWithBoss : MonoBehaviour
{
    public GameObject hintButton;
    public Image hintImage;
    public bool active;
    public int index;
    public Sprite[] sprites;
    public string[] words;
    public bool end;

    // Start is called before the first frame update
    void Start()
    {
        hintButton.SetActive(false);
        active = false;
        index = 0;
    }

    // Update is called once per frame
    public void bossCallsHint(){
                if (index < 1)
                {
                    hintButton.SetActive(true);
                    active = true;
                    index++;
                }
                else if(index > 0 && index < 7){
                    hintImage.sprite = sprites[index];
                    index++;
                }
                else if(index == 7)
                {
                    end = true;
                }
    }
    void Update(){
        if(end){
            Start();
        }
    }
}
