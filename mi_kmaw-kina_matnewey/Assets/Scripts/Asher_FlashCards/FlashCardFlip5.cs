using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question5
{
    public string question;
    public string correctAnswer;
    public Question5(string q, string c)
    {
        question = q;
        correctAnswer = c;
    }
}

public class FlashCardFlip5 : MonoBehaviour
{

    public RectTransform r; //hold flashcard object
    public Text cardText;

    public Question[] ques = new Question[1];

    private float flipTime = 0.5f;
    private int faceSide = 0; //0=front, 1=back
    private int isShrinking = -1; //-1= get smaller, 1= get bigger
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ques[0] = new Question("Na’n", "Five");

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
}
