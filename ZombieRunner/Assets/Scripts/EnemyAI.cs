using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float chaseRange = 5f;
    NavMeshAgent myAI;
    private float distance = Mathf.Infinity;
    bool isProvoked = false;
    Animator enemyAnim;
    [SerializeField] private float turnSpeed = 5f;

    void Start()
    {
        myAI = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        distance = Vector3.Distance( target.transform.position, transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distance <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distance <= myAI.stoppingDistance)
        {
            Attacktarget();
        }

        if(distance >= myAI.stoppingDistance)
        {
            ChaseTarget();
        }
    }

    private void Attacktarget()
    {
        enemyAnim.SetBool("Attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        enemyAnim.SetBool("Attack", false);
        enemyAnim.SetTrigger("Move");
        myAI.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    
}
