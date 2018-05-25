using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform Human;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(Human.position, this.transform.position) < 40)
        {
            Vector3 direction = Human.position - this.transform.position;
        }
    }
}
