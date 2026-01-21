using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neighbourMove : MonoBehaviour
{

    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 10f;
    private bool isMoving = true;
    float radius = 0.5f;

    // private int obstacleLayer= (1<<7);
    private int obstacleLayer, obstacleLayer2;
    private float raycastDistance = 1;

    // Wait for 60 seconds before the car starts moving after colliding with another car
    public float startDelay = 60f;
    private bool timerStarted = false; // Count for 60 minutes

    private bool movingTowardsPointB = true;
    private bool movingTowardsPointA = false;


    void Start()
    {
        // Make raycast only detect the chanracter layer
        obstacleLayer = 1 << LayerMask.NameToLayer("Character");
        obstacleLayer2 = 1 << LayerMask.NameToLayer("Vehicle");
        Debug.Log(obstacleLayer);
    }

    void Update()
    {

        Vector3 targetPosition = movingTowardsPointB ? pointB : pointA;
        Vector3 direction = targetPosition - transform.position;



        RaycastHit hit;

        if (isMoving)
        {
            Move();
        }


        // Physics.Raycast(transform.position + new Vector3(0f, 0.05f, 0f), direction, out hit, raycastDistance, obstacleLayer)

        // SphereCast will detect the object in direction of car
        // Added new Vector3(0f, 0.05f, 0f) to move the raycast up and increase accuracy
        if (Physics.SphereCast(transform.position + new Vector3(0f, 0.05f, 0f), radius, direction, out hit, raycastDistance, obstacleLayer))
        {
            // Draw a debug ray in red to visualize the raycast
            Debug.DrawRay(transform.position, direction, Color.red);

            // stop if it detect the player
            if (hit.collider.CompareTag("Player"))
            {

                SetMovingStatus(false);

            }
            if (hit.collider.CompareTag("Vehicle"))
            {

                //SetMovingStatus(false);
                isMoving = false;
                return;


            }
        }
        else if (Physics.Raycast(transform.position + new Vector3(0f, 0.05f, 0f), direction, out hit, raycastDistance, obstacleLayer2))
        {
            if (timerStarted)
            {
                return;
            }
            else
            {
                StartCoroutine(StartMovingAfterDelay());
            }
        }
        else
        {

            // move if it does not detect anything
            SetMovingStatus(true);
        }




    }

    private IEnumerator StartMovingAfterDelay()
    {
        if (!timerStarted)
        {
            timerStarted = true;
        SetMovingStatus(false);

        Debug.Log("Stop for 10 seconds");
        yield return new WaitForSeconds(1f); // Stop for 10 seconds

        Debug.Log("Start moving after delay");
        //SetMovingStatus(true);

        yield return new WaitForSeconds(1f); // Keep moving for additional 10 seconds

        timerStarted = false;
        }
    }



    void Move()
    {


        // Calculate the direction to move towards the current target point
        Vector3 targetPosition = movingTowardsPointB ? pointB : pointA;
        Vector3 direction = targetPosition - transform.position;

        // Move towards the target point
        transform.position += direction.normalized * speed * Time.deltaTime;

        // Check if the target point has been reached
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distanceToTarget < 0.1f)
        {
            //telepote to pointA when arrive pointB
            this.transform.position = pointA;
            // If the target point has been reached, switch to the other target point
            //movingTowardsPointB = !movingTowardsPointB;
            //movingTowardsPointA = !movingTowardsPointA; 

            // Rotate the character by 180 degrees if moving towards point A from point B
            //if (!movingTowardsPointB)
            //{
            //    transform.Rotate(0f, 0f, 180f);
            //}
            // Rotate the character by 180 degrees if moving towards point B from point A
            //if (!movingTowardsPointA)
            //{
            //    transform.Rotate(0f, 0f, 180f);
            //}


        }

    }

    // The movement of the car when another car is infront of it




    private void SetMovingStatus(bool status)
    {
        isMoving = status;
    }
}
