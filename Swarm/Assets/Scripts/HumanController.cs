using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour {

    public NavMeshAgent humanAgent;
    public GameObject Infection;
    public float InfectionDistanceRun = 10.0f;

    /*private Vector3 FindClosestInfection()
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
    }*/

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
        humanAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Infection.transform.position);

        Debug.Log("Distance: " + distance);

        if (distance < InfectionDistanceRun)
        {
            Vector3 DirToPlayer = transform.position - Infection.transform.position;
            Vector3 newPos = transform.position + DirToPlayer;
            humanAgent.SetDestination(newPos);
        }

    }
}
