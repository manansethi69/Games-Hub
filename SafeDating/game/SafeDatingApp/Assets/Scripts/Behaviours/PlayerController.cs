using UnityEngine;
using UnityEngine.InputSystem;
using Fungus;

public class PlayerController : MonoBehaviour{
    private Rigidbody rigidBody;

    //Speed Variables
    [SerializeField] private float speed = 0.1f;
    private float turnSpeed = 0.1f;
    private float movementSmoothingSpeed = 1f;

    //Movement Vectors
    private Vector2 inputMovement;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;

    //Camera
    private Transform cameraTransform;

    //Animations
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    //Logic Checks
    private Flowchart flowchart;
    private bool canWalk = false;
    private int modulesCompleted;
    private int modulesRequired;
    private bool isDialoguePlaying;
    

    //Actions at start of scene
    void Start(){
        //Get object body
        rigidBody = GetComponent<Rigidbody>();

        //Load Animations
        anim = GetComponent<Animator>();
        anim.SetBool(WALK_ANIMATION, false);

        //Find Camera
        cameraTransform = GameObject.Find("Main Camera").transform;

        //Link Flowchart
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    //When a new button is pressed, update movement
    public void OnMove(InputAction.CallbackContext value){
        inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
        
    }

    void Update(){
        isDialoguePlaying = flowchart.GetBooleanVariable("DialoguePlaying");
        if((rawInputMovement.x != 0 || rawInputMovement.y != 0 || rawInputMovement.z != 0) && !isDialoguePlaying) canWalk = true;
        else canWalk = false;

    }
    
    //Moves player as button is held
    void FixedUpdate(){
        Debug.Log(canWalk);
        modulesCompleted = flowchart.GetIntegerVariable("ModulesCompleted");
        modulesRequired = flowchart.GetIntegerVariable("ModulesRequired");

        if(canWalk && modulesCompleted != modulesRequired){
            if (!SayDialog.GetSayDialog().FadeWhenDone && SayDialog.GetSayDialog().GetComponent<Writer>().HasWordsRemaining){
                anim.SetBool(WALK_ANIMATION, false);
            }
            else{
                //Move Player
                Vector3 movement = CameraDirection(rawInputMovement) * speed * Time.deltaTime;
                rigidBody.MovePosition(transform.position + movement);

                //Rotate Player
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0);
                rigidBody.MoveRotation(targetRotation);

                anim.SetBool(WALK_ANIMATION, true);
            }
        }
        else anim.SetBool(WALK_ANIMATION, false);
        
    }
    
    //Moves player relative to camera direction
    Vector3 CameraDirection(Vector3 inputMovement){
        var cameraForward = cameraTransform.forward;
        var cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        
        return cameraForward * inputMovement.z + cameraRight * inputMovement.x; 
   
    }
}

