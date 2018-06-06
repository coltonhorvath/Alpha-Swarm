using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour {

    NavMeshAgent humanAgent;
    Vector3 runAway;

    private Vector3 FindClosestInfection()
    {
        GameObject[] Infections = GameObject.FindGameObjectsWithTag("Infection");

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject Infection in Infections)
        {
            Vector3 directionToTarget = Infection.transform.position - currentPosition;

            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = Infection.transform;
            }
        }

        return bestTarget.position;
    }

    public Rigidbody prefabInfection;
    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Infection")
        {
            Destroy(gameObject);
            Instantiate(prefabInfection, transform.position, transform.rotation);
        }
    }

    void Start()
    {
        humanAgent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //work needs done in update to make Humans work.
        humanAgent.Move(transform.position.normalized - prefabInfection.transform.position.normalized);

    }
}
