using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenHealth;
    public bool isDead = false;
    public Animator anim;
    void Start()
    {
        currenHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        //play hurt animation
        anim.SetTrigger("Hurt");


        if(currenHealth <=0)
        {
            Die();

        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("EnemyDied");

        //Die Animation;
        anim.SetBool("IsDead", true);
      
        

    }

  

}
