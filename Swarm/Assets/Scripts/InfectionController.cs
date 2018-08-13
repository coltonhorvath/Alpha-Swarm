using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class InfectionController : MonoBehaviour {

    
    float speed = 15f;
    float bloaterSpeed = 5f;
    float range = 20000f;
    float spawnChance = 50;
    private Transform targetHuman;
    NavMeshAgent infectionAgent;
    NavMeshAgent bloaterAgent;

    private string humanTag = "Human";
    private string vaccineTag = "Vaccine";

    void Start ()
    {
        infectionAgent = GetComponent<NavMeshAgent>();
        bloaterAgent = GetComponent<NavMeshAgent>();
        infectionAgent.autoBraking = false;
        infectionAgent.speed = speed;
        bloaterAgent.speed = bloaterSpeed;

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
            if (this.GetComponent<BloaterClass>())
            {
                Debug.Log("Bloater was accessed by " + this.gameObject.name + bloaterAgent.speed);
                bloaterAgent.SetDestination(targetHuman.transform.position);
            }
            if (this.GetComponent<InfectedClass>())
            {
                Debug.Log("Infected was accessed by" + this.gameObject.name + infectionAgent.speed);
                infectionAgent.SetDestination(targetHuman.transform.position);
            }
            //infectionAgent.SetDestination(targetHuman.transform.position);
        }
    }
}
