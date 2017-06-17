using UnityEngine;
using System.Collections;

public class DestroyByCollisionSmallExplosion : MonoBehaviour {
	
	public ParticleSystem trailsWhite;
	public ParticleSystem sparks;
	public ParticleSystem fireball;
	public ParticleSystem shower;
	public ParticleSystem smallFireball;


	public void playSmallExplosion(){
		//Explosion effects
		ParticleSystem trailsWhiteClone = (ParticleSystem)Instantiate (trailsWhite, transform.position, transform.rotation);
		ParticleSystem sparksClone = (ParticleSystem)Instantiate (sparks, transform.position, transform.rotation);
		ParticleSystem fireballClone = (ParticleSystem)Instantiate (fireball, transform.position, transform.rotation);


		//Destroys the explosion effects one second after they spawn
		Destroy (trailsWhiteClone.gameObject, 1);
		Destroy (sparksClone.gameObject, 1);
		Destroy (fireballClone.gameObject, 1);
	}

	public void playSmallExplosion(Transform position){
		//Explosion effects
		ParticleSystem trailsWhiteClone = (ParticleSystem)Instantiate (trailsWhite, transform.position, transform.rotation);
		ParticleSystem sparksClone = (ParticleSystem)Instantiate (sparks, transform.position, transform.rotation);
		ParticleSystem fireballClone = (ParticleSystem)Instantiate (fireball, transform.position, transform.rotation);


		//Destroys the explosion effects one second after they spawn
		Destroy (trailsWhiteClone.gameObject, 1);
		Destroy (sparksClone.gameObject, 1);
		Destroy (fireballClone.gameObject, 1);
	}

	public void playHitEffect(){

		ParticleSystem smallFireballClone = (ParticleSystem)Instantiate (smallFireball, transform.position, transform.rotation);
		ParticleSystem showerClone = (ParticleSystem)Instantiate (shower, transform.position, transform.rotation);

		Destroy (smallFireballClone.gameObject, 1);
		Destroy (showerClone.gameObject, 1);

	}

	public void playHitEffect(Vector3 position){

		ParticleSystem smallFireballClone = (ParticleSystem)Instantiate (smallFireball, position, transform.rotation);
		ParticleSystem showerClone = (ParticleSystem)Instantiate (shower, position, transform.rotation);

		Destroy (smallFireballClone.gameObject, 1);
		Destroy (showerClone.gameObject, 1);

	}

}
