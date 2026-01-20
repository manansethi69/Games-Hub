using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Reference: Code was copied from Painless Programming on Youtube

public class Question
{
    public string question;
    public string correctAnswer;
    public Question(string q, string c)
    {
        question = q;
        correctAnswer = c;
    }


}

public class Noseflashcardflip : MonoBehaviour
{
    public RectTransform r; //Hold Flashcard object scale
    public Text cardText;

    public Question[] ques = new Question[7];

    private float flipTime = 0.5f;
    private int faceSide = 0; //0=front, 1=back
    private int isShrinking = -1; //-1=get smaller, 1 get bigger
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timecount = 0;

    // Start is called before the first frame update
    void Start()
    {

        ques[0] = new Question("Ne’wt", "One");
        ques[1] = new Question("Ta’pu", "Two");
        ques[2] = new Question("Si’st", "Three");
        ques[3] = new Question("Ne’w", "Four");
        ques[4] = new Question("Na’n", "Five");
        ques[5] = new Question("Akusom", "Six");
        ques[6] = new Question("L’luiknek", "Seven");
    
      



        distancePerTime = r.localScale.x / flipTime;
        cardNum = 0;
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

            timecount += Time.deltaTime;
            if ((timecount >= flipTime) && (isShrinking < 0))
            {
                isShrinking = 1;//make it grow
                timecount = 0;
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
            else if ((timecount >= flipTime) && (isShrinking == 1))
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
        timecount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
    public void lastCard()
    {
        faceSide = 0;
        cardNum--;
        if(cardNum < 1)
        {
            cardNum = 0;

        }
        cardText.text = ques[cardNum].question; 
    }
}
