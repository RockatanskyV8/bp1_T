using UnityEngine;
using System.Collections;

public class ObjectPhysics : MonoBehaviour 
{
	public Rigidbody rb;
	public Rigidbody par;
	Vector3 movement = new Vector3(0f, 0f, 0f);
	Vector3 normal = new Vector3(0f, 0f, 0f);
	float speed = 1000f;
	float velocidade = 0f;
	bool pulo = false;
	bool isgrounded = false;


	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 1000;
		rb.AddTorque(0, speed, 0);
		StartCoroutine(PerdaVelocidade());
	}

	void Update () 
	{
		Controller();

		//rb.AddTorque(-rb.angularVelocity * Time.deltaTime);

		//rb.AddForce(n - p);
		//transform.Rotate((n - p) * Time.deltaTime);

		if (rb.angularVelocity.y > 1f)
			transform.position += movement * 100 * Time.deltaTime;

		if (pulo)
		{
			rb.velocity = rb.velocity + new Vector3(0, 150, 0) * Time.deltaTime;
			pulo = false;
		}

		//movement = movement * Time.deltaTime;

		Debug.DrawLine(Vector3.zero, normal, Color.red);
	}

	IEnumerator PerdaVelocidade()
	{
		while (true)
		{
			movement.x = movement.x * 0.9f;
			movement.z = movement.z * 0.9f;
			movement.y = movement.y * 0.9f;
			yield return new WaitForSeconds(0.1f);
		}
	}

	void Controller()
	{
		if (isgrounded)
		{
			if (Input.GetKey(KeyCode.RightArrow))
			{
				movement.x += 0.15f * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				movement.x += -0.15f * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				movement.z += 0.15f * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				movement.z += -0.15f * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.Space))
			{
				if (isgrounded)
					pulo = true;
			}

			velocidade = Mathf.Pow(movement.x, 2) + Mathf.Pow(movement.z, 2);

			if (Mathf.Sqrt(velocidade) > 1.0f)
			{
				movement.x = movement.x / velocidade;
				movement.z = movement.z / velocidade;
			}

		}
	}

/*	void OnCollisionStay(Collision hit)
	{
		normal = hit.contacts[0].normal;        
	}

	void OnCollisionEnter(Collision hit)
	{
		if(hit.gameObject.tag == "floor")
		{
			isgrounded = true;
		}
	}

	void OnCollisionExit(Collision hit)
	{
		if(hit.gameObject.tag == "floor")
		{
			isgrounded = false;
		}
	}*/
}

