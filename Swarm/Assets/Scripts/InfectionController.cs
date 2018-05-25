using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InfectionController : MonoBehaviour {

    public float searchRadius = 20f;
    NavMeshAgent infectionAgent;
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

    /*void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Human")
        {
            Debug.Log("Hit Human.");
        }
    }*/

    void Start ()
    {
        infectionAgent = this.GetComponent<NavMeshAgent>();
        infectionAgent.autoBraking = false;
	}

	void Update ()
    {
            infectionAgent.SetDestination(FindClosestHuman());
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}
