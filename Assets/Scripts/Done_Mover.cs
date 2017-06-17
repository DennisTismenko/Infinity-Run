using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
	Rigidbody rb;
	Vector3 cursorPosition;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody> ();
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void Update(){
		
	}
	 
}
