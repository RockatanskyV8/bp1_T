using UnityEngine;
using System.Collections;

public class Direcao : MonoBehaviour {

	private LineRenderer lr;
	private float counter;
	private float dist;

	public Transform Origin;
	public Transform Destination;

	public float linedrawspeed = 6f;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer>();
		lr.SetPosition (0, Origin.position);
		lr.SetWidth(0.2F, 0.2F);

		dist = Vector3.Distance (Origin.position, Destination.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(counter < dist){

			counter += .1f / linedrawspeed;

			float x = Mathf.Lerp(0, dist, counter);

			Vector3 pointA = Origin.position;
			Vector3 pointB = Destination.position;

			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;

			lr.SetPosition (1, pointAlongLine);

		}
	}
}
