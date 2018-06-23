﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VaccinatorControlller : MonoBehaviour {

    float health = 5f;
    float speed = 12.5f;
    float runDistance = 20f;
    float chaseDistance = 23f;
    private NavMeshAgent vaccineAgent;
    public Rigidbody infection;

	void Start () {
        vaccineAgent = GetComponent<NavMeshAgent>();
        vaccineAgent.speed = speed;
	}

	void Update () {
        Chase();
	}

    void Chase()
    {
        GameObject[] Infections = GameObject.FindGameObjectsWithTag("Infection");
        foreach (GameObject infection in Infections)
        {
            float distance = Vector3.Distance(transform.position, infection.transform.position);
            if (distance < runDistance)
            {
                Vector3 DirToPlayer = transform.position - infection.transform.position;
                Vector3 newPos = transform.position + DirToPlayer;
                vaccineAgent.SetDestination(newPos);
            }
            if (distance > chaseDistance)
            {
                Vector3 DirToPlayer = transform.position - infection.transform.position;
                Vector3 newPos = transform.position - DirToPlayer;
                vaccineAgent.SetDestination(newPos);
            }
        }
    }

    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Infection")
        {
            Debug.Log("hit");
            health = health - 1;
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(infection, transform.position, transform.rotation);
            }
        }
    }
}
