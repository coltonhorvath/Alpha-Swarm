using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour {

    private NavMeshAgent humanAgent;
    public float InfectionDistanceRun = 10.0f;

    private void RunAway()
    {
        GameObject[] Infections = GameObject.FindGameObjectsWithTag("Infection");
        foreach (GameObject infection in Infections)
        {
            float distance = Vector3.Distance(transform.position, infection.transform.position);

            Debug.Log("Distance: " + distance);

            if (distance < InfectionDistanceRun)
            {
                Vector3 DirToPlayer = transform.position - infection.transform.position;
                Vector3 newPos = transform.position + DirToPlayer;
                humanAgent.SetDestination(newPos);
            }
        }
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
        humanAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        RunAway();
        /*float distance = Vector3.Distance(transform.position, Infection.transform.position);

        Debug.Log("Distance: " + distance);

        if (distance < InfectionDistanceRun)
        {
            Vector3 DirToPlayer = transform.position - Infection.transform.position;
            Vector3 newPos = transform.position + DirToPlayer;
            humanAgent.SetDestination(newPos);
        }*/

    }
}
