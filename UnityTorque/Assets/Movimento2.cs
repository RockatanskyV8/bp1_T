using UnityEngine;
using System.Collections;

public class Movimento2 : MonoBehaviour {
	public Rigidbody rb;
	ForcaScript forca;

	Vector3 Ti 	= new Vector3(0f, 0f, 1f);
	Vector3 iT 	= new Vector3(1f, 0f, 0f);

	public bool onNoff;

	float F;

	float angleX;
	float angleZ;

	float Xang;
	float Zang;
//	Vector3 Incl;

	Vector3 x;
	float theta;
	Vector3 w;

	Quaternion q;
	Vector3 T;

	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody>();
		forca = GetComponent<ForcaScript>();

		x = Vector3.Cross(Ti.normalized, iT.normalized);
		theta = Mathf.Asin(x.magnitude);
		w = x.normalized * theta / Time.fixedDeltaTime;

		q = transform.rotation * rb.inertiaTensorRotation;
		T = q * Vector3.Scale(rb.inertiaTensor, (Quaternion.Inverse(q) * w));



		angleX = 0;
		angleZ = 0;

		F = 100f;
	}

	void Start () {
		//StartCoroutine ("Instab");

	}

	// Update is called once per frame
	void Update () {
		Movimento();
		InclinP ();
		print (Zang);
	}

	void FixedUpdate()
	{
		rb.AddTorque (T * F, ForceMode.Acceleration);
		//Inclinacao ();
	}

	void Movimento()
	{
		if (Input.GetAxis("Vertical") > 0)
		{
			rb.AddForce(Vector3.forward * 10);
		}

		if (Input.GetAxis("Vertical") < 0)
		{
			rb.AddForce(-Vector3.forward * 10);
		}

		if (Input.GetAxis("Horizontal") > 0)
		{
			rb.AddForce(Vector3.right * 10);
		}

		if (Input.GetAxis("Horizontal") < 0)
		{
			rb.AddForce(-Vector3.right * 10);
		}
	}

	void InclinP()
	{
		//transform.eulerAngles = Incl;

		if (onNoff == true) {
			transform.eulerAngles = new Vector3 (angleX, transform.eulerAngles.y, angleZ);
		} else {
			Xang = transform.eulerAngles.x;
			Zang = transform.eulerAngles.z;

			InclinS (Xang, Zang);
			//PararTorque (Xang, Zang);
		}
	}

	void InclinS(float a, float b)
	{
		if (a != 0 && b != 0) {
			angleX = a;
			angleZ = b;
		}
	}

	void PararTorque(float a, float b)
	{
		if((a > 52 && a < 53) || (b > 52 && b < 53))
		{
			F = 0f;

		}
	}
}