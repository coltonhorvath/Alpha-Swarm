using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour {

    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Infection")
        {
            gameObject.tag = "Infection";
            Debug.Log("Hit by" + colInfo.gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(gameObject.name + " was triggered by " + other.gameObject.name);
    }

    void Start()
    {
        // Debug.Log("start test");
    }

}
