using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moveTowards = new Vector3 (0, 0, speed);

		this.gameObject.transform.Translate (-moveTowards * Time.deltaTime, Space.World);
		this.gameObject.transform.Rotate (150f *Time.deltaTime, 100f *Time.deltaTime, 100f * Time.deltaTime, Space.World);
	}
}
