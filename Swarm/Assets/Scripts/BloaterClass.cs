using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class BloaterClass : MonoBehaviour {
 	public int health;
    public float speed;
    public float range;
    public float spawnChance;
    private Transform targetHuman;
    public GameObject Pod;
    NavMeshAgent bloaterAgent;
    protected string humanTag = "Human";
    protected string vaccineTag = "Vaccine";
    protected string podSpawnTag = "PodSpawn";

    protected void Start ()
    {
        bloaterAgent = GetComponent<NavMeshAgent>();
        bloaterAgent.autoBraking = false;
        bloaterAgent.speed = speed;
        this.gameObject.tag = "Infection";
        //InvokeRepeating("UpdateTarget", 0f, 10f);
 	}

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
 
    protected void Update()
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
            //Vector3 directionToTarget = huvacs.transform.position - currentPosition;
            float distanceToTarget = Vector3.Distance(transform.position, huvacs.transform.position);
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
            bloaterAgent.SetDestination(targetHuman.transform.position);
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
        GameObject[] podSpawnArray = GameObject.FindGameObjectsWithTag(podSpawnTag);
        foreach (GameObject podSpawnPoints in podSpawnArray)
        {
            GameObject podInstance = Instantiate(Pod, podSpawnPoints.transform.position, transform.rotation);
        }
    }
 }