using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
	Rigidbody rb;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody> ();
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
