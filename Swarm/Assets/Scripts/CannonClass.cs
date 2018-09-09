using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonClass : MonoBehaviour {

	// public int ammo;
	// public float timer;
	// public int reloadTimer;
	private float fireTimer;
    public float fireRatePerSecond;
	public float closeRange;
	public float farRange;
	public float mortarForce;
	private string infectionTag = "Infection";
	public GameObject shellPrefab;
	private Transform targetInfection;
	public Transform partToRotate;
	public Transform firePoint;

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, closeRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, farRange);
    }
	void Start () {
		
	}

	void FixedUpdate () 
	{
		UpdateTarget();
		fireTimer -= Time.deltaTime;
		Debug.Log(fireTimer);
		if (fireTimer <= 0f)
        {
            Shoot();
			Debug.Log("shooting now");
            fireTimer = fireRatePerSecond;
        }
	}

	void UpdateTarget()
	{
		GameObject[] infections = GameObject.FindGameObjectsWithTag(infectionTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestInfection = null;
        Vector3 currentPosition = this.transform.position;

        foreach (GameObject infection in infections)
        {
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

        if(nearestInfection != null && shortestDistance >= closeRange && shortestDistance <= farRange)
        {
			//Debug.Log("infection found");
            targetInfection = nearestInfection.transform;
			Vector3 directionToRotate = targetInfection.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation(directionToRotate);
			Vector3 rotation = lookRotation.eulerAngles;
			partToRotate.rotation = lookRotation;
        }

        else
        {
            targetInfection = null;
        }
	}

	public void Shoot()
	{
		GameObject shellGO = (GameObject)Instantiate(shellPrefab, firePoint.position, shellPrefab.transform.rotation);
		Bullet shell = shellGO.GetComponent<Bullet>();
		shellGO.GetComponent<Rigidbody>().AddRelativeForce(0,0, mortarForce, ForceMode.Impulse);
		Debug.Log("Instantiat");
		
		// Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 6f);

		// foreach (Collider target in hitColliders)
		// {
		// 	//Needs workd done here.
		// }
	}
}
