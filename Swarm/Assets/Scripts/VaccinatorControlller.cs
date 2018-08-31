using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VaccinatorControlller : MonoBehaviour {

    public float health = 5f;
    public float timer;
    public float speed = 12.5f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;
    public float range;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private Transform targetInfection;
    private NavMeshAgent vaccineAgent;
    public Rigidbody infection;
    string infectionTag = "Infection";

	void Start () {
        vaccineAgent = GetComponent<NavMeshAgent>();
        vaccineAgent.speed = speed;
	}

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void FixedUpdate()
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
        //targetOffset = new Vector3(10,0,10);

        foreach (GameObject infection in infections)
        {
            //Vector3 directionToInfection = infection.transform.position - currentPosition;
            float distanceToTarget = Vector3.Distance(transform.position, infection.transform.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestInfection = infection;
            }
            else
            {
                targetInfection = null;
            }
        }

        if (nearestInfection != null && shortestDistance <= range)
        {
            //Vector3 offset = new Vector3()
            targetInfection = nearestInfection.transform;
            vaccineAgent.destination = targetInfection.transform.position;
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

    void OnCollisionStay(Collision stayInfo)
    {
        if(stayInfo.collider.tag == "Infection") SufferInfection();
    }
    
    void SufferInfection()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            health -= 1f;
            timer = 0;
        }
        if (health <= 0) Die();
    }

    void Die()
    {
        if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(infection, transform.position, transform.rotation);
            }
    }
}
