using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Movement2 : MonoBehaviour
{
    public final_battle battle;
    public FlashCardFlip1 card1;
    public FlashCardFlip1 card2;
    public FlashCardFlip1 card3;
    public FlashCardFlip1 card4;
    public FlashCardFlip1 card5;
    public FlashCardFlip1 card6;
    public FlashCardFlip1 card7;
    public string[] bossWords;
    public int i=0; 
    
    public Animator animator;
    private Animator explodeAnimator;

    public MusicController musicController;
    
    // Animation states & params
    private bool IsAttacking;
    private bool IsHurting;

    private string currentState;
    const string Boss_attack = "Boss_attack";
    const string Boss_hurt = "Boss_hurt";
    const string Boss_Idle = "Boss_Idle";

    // Animation for dead
    [SerializeField] private GameObject explode;
    [SerializeField] private GameObject transitionDoor;


    public QuizManager quizManager;
    public PlayerMovement player;

    //float spinSpeed = 360f;
    bool isSpinning = false;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        if (player == null)
        {
            Debug.LogError("Player Movement script Not Found!!!");
        }

        card1 = GameObject.Find("FlashCard1").GetComponent<FlashCardFlip1>();
        card2 = GameObject.Find("FlashCard2").GetComponent<FlashCardFlip1>();
        card3 = GameObject.Find("FlashCard3").GetComponent<FlashCardFlip1>();
        card4 = GameObject.Find("FlashCard4").GetComponent<FlashCardFlip1>();
        card5 = GameObject.Find("FlashCard5").GetComponent<FlashCardFlip1>();
        card6 = GameObject.Find("FlashCard6").GetComponent<FlashCardFlip1>();
        card7 = GameObject.Find("FlashCard7").GetComponent<FlashCardFlip1>();

        musicController = GameObject.Find("MusicController").GetComponent<MusicController>();

        if (musicController == null)
        {
            Debug.LogError("MusicController Not Found!");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player") && !isSpinning){
            StartCoroutine(Spin());
            musicController.StartBossFight();
        }
    }
   

   IEnumerator Spin(){
    isSpinning = true;
    // Play boss1 entrance animation
    animator.SetTrigger("isSpinning");

        float elapsedTime = 0f;
        while (elapsedTime < 2f) {
            //transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f); // spin the character
            elapsedTime += Time.deltaTime;
            yield return null; // wait for the next frame
        }
        DisplayNumbers();

        // Display english question
        quizManager.ActivateQuestionPanel();
   }

   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
        explodeAnimator = explode.GetComponent<Animator>();
        transitionDoor.SetActive(false);
    }

    
    public void DisplayNumbers() 
    {
        if(i<7){
            // Display the current number
            //textMeshPro.text = bossWords[i];

            if(i<1){
                card1.showCard();
                card2.showCard();
                card3.showCard();
                card4.showCard();
                card5.showCard();
                card6.showCard();
                card7.showCard();
            }

            battle.setIdx(i);
            i++;
        }
        else{
            battle.pass();
        }
            
        // Wait for a short period of time before displaying the next number
            
        //  card1.checker(i);

        // Clear the text after all numbers have been displayed
       
    }

    void Update(){
    }

    public void Attack() {
        IsAttacking = true;
    }

    public void Hurt() {
        IsHurting = true;
    }

    public void Explode() {
        explodeAnimator.SetTrigger("isDead");
        Invoke("DisableBoss", explodeAnimator.GetCurrentAnimatorStateInfo(0).length); // call DisableBoss
    }

    public void DisableBoss() {
        gameObject.SetActive(false);
        transitionDoor.SetActive(true);
        player.SetCanMove(1); // Enable player movement
    }

    public void ChangeAnimationState(string newState) {
        if (currentState == newState) {
            return;
        }

        animator.Play(newState);
        currentState = newState;
    }
    
    private void FixedUpdate(){
        // if (currentState != Boss_Idle) {
        //     ChangeAnimationState(Boss_Idle);
        // }
        if (IsAttacking) {
            ChangeAnimationState(Boss_attack);
            IsAttacking = false;
            ChangeAnimationState(Boss_Idle);
        }
        if (IsHurting) {
            ChangeAnimationState(Boss_hurt);
            IsHurting = false;
            ChangeAnimationState(Boss_Idle);
        }
    }
   
}




