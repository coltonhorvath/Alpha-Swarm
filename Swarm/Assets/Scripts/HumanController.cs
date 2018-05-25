using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour {

    public Rigidbody prefabInfection;
    public Transform infectLocation;


    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Infection")
        {
            Destroy(gameObject);
            Instantiate(prefabInfection, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name + " was triggered by " + other.gameObject.name);
    }

    void Start()
    {
        Debug.Log(transform.position);
    }

}
