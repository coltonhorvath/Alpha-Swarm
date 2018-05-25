using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InfectionController : MonoBehaviour {

    public float searchRadius = 20f;
    NavMeshAgent infectionAgent;
    public Transform humanTarget;
    private Vector3 FindClosestHuman()
    {
        GameObject[] Humans = GameObject.FindGameObjectsWithTag("Human");

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;
        foreach (GameObject human in Humans)
        {
            Vector3 directionToTarget = human.transform.position - currentPosition;

            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = human.transform;
            }
        }

        return bestTarget.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }

	// Use this for initialization
	void Start ()
    {
        infectionAgent = this.GetComponent<NavMeshAgent>();
        infectionAgent.autoBraking = false;
	}


	// Update is called once per frame
	void Update ()
    {
        infectionAgent.SetDestination(FindClosestHuman());
	}
}
