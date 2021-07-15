using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwordAttack : MonoBehaviour
{
    public Animator anim;
    public float attackRange = 0.5f;
    public Transform attackPoint;
   
    
    

    

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        
       

    }


    public void Attack()
    {
       // anim.Play("Attack1");
        anim.SetTrigger("Attack");

       
        

    }

   private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    

}
