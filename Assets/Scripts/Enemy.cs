using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private int health;
	//public GameObject player;
	private DestroyByCollisionSmallExplosion sAnimation;
	private DestroyByCollisionBigExplosion bAnimation;

	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "Asteroid" || this.gameObject.name == "Asteroid(Clone)") {
			health = 20;
		} else if (this.gameObject.name == "EnemyShip" || this.gameObject.name == "EnemyShip(Clone)") {
			health = 100;
		} else {
			health = 10;
		}

		sAnimation = this.gameObject.GetComponent<DestroyByCollisionSmallExplosion>();
		bAnimation = this.gameObject.GetComponent<DestroyByCollisionBigExplosion> ();
			
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			destruct ();
		}
	}

	public void takeDamage (int amount){
		health -= amount;
	}

	void destruct (){

		//this.gameObject.GetComponent<DestroyByCollisionSmallExplosion> ().playSmallExplosion();
		if (this.gameObject.name == "Mine" || this.gameObject.name == "Mine(Clone)")
		{
			bAnimation.PlayBigExplosion();
		} else {
			sAnimation.playSmallExplosion();
		}
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider col){
		if (this.gameObject.name != "Mine" && this.gameObject.name != "Mine(Clone)" && this.gameObject.name != "sFlare" && this.gameObject.name != "sFlare(Clone)") {
			if (col.gameObject.tag == "PlayerShot"){
				Destroy (col.gameObject);
				sAnimation.playHitEffect ();
				takeDamage (10 * Player.damageMultiplier);
			}
		}

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player") {
			destruct ();
		}
	}
}
