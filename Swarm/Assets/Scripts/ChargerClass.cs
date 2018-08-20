using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class ChargerClass : MonoBehaviour {
 	public int health = 10;
    public float speed = 15f;
    public float range = 20000f;
	public float chargeRange = 25f;
	public int chargeForce;
	public float chargeTimer = 2.5f;
	public float chargeRecharge = 10f;
	bool chargeReady = true;
    float spawnChance = 50;
    private Transform targetHuman;
    NavMeshAgent ChargerAgent;
	Rigidbody chargerRigidBody;
    public string humanTag = "Human";
    public string vaccineTag = "Vaccine";
    

     void Start ()
    {
        ChargerAgent = GetComponent<NavMeshAgent>();
        chargerRigidBody = GetComponent<Rigidbody>();
        ChargerAgent.autoBraking = false;
        ChargerAgent.speed = speed;
 
        InvokeRepeating("Test", 0f, 1f);
 	}
    void FixedUpdate()
    {
        UpdateTarget();
    }
    void Update()
    {
        
    }
	void Test()
	{
		
	}
    void UpdateTarget()
    {
        GameObject[] Humans = GameObject.FindGameObjectsWithTag(humanTag);
        GameObject[] Vaccines = GameObject.FindGameObjectsWithTag(vaccineTag);
        GameObject[] HV = Humans.Concat(Vaccines).ToArray();
 
        float shortestDistance = Mathf.Infinity;
        GameObject nearestHuman = null;
        Vector3 currentPosition = this.transform.position;
 
        foreach (GameObject huvacs in HV)
        {
            Vector3 directionToTarget = huvacs.transform.position - currentPosition;
 
            float distanceToTarget = directionToTarget.sqrMagnitude;
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestHuman = huvacs;
            }
            else
            {
                targetHuman = null;
            }
        }
 
        if (nearestHuman != null && shortestDistance <= range)
        {
            targetHuman = nearestHuman.transform;
            ChargerAgent.SetDestination(targetHuman.transform.position);
            Vector3 toTarget = (targetHuman.transform.position - this.transform.position).normalized;
			if (shortestDistance <= chargeRange)
			{
                if(chargeReady == true)
                {
                    chargeTimer -= Time.deltaTime;
                    if (chargeTimer <= 0)
                    {
                    Debug.Log("Charging at human now.");
                    chargerRigidBody.AddForce(toTarget * chargeForce * Time.deltaTime, ForceMode.Impulse);
                    chargeReady = false;
                    chargeTimer = 2.5f;
                    }
                }
				 //Implement slowdown;
            }
        }
        if(chargeReady == false)
        {
            chargeRecharge -= Time.deltaTime;
            if(chargeRecharge <= 0)
            {
                chargeReady = true;
                chargeRecharge = 10f;
            }
        }
    }
    public void damageTaken (int damage)
    {
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
             Die();
        }
     }
     
    void Die()
    {
        Destroy(gameObject);
    }
 }