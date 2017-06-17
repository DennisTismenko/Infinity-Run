using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject asteroid;
	public float asteroidSpawnTime;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnAsteroid", asteroidSpawnTime, asteroidSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (!Player.alive) {
			CancelInvoke ();
		}
	}

	void SpawnAsteroid(){

		float ranX = Random.Range (-10, 12);
		float ranY = Random.Range (-4, 6);

		Vector3 position = new Vector3 (ranX, ranY, 500);

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		//Quaternion rotation = new Quaternion;
		Instantiate(asteroid, position, Random.rotation);
	}

}
