using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera myCam;
    [SerializeField] float range = 100f;
    EnemyHealth enemyHealthScript;
    [SerializeField] float weaponDamage = 1f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, range))
        {
            enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
            if(enemyHealthScript != null ) 
            {
                enemyHealthScript.TakeDamage(weaponDamage);
            }
        }
        else
        {
            return;
        }
    }
}
