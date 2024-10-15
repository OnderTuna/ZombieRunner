using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float damage = 40f;
    PlayerHealth healthScript;

    void Awake()
    {
        healthScript = FindObjectOfType<PlayerHealth>();
    }
    
    public void AttackHitEvent()
    {
        if(target != null)
        {
            healthScript.TakeDamageFromEnemy(damage);
        }
    }
}
