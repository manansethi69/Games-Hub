
using UnityEngine;
using Fungus;

public class WinningUI_Cafe : MonoBehaviour
{
    [SerializeField]
    GameObject star_Left, star_Middle_Left, star_Middle, star_Middle_Right, star_Right;
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
        int oldpoints = StaticPoints.valueToKeep;
        int newpoints = Points - oldpoints;
        int cpoints = flowchart.GetIntegerVariable("Cpoints");
        Debug.Log(newpoints);
        if(newpoints < 0){
            newpoints = 0;
        }
        if (cpoints == 0)
        {
            star_Left.SetActive(false);
            star_Middle_Left.SetActive(false);
            star_Middle.SetActive(false);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if (cpoints == 10)
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(false);
            star_Middle.SetActive(false);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if (cpoints == 20)
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(true);
            star_Middle.SetActive(false);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if (cpoints == 30)
        {
            star_Left.SetActive(true);
            star_Middle_Left.SetActive(true);
            star_Middle.SetActive(true);
            star_Middle_Right.SetActive(false);
            star_Right.SetActive(false);

        }
        else if (cpoints == 40)
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

        

    }
    
}
