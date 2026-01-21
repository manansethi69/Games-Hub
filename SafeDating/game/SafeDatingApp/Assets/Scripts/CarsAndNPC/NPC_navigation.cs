using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//from unity.com => navigation patrol and modify by Rui
public class NPC_navigation : MonoBehaviour
{
    //public Transform[] points;
    public Vector3[] points;
    public bool iswalk;

    private int destPoint = 0;

    private NavMeshAgent agent;
    private string WALKING_FLAG = "isWalking";
    private Animator animator;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();

        agent.autoBraking = false;
        
        animator.SetBool(WALKING_FLAG, iswalk);
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint];

        destPoint = (destPoint + 1) % points.Length;
    }

    private void OnAnimatorMove()
    {
        animator.SetBool(WALKING_FLAG, iswalk);
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    private void Update()
    {

        OnAnimatorMove();
    }
}
