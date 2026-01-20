using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class final_battle : MonoBehaviour
{

    public GameObject character;
    public FlashCardFlip1[] cards;
    public Boss_Movement2 boss; 
    public game_over_text_UI gameOver;
    public DamageController damage; 
    public int idx; 
    public Image image; 
    public Color color1;
    public Color color2;
    
    Animator animator;
    private bool IsAttacking;
    private bool IsHurting;
    // Animation states
    private string currentState;
    const string Boss_attack = "Boss_attack";
    const string Boss_hurt = "Boss_hurt";
    const string Boss_Idle = "Boss_Idle";

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.isGameOver==false){
            // Player chose correct card
            if (cards[idx].isFlipped()){
            cards[idx].visibilityCardOne.SetActive(false); //destroy the right card
            //next number comes out
            cards[idx].faceSide=0;
            boss.DisplayNumbers();
            //animator.SetBool("IsHurting", true); //play hurt animation
            IsHurting = true;
            } 
            else{
                for(int i=0;i<7;i++){
                    if (i!=idx){
                        if(!cards[i].isFlipped() && !cards[i].isFlipping){
                            image = cards[i].GetComponent<Image>();
                            image.color = color2;
                        }
                        // Player chose wrong card
                        if(cards[i].isFlipped() && !cards[i].isFlipping){
                            image = cards[i].GetComponent<Image>();
                            image.color = color1;
                        
                            // Reduce 1 heart and play attack animation
                            damage.Damage();
                            IsAttacking = true;

                            cards[i].FlipCard();
                            cards[i].visibilityCardOne.SetActive(true);
                            break;
                        }
                    }
                }
            }
        }else{
            for(int k=0;k<7;k++){
                cards[k].visibilityCardOne.SetActive(false);
            }
        }
    }

    public void setIdx(int index){
        idx = index;
    }

    public void pass(){
        gameOver.isGameOver=true;
        gameOver.gameOverText.text = "Congratulations on passing!";
        
    }

    public void ChangeAnimationState(string newState) {
        if (currentState == newState) {
            return;
        }

        animator.Play(newState);
        currentState = newState;
    }
    
    private void FixedUpdate(){
        if (currentState != Boss_Idle) {
            ChangeAnimationState(Boss_Idle);
        }
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
