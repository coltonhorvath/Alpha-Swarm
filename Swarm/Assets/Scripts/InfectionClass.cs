using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionClass : InfectionController {

    public float health = 3f;
    string Bullet = "Bullet";

    void Update()
    {
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
	
}
