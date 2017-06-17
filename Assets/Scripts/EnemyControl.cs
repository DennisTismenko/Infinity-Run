using UnityEngine;
using System.Collections;

public class EnemyControl: MonoBehaviour {

	private Rigidbody obstacle;
	private SpawnManager spawn;


	public float speed;
	// Use this for initialization
	void Start () {
		

		obstacle = GetComponent<Rigidbody>();
		GameObject spawner = GameObject.Find ("SpawnManager");
		spawn = spawner.GetComponent<SpawnManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 movement = new Vector3 (0, 0, speed);
		obstacle.AddForce (-movement * Time.deltaTime, ForceMode.Acceleration);
		obstacle.AddTorque (1000f, 250f, 250f);
	}
}
