using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    public List<FlashCardFlip1> options;
    public List<WordPair> questions;
    public int currentQuestion;
    public GameObject questionPanel;

    [SerializeField]
    private Text questionText;

    // Controllers for damage health
    public DamageController damageController;
    public healthcontrol healthController;

    public Boss_Movement2 boss;

    // Hints
    public List<Sprite> sprites;
    public Image hintImage;
    public GameObject hintButton;

    private void Awake()
    {
        questionPanel = GameObject.Find("QuestionPanel");
        hintButton = GameObject.Find("HintButton");
        hintImage = GameObject.Find("HintImage").GetComponent<Image>();
        questionText = GameObject.Find("EnglishQuestion").GetComponent<Text>();
        
        options = new List<FlashCardFlip1>
        {
            GameObject.Find("FlashCard1").GetComponent<FlashCardFlip1>(),
            GameObject.Find("FlashCard2").GetComponent<FlashCardFlip1>(),
            GameObject.Find("FlashCard3").GetComponent<FlashCardFlip1>(),
            GameObject.Find("FlashCard4").GetComponent<FlashCardFlip1>(),
            GameObject.Find("FlashCard5").GetComponent<FlashCardFlip1>(),
            GameObject.Find("FlashCard6").GetComponent<FlashCardFlip1>(),
            GameObject.Find("FlashCard7").GetComponent<FlashCardFlip1>()
        };
        
    }

    void Start()
    {

        //each position in the array references the starting positions of each of the flashcards in the scenes.
        Vector3[] positions = new Vector3[] {
            new Vector3(-506, -123, 0),
            new Vector3(0, -123, 0),
            new Vector3(496, -123, 0),
            new Vector3(-700, -324, 0),
            new Vector3(-250, -324, 0),
            new Vector3(250, -324, 0),
            new Vector3(726, -324, 0)
        };
        
        positions = positions.OrderBy(x => Random.value).ToArray();
        
        for (int i = 0; i < options.Count; i++) {
            options[i].transform.localPosition = positions[i];
        }

        // Disable english question text and the hint button
        questionPanel.SetActive(false);
        hintButton.SetActive(false);

        // Get random question
        SetQuestion();
    }

    void Update()
    {
        // Flip the card that was clicked by player
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].isFlipped() && !options[i].isFlipping)
            {
                // card color change to red
                StartCoroutine(options[i].changeColorToRed());

                options[i].FlipCard();
            }
        }
        
        SetAnswers();
    }

    public void ActivateQuestionPanel()
    {
        // Display english question
        questionPanel.SetActive(true);
        hintButton.SetActive(true);
    }

    public void Correct()
    {
        boss.Hurt(); // Boss play hurt animation

        // Remove correct/answered from question list & options list
        questions.RemoveAt(currentQuestion);
        sprites.RemoveAt(currentQuestion);
        RemoveAndDestroyGameObject(currentQuestion);

        SetQuestion();
    }

    public void Wrong()
    {
        boss.Attack(); // Boss play attack animation

        damageController.Damage();
    }

    public void SetQuestion()
    {
        // Check if player pass the game
        if (options.Count != 0)
        {
            // Pick a random question
            currentQuestion = Random.Range(0, questions.Count);
            //Debug.Log("In `SetQuestion()`: index of current question: " + currentQuestion);
            questionText.text = questions[currentQuestion].english;
            hintImage.sprite = sprites[currentQuestion];

            SetAnswers();
        }
        // Transition to main menu when answered all questions
        else 
        {
            boss.Explode(); 
            questionPanel.SetActive(false);
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            // Assign answer to the flashcard, commented out as answer have assigned on Unity therefore no need to reassign in script
            //options[i].transform.GetChild(0).GetComponent<Text>().text = questions[currentQuestion].mikmaw[i];

            // If the player selects the correct answer
            if (
                questions[currentQuestion].correctAnswer
                == options[i].transform.GetChild(0).GetComponent<Text>().text
            )
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void RemoveAndDestroyGameObject(int index)
    {
        if (index >= 0 && index < options.Count)
        {
            FlashCardFlip1 flashCard = options[index];
            // Remove card from options list
            options.RemoveAt(index);
            flashCard.RemoveAndDestroy();
        }
    }
}
