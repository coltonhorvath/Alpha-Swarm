﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class InfectionController : MonoBehaviour {
     /*public int health = 3;
    
    float speed = 15f;
    float range = 20000f;
    float spawnChance = 50;
    private Transform targetHuman;
    NavMeshAgent infectionAgent;
     public string humanTag = "Human";
    public string vaccineTag = "Vaccine";

     void Start ()
    {
         infectionAgent = GetComponent<NavMeshAgent>();
         infectionAgent.autoBraking = false;
         infectionAgent.speed = speed;
 
         //InvokeRepeating("UpdateTarget", 0f, 10f);
 	}
 
     void Update()
     {
         UpdateTarget();
     }
 
     void UpdateTarget()
     {
         GameObject[] Humans = GameObject.FindGameObjectsWithTag(humanTag);
         GameObject[] Vaccines = GameObject.FindGameObjectsWithTag(vaccineTag);
         GameObject[] HV = Humans.Concat(Vaccines).ToArray();
 
         float shortestDistance = Mathf.Infinity;
         GameObject nearestHuman = null;
         Vector3 currentPosition = this.transform.position;
 
         foreach (GameObject huvacs in HV)
         {
             Vector3 directionToTarget = huvacs.transform.position - currentPosition;
 
             float distanceToTarget = directionToTarget.sqrMagnitude;
             if (distanceToTarget < shortestDistance)
             {
                 shortestDistance = distanceToTarget;
                 nearestHuman = huvacs;
             }
             else
             {
                 targetHuman = null;
             }
         }
 
         if (nearestHuman != null && shortestDistance <= range)
         {
             targetHuman = nearestHuman.transform;
             infectionAgent.SetDestination(targetHuman.transform.position);
        }
    }
    public void damageTaken (int damage)
    {
        health -= damage;
        if(health <= 0)
         {
             Die();
         }
     }
     
    void Die()
    {
        Destroy(gameObject);
    }*/
}