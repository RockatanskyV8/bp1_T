using UnityEngine;
using System.Collections;

public class AngleTest : MonoBehaviour 
{

	public Rigidbody go;

	void Start()
	{
		transform.position = go.position;
	}

	void FixedUpdate()
	{
		Vector3 forward = Quaternion.FromToRotation(transform.rotation * Vector3.up, Quaternion.identity * Vector3.up) * go.velocity;
		Debug.DrawRay (go.position, (forward), Color.green);
	}

}