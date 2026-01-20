using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wordInformation : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public GameObject wordAnim_Canvas;
    public WordCollection wordScript;

    public Image wordImage;
    public TMP_Text text;
    public string englishWord;
    public string mi_kmaw_Word;

    public Animator wordAnim;
     public void start(){
        wordAnim.Play("in");
        wordAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
     }

    public Image panelImage;
    public void SayWord(){
        source.PlayOneShot(clip);
    }

    public void setClip(AudioClip clip){
        this.clip = clip;
    }

    public void setSource(AudioSource source){
        this.source = source;
    }
    public void ExitWordAnimation(){
        wordScript.ExitWordCoinAnimation();
        wordAnim_Canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void setWordScript(WordCollection wordScript){
        this.wordScript = wordScript;
    }

    public void setWordImage(Sprite wordImage){
        panelImage.sprite = wordImage;
    }

    public void setEnglishWordText(string englishWord){
        this.englishWord = englishWord;
    }

    public void setMi_kmaw_WordText(string mi_kmaw_Word){
        this.mi_kmaw_Word = mi_kmaw_Word;
        text.text = mi_kmaw_Word + " is the Mi'kmaq word for " + englishWord;
    }

    public void startAnim(){
        wordAnim.SetBool("showWord", true);
        StartCoroutine(waitForAnim());

    }

    IEnumerator waitForAnim(){
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 0.0f;
    }
}