
using UnityEngine;
using Fungus;

public class WinningUI : MonoBehaviour
{
    [SerializeField]
    GameObject scoreTitleRibbon,starsBg,star_Left,star_Middle_Left,star_Middle,star_Middle_Right, star_Right,scoreBox,coins,gems,ok;
    
    public Flowchart flowchart;
    
    private void Awake()
    {
        // reset LeanTween
        LeanTween.reset();

    }

    /* logic :
    winning with 3 stars - score above or equal to 1500
    winning with 2 stars - score above or equal to 1300
    */

    // Start is called before the first frame update
    void Start()
    {
        // rotate the back color wheel, 360degree in 10seconds
        //  LeanTween.rotateAround(colorWheel,Vector3.forward,-360f,10f).setLoopClamp();

        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        int Points = flowchart.GetIntegerVariable("Points");
        Debug.Log(Points);
        
        if (Points < 65 )
        {
            star_Left.SetActive(false);
            star_Middle_Left.SetActive(false);
            star_Middle.SetActive(false);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if(Points >= 65 && Points < 80)
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(false);
            star_Middle.SetActive(false);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if (Points >= 80 && Points < 100)
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(true);
            star_Middle.SetActive(false);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if (Points >= 100 && Points < 120)
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(true);
            star_Middle.SetActive(true);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if (Points >= 120 && Points < 140)
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(true);
            star_Middle.SetActive(true);
            star_Middle_Right.SetActive(true);
            star_Right.SetActive(false);

        }
        else
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(true);
            star_Middle.SetActive(true);
            star_Middle_Right.SetActive(true);
            star_Right.SetActive(true);
        }

        /*// set the title ribbon animation
        LeanTween.moveLocal(scoreTitleRibbon,new Vector3(0f,115f,2f),1f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(scoreTitleRibbon,new Vector3(1.2f,1.2f,1.2f),2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(scoreTitleRibbon,new Vector3(1f,1f,1f),1f).setDelay(1.7f).setEase(LeanTweenType.easeOutCubic);
        
        if (Points ==1200){

            // display the middle star
        star_Middle.SetActive(true);
        LeanTween.moveLocal(star_Middle,new Vector3(0f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Middle,new Vector3(1f,1f,1f),0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic); 


        }
        
        if (Points >= 1300 && Points < 1500) 
        { 
        
        // set the star animation - show 2 stars
        star_Left.SetActive(true);
        LeanTween.moveLocal(star_Left,new Vector3(-80f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Left,new Vector3(1f,1f,1f),0.5f).setDelay(0.2f).setEase(LeanTweenType.easeInOutElastic);


        // display the middle star
        star_Middle.SetActive(true);
        LeanTween.moveLocal(star_Middle,new Vector3(0f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Middle,new Vector3(1f,1f,1f),0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic); 

        }

        else if (Points >= 1500) 
        {
            star_Left.SetActive(false);
            star_Right.SetActive(false);

        // set the star animation - show 3 stars
        star_Left.SetActive(true);
        LeanTween.moveLocal(star_Left,new Vector3(-80f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Left,new Vector3(1f,1f,1f),0.5f).setDelay(0.2f).setEase(LeanTweenType.easeInOutElastic);


        // display the right star
        star_Right.SetActive(true);
        LeanTween.moveLocal(star_Right,new Vector3(80f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Right,new Vector3(1f,1f,1f),0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic);

        // display the middle star
        star_Middle.SetActive(true);
        LeanTween.moveLocal(star_Middle,new Vector3(0f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Middle,new Vector3(1f,1f,1f),0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic); 

        }*/
        
    }
  /*
     private void TwoStar() 
    {
        // display the left star
        star_Left.SetActive(true);
        LeanTween.moveLocal(star_Left,new Vector3(-80f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(star_Left,new Vector3(1f,1f,1f),0.5f).setDelay(0.2f).setEase(LeanTweenType.easeInOutElastic).setOnComplete(RightStarAnim);

        //right star
         star_Right.SetActive(true);
        LeanTween.moveLocal(star_Right,new Vector3(80f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Right,new Vector3(1f,1f,1f),0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic); //.setOnComplete(MidStarAnim);

        //middle star
       //  star_Middle.SetActive(false);
   
    }
    
    //left star animation
    private void LeftStarAnim()
    {
        // display the left star
        star_Left.SetActive(true);
        LeanTween.moveLocal(star_Left,new Vector3(-80f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Left,new Vector3(1f,1f,1f),0.5f).setDelay(0.2f).setEase(LeanTweenType.easeInOutElastic).setOnComplete(RightStarAnim);


        // set the star background
        starsBg.SetActive(true);
    }

    // right star animation
    private void RightStarAnim()
    {
         // display the right star
        star_Right.SetActive(true);
        LeanTween.moveLocal(star_Right,new Vector3(80f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Right,new Vector3(1f,1f,1f),0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic);//.setOnComplete(MidStarAnim);

    }

    // middle star animation
    private void MidStarAnim()
    {
        // display the middle star
        star_Middle.SetActive(true);
        LeanTween.moveLocal(star_Middle,new Vector3(0f,60f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);
        // scale size
        LeanTween.scale(star_Middle,new Vector3(1f,1f,1f),0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutElastic); // .setOnComplete(Score) - link score animation
    }

//score animation
    private void Score()
    {
         // display the right star
        scoreBox.SetActive(true);
        LeanTween.moveLocal(scoreBox,new Vector3(0f,0f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);

    }
//coins animation
     private void Coins()
    {
         // display the right star
        coins.SetActive(true);
        LeanTween.moveLocal(coins,new Vector3(0f,-50f,2f),0.3f).setEase(LeanTweenType.easeInOutCubic);

    }
    */
}
