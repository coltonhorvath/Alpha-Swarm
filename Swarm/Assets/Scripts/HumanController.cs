using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour {

    NavMeshAgent humanAgent;

    private Vector3 FindClosestInfection()
    {
        GameObject[] Humans = GameObject.FindGameObjectsWithTag("Infection");

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
        humanAgent.transform.position = FindClosestInfection();
        
    }
}
