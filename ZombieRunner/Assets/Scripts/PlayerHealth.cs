using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void TakeDamageFromEnemy(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            Debug.Log(health);
        }
        else
        {
            Debug.Log("Death");
        }
    }
}
