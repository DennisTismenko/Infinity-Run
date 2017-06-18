using UnityEngine;
using System.Collections;

public class ObstacleControl: MonoBehaviour {

	private Rigidbody obstacle;
    private Vector3 movement;



    public float speed;
	// Use this for initialization
	void Start () {
		obstacle = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector3 (0, 0, speed);
		obstacle.AddForce (-movement * Time.deltaTime, ForceMode.Acceleration);
		obstacle.AddTorque (1000f, 250f, 250f);
	}
}
