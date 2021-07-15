 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    
    public float startWaitTime;

    private bool isRight=true;

    public Transform[] moveSpot;

    private Animator anim;
    private Vector3 pos1, pos2;

    private void Start()
    {
        
        anim = GetComponentInChildren<Animator>();
        pos1 = moveSpot[0].position;
        pos2 = moveSpot[1].position;
    }
    void Update()
    {
        if(isRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot[1].position, 
                                                        speed * Time.deltaTime);
            Vector3 direction = (moveSpot[1].position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            anim.SetBool("EnemyWalk", true);
            if(transform.position.Equals(pos2))
            {
                isRight = false;
                anim.SetBool("EnemyWalk", false);
                anim.SetBool("EnemyIdle", true);
            }
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot[0].position,
                                                        speed * Time.deltaTime);
            Vector3 direction = (moveSpot[0].position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            anim.SetBool("EnemyWalk", true);
            if (transform.position.Equals(pos1))
            {
                isRight = true;
                anim.SetBool("EnemyWalk", false);
                anim.SetBool("EnemyIdle", true);
            }
        }
        
        
    
    }
}
         