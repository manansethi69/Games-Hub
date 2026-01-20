using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;

    public QuizManager quizManager;

    private void Awake()
    {
        quizManager = GameObject.Find("QuizManager").GetComponent<QuizManager>();
    }

    public void Answer()
    {
        if(isCorrect) {
            Debug.Log("Correct");
            quizManager.Correct();
        }
        else {
            Debug.Log("Wrong");
            quizManager.Wrong();
        }
    }
}
