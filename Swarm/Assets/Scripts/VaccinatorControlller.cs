using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VaccinatorControlller : MonoBehaviour {

    public float health = 5f;
    public float speed = 12.5f;
    //float runDistance = 20f;
    //float chaseDistance = 23f;

    public float fireRate = 1f;
    public float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float range = 100f;
    string infectionTag = "Infection";
    private NavMeshAgent vaccineAgent;
    private Transform targetInfection;
    public Rigidbody infection;

	void Start () {
        vaccineAgent = GetComponent<NavMeshAgent>();
        vaccineAgent.speed = speed;
	}

    void Update()
    {
        UpdateTarget();
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] infections = GameObject.FindGameObjectsWithTag(infectionTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestInfection = null;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject infection in infections)
        {
            float directionToInfection = Vector3.Distance(transform.position, infection.transform.position);
            if (directionToInfection < shortestDistance)
            {
                shortestDistance = directionToInfection;
                nearestInfection = infection;
            }
            else
            {
                targetInfection = null;
            }
        }

        if (nearestInfection != null && shortestDistance <= range)
        {
            targetInfection = nearestInfection.transform;
            vaccineAgent.SetDestination(targetInfection.position);
        }
        else
        {
            targetInfection = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(targetInfection);
    }

    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Infection")
        {
            //Debug.Log("hit");
            health = health - 1;
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(infection, transform.position, transform.rotation);
            }
        }
    }
}
