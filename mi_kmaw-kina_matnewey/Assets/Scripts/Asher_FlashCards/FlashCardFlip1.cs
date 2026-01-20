using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question1
{
    public string question;
    public string correctAnswer;
    public Question1(string q, string c)
    {
        question = q;
        correctAnswer = c;
    }
}

public class FlashCardFlip1 : MonoBehaviour
{

    public GameObject visibilityCardOne;
    public Boss_Movement2 boss;
    // public card1;
    // public FlashCardFlip2 card2;
    // public FlashCardFlip3 card3;
    // public FlashCardFlip4 card4;
    // public FlashCardFlip5 card5;
    // public FlashCardFlip6 card6;
    // public FlashCardFlip7 card7;
    // public GameObject[] cards;
    public string mikmaq;
    public string english;
  

    public RectTransform r; //hold flashcard object
    public Text cardText;


    public Question[] ques = new Question[1];

    private float flipTime = 0.5f;
    public int faceSide = 0; //0=front, 1=back
    private int isShrinking = -1; //-1= get smaller, 1= get bigger
    public bool isFlipping = false;
    public int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;

    public game_over_text_UI gameOverManager;

    private void Awake()
    {
        gameOverManager = GameObject.Find("GameOverMessage").GetComponent<game_over_text_UI>();
    }

    // Start is called before the first frame update
    void Start()
    {

        visibilityCardOne.SetActive(false);
        ques[0] = new Question(mikmaq, english);


        distancePerTime = r.localScale.x/flipTime;
        cardNum =  0;
        cardText.text = ques[cardNum].question;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipping)
        {
            Vector3 v = r.localScale;
            v.x += isShrinking * distancePerTime * Time.deltaTime;
            r.localScale = v;

            timeCount += Time.deltaTime;
            if((timeCount >= flipTime) && (isShrinking < 0))
            {
                isShrinking = 1; //make it grow
                timeCount = 0;
                if (faceSide == 0)
                {
                    faceSide = 1;
                    cardText.text = ques[cardNum].correctAnswer;
                }
                else
                {
                    faceSide = 0;
                    cardText.text = ques[cardNum].question;
                }
            }
            else if ((timeCount >= flipTime) && (isShrinking == 1))
            {
                isFlipping = false;
            }
        }

        // if game over, remove all cards
        if (gameOverManager.isGameOver == true) {
            visibilityCardOne.SetActive(false);
        }
    }

    public void NextCard()
    {
        faceSide = 0;
        cardNum++;
        if(cardNum >= ques.Length)
        {
            cardNum = 0;
        }
        cardText.text = ques[cardNum].question;
    }

    public void FlipCard()
    {
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }

    public void showCard()
    {
        visibilityCardOne.SetActive(true);
    }

    public bool isFlipped()
    {
        // when card is in English
        if(faceSide ==1){
            return true;
        }else{
            // when card is in Mikmaw
            return false;
        }
    }

    public IEnumerator changeColorToRed()
    {
        // assign image of color to red
        Image image = GetComponent<Image>();
        image.color = Color.red;

        // wait for 1.5s
        yield return new WaitForSeconds(1.5f);

        // reset to original color
        Color newColor;
        ColorUtility.TryParseHtmlString("#FAE8E0", out newColor);
        image.color = newColor;
    }

    public void RemoveAndDestroy()
    {
        Destroy(gameObject);
    }

}
