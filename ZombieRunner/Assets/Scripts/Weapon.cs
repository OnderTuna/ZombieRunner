using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera myCam;
    [SerializeField] float range = 100f;
    EnemyHealth enemyHealthScript;
    [SerializeField] float weaponDamage = 1f;
    [SerializeField] ParticleSystem muzzleEffect;
    [SerializeField] GameObject impactEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        ProcessRaycast();
        MuzzleEffect();
    }

    private void MuzzleEffect()
    {
        if (!muzzleEffect.isPlaying)
        {
            muzzleEffect.Play();
        }
    }

    public void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealthScript != null)
            {
                enemyHealthScript.TakeDamage(weaponDamage);
            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        Instantiate(impactEffect, hit.point, Quaternion.identity);
    }
}
