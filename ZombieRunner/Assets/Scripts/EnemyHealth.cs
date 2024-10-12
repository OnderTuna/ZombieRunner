using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 5f; 
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
