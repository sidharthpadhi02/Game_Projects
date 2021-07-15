using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 25f;
    //public float disInBetween;
    Transform target;
    NavMeshAgent agent;
    

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerMan.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector3.Distance(target.position, transform.position);

        if(distance<=lookRadius && distance>agent.stoppingDistance)
        {
            agent.SetDestination(target.position);
            
            anim.SetBool("EnemyRun", true);
            //anim.SetBool("EnemyWalk", false);
            anim.SetBool("EnemyIdle", false);
            //anim.SetBool("canAttack", false);

            GetComponent<EnemyPatrol>().enabled = false;

        }
        else if (distance<=agent.stoppingDistance)
        {
            anim.SetBool("EnemyRun", false);
            anim.SetBool("EnemyWalk", false);
            anim.SetBool("EnemyIdle", true);

            if(GetComponent<EnemyDamage>().isDead == false)
            {
                anim.SetTrigger("ct");
                //anim.SetBool("canAttack", true);
            }
            /*else if (GetComponent<EnemyDamage>().isDead == true)
            { 
                anim.SetBool("canAttack", false);
            }*/
            

            //face the target
            FaceTheTarget();

        }
 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    public void FaceTheTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        
    }
}
