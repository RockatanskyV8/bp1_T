using UnityEngine;
using System.Collections;

public class Colider : MonoBehaviour {

	private Rigidbody rb;
	public float Damage = 0;

	void Start()
	{
		rb = GetComponent <Rigidbody> ();
	}
		
	void OnCollisionEnter(Collision c)
	{
		Vector3 normal = c.contacts[0].normal;
		Vector3 vel = rb.velocity;

		if (c.gameObject.name == "Blade1" || c.gameObject.name == "Blade2") 
		{
			rb.AddForce (normal.normalized * vel.magnitude, ForceMode.Impulse);
			Damage += vel.magnitude;
		}
	}
}