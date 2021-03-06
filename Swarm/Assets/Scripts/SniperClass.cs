﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SniperClass : MonoBehaviour {

    public float health = 5f;
    public float healthTimer;
    public float speed = 12.5f;
    private float fireTimer;
    public float fireRatePerSecond;
    public float range;
    public float tooClose;
    public GameObject bulletPrefab;
    public Transform firePoint;
	public Transform partToRotate;
    private Transform targetInfection;
    private NavMeshAgent vaccineAgent;
    private Rigidbody infection;
    string infectionTag = "Infection";

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, tooClose);
    }

	void Start () {
        vaccineAgent = GetComponent<NavMeshAgent>();
        vaccineAgent.speed = speed;
	}

    void FixedUpdate()
    {
        UpdateTarget();
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRatePerSecond;
        }

		Vector3 directionToRotate = targetInfection.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(directionToRotate);
		Vector3 rotation = lookRotation.eulerAngles;
		partToRotate.rotation = lookRotation;
		
    }

    void UpdateTarget()
    {
        GameObject[] infections = GameObject.FindGameObjectsWithTag(infectionTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestInfection = null;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject infection in infections)
        {
            float distanceToTarget = Vector3.Distance(transform.position, infection.transform.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestInfection = infection;
            }
            else
            {
                targetInfection = null;
            }
        }
        // if(nearestInfection != null && shortestDistance <= tooClose)
        // {
        //     targetInfection = nearestInfection.transform;
        //     Vector3 dirToInfection = transform.position - targetInfection.transform.position;
        //     Vector3 runAway = transform.position + dirToInfection;
        //     vaccineAgent.SetDestination(runAway);
        // }
        if (nearestInfection != null && shortestDistance <= range)
        {
            targetInfection = nearestInfection.transform;
            vaccineAgent.destination = targetInfection.transform.position;
        }
        else
        {
            targetInfection = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //Change bullet damage here:
		bullet.damage = 5;

        if (bullet != null)
            bullet.Seek(targetInfection);
    }

    void OnCollisionStay(Collision stayInfo)
    {
        if(stayInfo.collider.tag == "Infection") SufferInfection();
    }
    
    void SufferInfection()
    {
        healthTimer += Time.deltaTime;
        if (healthTimer >= 1f)
        {
            health -= 1f;
            healthTimer = 0;
        }
        if (health <= 0) Die();
    }

    void Die()
    {
        if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(infection, transform.position, transform.rotation);
            }
    }
}
