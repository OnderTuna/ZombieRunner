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
    
    void Start()
    {
        myAI = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        distance = Vector3.Distance( target.transform.position, transform.position);

        if(distance > chaseRange)
        {
            return;
        }
        else
        {
            myAI.SetDestination(target.transform.position);
        }
    }
}
