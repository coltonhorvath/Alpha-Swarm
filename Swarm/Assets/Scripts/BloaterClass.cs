using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloaterClass : InfectionController {

	public int health = 5;
	public float speed;
	public float spawnChance;

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
