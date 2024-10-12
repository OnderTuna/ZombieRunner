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
    
    void Start()
    {
        myAI = GetComponent<NavMeshAgent>();
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
        if(distance <= myAI.stoppingDistance)
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
        Debug.Log($"{name} has seeked and is destroying {target.name}");
    }

    private void ChaseTarget()
    {
        myAI.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
