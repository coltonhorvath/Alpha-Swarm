using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BloaterClass : InfectionController {

	public int health = 5;
	public float speed = 5f;
	public float spawnChance;
    NavMeshAgent bloaterAgent;

    void Start()
    {
        bloaterAgent.speed = speed;
    }
    
	public void damageTaken (int damage)
    {
        health -= damage;
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
