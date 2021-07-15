using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Actions : MonoBehaviour
{
    private Animator animator;

    public MovePlayer joyControl;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Idle(bool idle)
    {
        animator.SetBool("Idle",idle);
    }

    public void Run(bool run)
    {
        animator.SetBool("Run",run);
    }
    public void Attack1()
    {

        animator.Play("Attack1");
        
            
    }
    public void Attack2()
    {
       
            animator.Play("Attack2");
    }
}
