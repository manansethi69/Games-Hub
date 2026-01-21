using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuySit : MonoBehaviour
{
    public Animator guy;
    public Animator guyModel;
    public GameObject girl;
    public Animator cm;
    // Start is called before the first frame update
    void Start()
    {
        guy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void Sit()
    {
        StartCoroutine(Sit1());
        StartCoroutine(MoveToTarget());
        cm.SetBool("focus", true);
        CafeCameraZoom.UpdateSitting(true);
    }

   public  IEnumerator Sit1()
    {
        guy.SetBool("guysit", true);
        guyModel.SetBool("Sit", true);
        yield return new WaitForSeconds(2f);
    }
    public Transform targetObject; // Reference to the target GameObject
    public float moveSpeed = 2.0f; // Speed of movement

    private bool isMoving = false; // Flag to check if the object is currently moving

   

    IEnumerator MoveToTarget()
    {
        isMoving = true;
        Vector3 initialPosition = girl.transform.position;
        Vector3 targetPosition = targetObject.position;
        float journeyLength = Vector3.Distance(initialPosition, targetPosition);
        float startTime = Time.time;

        while (Time.time - startTime < journeyLength / moveSpeed)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            girl.transform.position = Vector3.Lerp(initialPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        girl.transform.position = targetPosition;
        isMoving = false;
    }
}
