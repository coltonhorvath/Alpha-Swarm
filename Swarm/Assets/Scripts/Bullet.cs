using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public GameObject impactEffect;
    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitInfection();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitInfection()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(gameObject);
    }
}
