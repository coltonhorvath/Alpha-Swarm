using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class InfectionController : MonoBehaviour {

    float health = 5f;
    float speed = 15f;
    float range = 20000f;
    private Transform targetHuman;
    NavMeshAgent infectionAgent;

    public string humanTag = "Human";

    void Start ()
    {
        infectionAgent = GetComponent<NavMeshAgent>();
        infectionAgent.autoBraking = false;
        infectionAgent.speed = speed;

        //InvokeRepeating("UpdateTarget", 0f, 10f);
	}

    void UpdateTarget()
    {
        GameObject[] Humans = GameObject.FindGameObjectsWithTag(humanTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestHuman = null;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject human in Humans)
        {
            Vector3 directionToTarget = human.transform.position - currentPosition;

            float distanceToTarget = directionToTarget.sqrMagnitude;
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestHuman = human;
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

	void Update ()
    {
        UpdateTarget();
	}

    /*private Vector3 FindClosestHuman()
    {
        GameObject[] Humans = GameObject.FindGameObjectsWithTag("Human");
        GameObject[] Vaccines = GameObject.FindGameObjectsWithTag("Vaccine");
        GameObject[] HV = Humans.Concat(Vaccines).ToArray();

        float shortestDistance = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject victim in HV)
        {
            Vector3 directionToTarget = victim.transform.position - currentPosition;

            float distanceToTarget = directionToTarget.sqrMagnitude;
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = victim.transform;
            }
        }

        return nearestTarget.position;
    }*/
}
