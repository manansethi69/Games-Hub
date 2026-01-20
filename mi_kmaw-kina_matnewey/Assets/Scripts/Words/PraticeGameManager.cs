using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PraticeGameManager : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI hintText;
    public TextMeshProUGUI coinText;
    public Button[] buttons;
    public int maxHintCount = 0;
    public Level level;
    private MikmaqWord currentWord;
    private int correctAnswersCount = 0;
    private int levelSwitchThreshold = 3;
    

    // Variables for hints
    public Button hintButton;
    private bool hintClicked = false;
    private int numHints = 5;

    //Variables for animation logic
    public Animator bossAnimator;
    public Animator playerAnimator;
    public Transform player;
    public Transform boss;
    public float moveSpeed = 2f;

    //bug fix attempt where buttons execute both methods at the same time after level switch
    public bool isPlayerAttacking;
    public bool isBossAttacking;

    //stores the starting position for the boss and player so that they can return to it
    public Vector3 bossOriginalPosition;
    public Vector3 playerOriginalPosition;
    
    //Variables for healthBar Logic
    public PractiseHealthBar playerHealthBar;
    public PractiseHealthBar bossHealthBar;

    //variables for endgame logic
    public GameObject playerObject;
    [SerializeField] public game_over_text_UI gameOver;
    //for boss death
    private Animator explodeAnimator;
    [SerializeField] private GameObject explode;
    public GameObject bossObject;

    void Start()
    {
        // Instantiate level1
        level = new Level1Words();
        SetButtonOnClickListeners();
        InitializeCurrentWord();
        
        hintButton.onClick.AddListener(HintButtonClick);
        UpdateHintText();

        //for animations
        InitializeAnimationVariables();

        //for healthbar
        playerHealthBar.setMaxHealth(100);
        bossHealthBar.setMaxHealth(300); //after 15 correct answers the game should end. default damage is 20
        explodeAnimator = explode.GetComponent<Animator>();

    }

    void InitializeCurrentWord()
    {
        if (level.words.Count > 0)
        {
            currentWord = level.GetRandomWord();
            wordText.text = currentWord.getWord();
            hintText.text = currentWord.getHint();
            hintText.gameObject.SetActive(false);
            hintClicked = false;
        }
    }

    void UpdateHintText() {
        hintButton.GetComponentInChildren<TextMeshProUGUI>().text = numHints + "/5\nHints";
    }

    void HintButtonClick() {
        if (!hintClicked && numHints > 0) {
            // Set the hint as active
            hintText.gameObject.SetActive(true);
            hintClicked = true;
            numHints--;
            UpdateHintText();
        }
    }

    void SetButtonOnClickListeners()
    {
        List<string> englishWordsForLevel = level.GetAllEnglishWords();
        int index = 0;
        foreach (Button button in buttons)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            
            if (buttonText != null)
            {
                buttonText.text = englishWordsForLevel[index];
                button.onClick.AddListener(() => OnButtonClick(buttonText.text));
                index++;
            }
        }
    }

    void OnButtonClick(string buttonText)
    {
        bool correct = buttonText == currentWord.getEnglishWord();
        // Debug.Log(correct? "Correct Answer!" : "Wrong Answer!");

        // Set new word
        if (correct) {
                level.ExcludeWord(currentWord);
                MainManager.Instance.coinInventory += 1;
                if (coinText != null) { coinText.text = MainManager.Instance.coinInventory.ToString(); }
                correctAnswersCount++;
                InitializeCurrentWord(); 
                StartCoroutine(PlayerAttack());
        }
        else {
                StartCoroutine(BossAttack());
        }

        if (correctAnswersCount == levelSwitchThreshold) { SwitchToNextLevel(); }
    }

    void InitializeAnimationVariables() {
        boss = GameObject.FindGameObjectWithTag("boss").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerOriginalPosition = player.position;
        bossOriginalPosition = boss.position;
    }

    void SetButtonsInteractable(bool interactable) {
        foreach(Button button in buttons) {
            button.interactable = interactable;
        }
    }
    
    //for player attack IEnumerator
    void BossTakeDamage() {
        bossHealthBar.takeDamage();
        if (bossHealthBar.getHealth() <= 0) {
            Explode();
        }
    }

    // Function for player to attack the boss
    IEnumerator PlayerAttack() {
        if(!isBossAttacking) {
            //remove acceess to the buttons while the attack animation is playing
            SetButtonsInteractable(false);
            isPlayerAttacking = true;
            // Move to each other - duplicate code
            while (Vector3.Distance(player.position, boss.position) > 2.0f) {
                player.position = Vector2.MoveTowards(player.position, boss.position, moveSpeed * Time.deltaTime);
                boss.position = Vector2.MoveTowards(boss.position, player.position, moveSpeed * Time.deltaTime);
                playerAnimator.SetBool("isMoving", true);
                bossAnimator.SetBool("isMoving", true);
                yield return null;
            }
            playerAnimator.SetBool("isMoving", false);
            bossAnimator.SetBool("isMoving", false);

            // Attack boss
            // for future installation of attack animation for Gopit based on what is agreed upon by the team.
            // playerAnimator.SetTrigger("Attack");

            bossAnimator.SetTrigger("Hurt");
            BossTakeDamage();

            //for attack duration
            yield return new WaitForSeconds(1.5f);

            bossAnimator.SetBool("IsHurting", false);

            // Move back - duplicate code
            player.Rotate(0f, 180f, 0f);
            boss.Rotate(0f, 180f, 0f);
            while(Vector3.Distance(player.position, playerOriginalPosition) > 1.0f && Vector3.Distance(boss.position, bossOriginalPosition) > 1.0f) {
                //when returning the hurt animation should not be playing due to delay from boss logic code
                playerAnimator.SetBool("Hurt", false);
                bossAnimator.SetBool("IsHurting", false);
                player.position = Vector2.MoveTowards(player.position, playerOriginalPosition, moveSpeed * Time.deltaTime);
                boss.position = Vector2.MoveTowards(boss.position, bossOriginalPosition, moveSpeed * Time.deltaTime);
                playerAnimator.SetBool("isMoving", true);
                bossAnimator.SetBool("isMoving", true);
                yield return null;
            }
            player.Rotate(0f, 180f, 0f);
            boss.Rotate(0f, 180f, 0f);
            playerAnimator.SetBool("isMoving", false);
            bossAnimator.SetBool("isMoving", false);
            isPlayerAttacking = false;
            //give back access to the buttons after the animation finishes
            SetButtonsInteractable(true);
        }
    }

    //for BossAttack IEnumerator
    void PlayerTakeDamage() {
        playerHealthBar.takeDamage();

        if (playerHealthBar.getHealth() <= 0) {
            playerObject.SetActive(false);
            gameOver.dead();
        }
    }

    IEnumerator BossAttack() {
        if (!isPlayerAttacking) {
            SetButtonsInteractable(false);
            isBossAttacking = true;
            // Move to each other - duplicate code
            while (Vector3.Distance(boss.position, player.position) > 2.0f) {
                player.position = Vector2.MoveTowards(player.position, boss.position, moveSpeed * Time.deltaTime);
                boss.position = Vector2.MoveTowards(boss.position, player.position, moveSpeed * Time.deltaTime);
                playerAnimator.SetBool("isMoving", true);
                bossAnimator.SetBool("isMoving", true);
                yield return null;
            }
            playerAnimator.SetBool("isMoving", false);
            bossAnimator.SetBool("isMoving", false);

            // Attack player
            bossAnimator.SetTrigger("Attack");

            //give time for attack to start and then display the player hurt animation
            yield return new WaitForSeconds(0.8f);
            playerAnimator.SetBool("Hurt", true);
            PlayerTakeDamage(); 
            //for attack duration
            yield return new WaitForSeconds(1.5f);
            
            playerAnimator.SetBool("Hurt", false);

            // Move back - duplicate code
            player.Rotate(0f, 180f, 0f);
            boss.Rotate(0f, 180f, 0f);
            while(Vector3.Distance(player.position, playerOriginalPosition) > 1.0f && Vector3.Distance(boss.position, bossOriginalPosition) > 1.0f) {
                //when returning the hurt animation should not be playing due to delay from boss logic code
                bossAnimator.SetBool("IsHurting", false);
                playerAnimator.SetBool("Hurt", false);
                player.position = Vector2.MoveTowards(player.position, playerOriginalPosition, moveSpeed * Time.deltaTime);
                boss.position = Vector2.MoveTowards(boss.position, bossOriginalPosition, moveSpeed * Time.deltaTime);
                playerAnimator.SetBool("isMoving", true);
                bossAnimator.SetBool("isMoving", true);
                yield return null;
            }
            player.Rotate(0f, 180f, 0f);
            boss.Rotate(0f, 180f, 0f);
            playerAnimator.SetBool("isMoving", false);
            bossAnimator.SetBool("isMoving", false);
            isBossAttacking = false;
            SetButtonsInteractable(true);
        }
    }

    //for boss death animation
    public void Explode() {
        explodeAnimator.SetTrigger("isDead");
        Invoke("DisableBoss", explodeAnimator.GetCurrentAnimatorStateInfo(0).length); // call DisableBoss
    }

    public void DisableBoss() {
        bossObject.SetActive(false);
        gameOver.dead();
    }

    
    
    void SwitchToNextLevel()
    {
        correctAnswersCount = 0;

        // Increment the level
        if (level.GetType() == typeof(Level1Words)) level = new Level2Words();
        else if (level.GetType() == typeof(Level2Words)) level = new Level3Words();
        else if (level.GetType() == typeof(Level3Words)) level = new Level4Words();
        else if (level.GetType() == typeof(Level4Words)) level = new Level5Words();
        else Explode();

        playerHealthBar.setMaxHealth(100);
        SetButtonOnClickListeners();
        InitializeCurrentWord();
    } 
}