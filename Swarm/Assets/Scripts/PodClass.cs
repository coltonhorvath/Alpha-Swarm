using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodClass : BloaterClass {

	public bool isGrounded;
	public Vector3 jump;
	public float jumpForce = 2.0f;
	public float jumpRadius = 5f;
	Rigidbody self;
	new void Start()
	{
		base.Start();
		self = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
	}
	void OnCollisionStay(Collision colinfo)
	{
		Debug.Log(colinfo.gameObject.name);
		if (colinfo.gameObject.name == "Ground")
		{
			isGrounded = true;
		}

	}

	new void Update()
	{
		base.Update();
		if (isGrounded)
		{
			self.AddForce(jump * jumpForce, ForceMode.Impulse);
		}
	}
	

}
