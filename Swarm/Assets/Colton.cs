
using UnityEngine;

public class Colton : MonoBehaviour {

    public Rigidbody God;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("w"))
        {
            God.AddForce(5000 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            God.AddForce(-5000 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            God.AddForce(0, 0, 5000 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            God.AddForce(0, 0, -5000 * Time.deltaTime);
        }
        if (Input.GetKey("space"))
        {
            God.AddForce(0, 5000 * Time.deltaTime, 0);
        }
    }
}
