using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    NavMeshAgent myAI;
    
    void Start()
    {
        myAI = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        myAI.SetDestination(target.transform.position);
    }
}
