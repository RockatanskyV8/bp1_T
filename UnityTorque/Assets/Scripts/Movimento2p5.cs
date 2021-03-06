﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Movimento2p5 : MonoBehaviour {
	public Rigidbody rb;
	void Start(){
		rb = GetComponent <Rigidbody> ();
	}
	void FixedUpdate () {
		Movimento();
	}

	void Movimento()
	{
		if (Input.GetAxis("Vertical") > 0)
		{
			rb.AddForce(-Vector3.forward * 10);
		}

		if (Input.GetAxis("Vertical") < 0)
		{
			rb.AddForce(Vector3.forward * 10);
		}

		if (Input.GetAxis("Horizontal") > 0)
		{
			rb.AddForce(-Vector3.right * 10);
		}

		if (Input.GetAxis("Horizontal") < 0)
		{
			rb.AddForce(Vector3.right * 10);
		}
	}
}