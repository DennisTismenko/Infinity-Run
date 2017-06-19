using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

	float health;
	DestroyByCollisionSmallExplosion smallExplosion;
	DestroyByCollisionBigExplosion bigExplosion;


	// Use this for initialization
	void Start () {
		smallExplosion = GetComponent<DestroyByCollisionSmallExplosion> ();
		bigExplosion = GetComponent<DestroyByCollisionBigExplosion> ();
		health = 1000;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "PlayerShot") {
			smallExplosion.playHitEffect (col.transform.localPosition);
			Destroy (col.gameObject);
			takeDamage (10);

		}
	}

	void takeDamage (float amount){
		health -= amount;
        if (health <= 0)
        {
            kill();
        }
	}

	void kill(){
		bigExplosion.PlayBigExplosion ();
		Destroy (this.gameObject);

	}
}
