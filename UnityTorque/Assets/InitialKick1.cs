using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class InitialKick1 : MonoBehaviour {

//	public Vector3 initialKick = new Vector3 (4f, 0, 0);
	Vector3 Ti 	= new Vector3(0f, 0f, 1f);
	Vector3 iT 	= new Vector3(1f, 0f, 0f);

	private Rigidbody rb;
	//public float torqueTime;

	Vector3 T;

// Use this for initialization
	void OnEnable () 
	{
		rb = GetComponent<Rigidbody> ();
		Vector3 x = Vector3.Cross(Ti.normalized, iT.normalized);
		float theta = Mathf.Asin(x.magnitude);
		Vector3 w = x.normalized * theta / Time.fixedDeltaTime;

		Quaternion q = transform.rotation * rb.inertiaTensorRotation;
		T = q * Vector3.Scale(rb.inertiaTensor, (Quaternion.Inverse(q) * w));
		rb.angularVelocity = T;

//		Ve = T.magnitude;
	}

/*	void FixedUpdate()
	{
		StopR ();
	}*/

	void StopR()
	{
		float SlowDownPerSecond = 2f;
		if(rb.angularVelocity.magnitude > SlowDownPerSecond * Time.deltaTime){
			rb.AddTorque(-rb.angularVelocity.normalized * SlowDownPerSecond, ForceMode.Force);
		}
		/*else {
			rb.angularVelocity = Vector3.zero;
		}*/
	}
}
