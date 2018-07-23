using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VaccinatorControlller : MonoBehaviour {

    float health = 5f;
    float speed = 12.5f;
    float runDistance = 20f;
    float chaseDistance = 23f;
    float fireRate = 1f;
    float fireCountdown = 0f;
    float range = 100f;
    string infectionTag = "Infection";
    private NavMeshAgent vaccineAgent;
    public GameObject bulletPrefab;
    private Transform targetInfection;
    public Transform firePoint;
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
            Debug.Log("In range of " + infection.gameObject);
            targetInfection = nearestInfection.transform;
            vaccineAgent.SetDestination(targetInfection.transform.position);
        }
    }

    void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();

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
