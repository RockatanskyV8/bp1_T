using UnityEngine;
using System.Collections;

public class ForcaScript : MonoBehaviour {

	float F = 100f;
	float B  = 0.05f;

	/*
	float angleX  = Mathf.Clamp(angleX, B, Bi);
	float angleZ  = Mathf.Clamp(angleZ, Bi, B);

	float Bi = (B) * (-1);
	*/

	public float Forca {
		get{return F;}
		set{F = value;}
	}

	public float Equilibrio{
		get{return B;}
		set{B = value;}
	}
}

/*public float EQ1{
		get{return angleX;}
		set{angleX = value;}
	}
	public float EQ2{
		get{return angleZ;}
		set{angleZ = value;}
	}

	
	public float E2{
		get{return Bi;}
		set{Bi = value;}
	}*/
