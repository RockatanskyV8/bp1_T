using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Movimento3 : MonoBehaviour {
	
	private Matrix4x4 __localI;
	private Vector3 _globalL;

	private Rigidbody rigidBody;
	private Colider Colli;
	private string Text;


	void Start() {
		rigidBody = GetComponent <Rigidbody> ();
		Colli = GetComponent <Colider> ();
		__localI = Matrix4x4.Scale (rigidBody.inertiaTensor);
		_globalL = rigidBody.angularVelocity;
	}

	void FixedUpdate() {
		CalculateRotation ();

	}

	void OnGUI(){
		if (rigidBody.name == "Blade1") {
			GUI.Label (new Rect (10, 10, 100, 20), Text);
		} else if (rigidBody.name == "Blade2"){
			GUI.Label (new Rect (650, 10, 100, 20), Text);
		}
	}

	void CalculateRotation ()
	{
		Matrix4x4 __rotationMatrix = Matrix4x4.TRS (Vector3.zero, transform.rotation, Vector3.one);
		Matrix4x4 __globalI =  __rotationMatrix * __localI * __rotationMatrix.inverse;


		Vector3 _globalW = __globalI.inverse * _globalL;
		Vector3 _globalRotationAxis = 	_globalW.normalized;

		float speed = 					_globalW.magnitude;
		float degreesThisFrame =(speed * Time.deltaTime * Mathf.Rad2Deg) - Time.time - Colli.Damage;

		if(degreesThisFrame >= 0)
		{
			transform.RotateAround (transform.position, _globalRotationAxis, degreesThisFrame);
		}

		Text = degreesThisFrame.ToString ();

	}
}