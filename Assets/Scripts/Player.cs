using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float maxHp;
	public float health;
	public float armour;

	public static bool isAlive;
	public static int damageMultiplier;
	public static int scoreMultiplier;
	public bool godMode;
	private bool upgraded;
	public static bool hasNuke;

	// Use this for initialization
	void Start () {
		
		hasNuke = false;
		damageMultiplier = 1;
		scoreMultiplier = 1;
		isAlive = true;
		//maxHp = 100f;
		health = maxHp;
		//armour = 10f;
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0 && isAlive) {
			killPlayer ();
		}

		if (Input.GetKey(KeyCode.K)){
			killPlayer();
		}
	}


	void killPlayer ()
	{

		DestroyEnemies ();
		DestroyPickups ();
		armour = 0;
		health = 0;
		isAlive = false;
		DisableDraw ();
		this.gameObject.GetComponent<DestroyByCollisionBigExplosion> ().Invoke ("PlayBigExplosion", 0);
		Time.timeScale = 0.1F;


	}



	public void TakeDamage (float amount)
	{
		if (!godMode) {
			if (armour > 0) {
				armour -= amount;
				if (armour < 0) {
					health += armour;
					armour = 0;
				}
			} else {
				health -= amount;
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.layer == 8) {
			TakeDamage (30);
		}
	}

	void OnTriggerEnter(Collider col){
		Destroy (col.gameObject);
	}
		

	void DisableDraw(){
		GameObject[] draw = GameObject.FindGameObjectsWithTag ("Render");
		for (int i = 0; i < draw.Length; i++) {
			draw [i].gameObject.SetActive (false);
		}
	}

	public void DestroyEnemies(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < enemies.Length; i++) {
			enemies [i].SetActive (false);
		}
	}

	void DestroyPickups(){
		GameObject[] pickups = GameObject.FindGameObjectsWithTag ("PickUp");
		for (int i = 0; i < pickups.Length; i++) {
			pickups [i].SetActive (false);
		}
	}			
}
