using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_idle : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    private string NPC = "NPC_id";
    private Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetInteger(NPC, id);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger(NPC, id);
    }
}

