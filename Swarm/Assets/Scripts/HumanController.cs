using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour {

    int health = 10;
    float speed = 10f;
    private NavMeshAgent humanAgent;
    public float InfectionDistanceRun = 10.0f;
    public Rigidbody prefabInfection;

    void Start()
    {
        humanAgent = GetComponent<NavMeshAgent>();
        humanAgent.speed = speed;
    }

    void Update()
    {
        RunAway();
    }

    void RunAway()
    {
        GameObject[] Infections = GameObject.FindGameObjectsWithTag("Infection");
        foreach (GameObject infection in Infections)
        {
            float distance = Vector3.Distance(transform.position, infection.transform.position);
            if (distance < InfectionDistanceRun)
            {
                Vector3 DirToPlayer = transform.position - infection.transform.position;
                Vector3 newPos = transform.position + DirToPlayer;
                humanAgent.SetDestination(newPos);
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
                Instantiate(prefabInfection, transform.position, transform.rotation);
            }
        }
    }
}
