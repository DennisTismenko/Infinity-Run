using UnityEngine;
using System.Collections;

public class DestroyByCollisionBigExplosion : MonoBehaviour {
	
	public ParticleSystem trailsBlack;
	public ParticleSystem trailsWhite;
	public ParticleSystem shower;
	public ParticleSystem fireball;
	public ParticleSystem dust;
	public ParticleSystem shockwave;
	public ParticleSystem smokeBlack;

	

	public void PlayBigExplosion(){
			//Explosion effects
			ParticleSystem trailsBlackClone = (ParticleSystem)Instantiate (trailsBlack, transform.position, transform.rotation);
			ParticleSystem trailsWhiteClone = (ParticleSystem)Instantiate (trailsWhite, transform.position, transform.rotation);
			ParticleSystem showerClone = (ParticleSystem)Instantiate (shower, transform.position, transform.rotation);
			ParticleSystem fireballClone = (ParticleSystem)Instantiate (fireball, transform.position, transform.rotation);
			ParticleSystem dustClone = (ParticleSystem)Instantiate (dust, transform.position, transform.rotation);
			ParticleSystem shockwaveClone = (ParticleSystem)Instantiate (shockwave, transform.position, transform.rotation);
			ParticleSystem smokeBlackClone = (ParticleSystem)Instantiate (smokeBlack, transform.position, transform.rotation);

			//Destroys the explosion effects one second after they spawn
			Destroy (trailsBlackClone.gameObject, 1);
			Destroy (trailsWhiteClone.gameObject, 1);
			Destroy (showerClone.gameObject, 1);
			Destroy (fireballClone.gameObject, 1);
			Destroy (dustClone.gameObject, 1);
			Destroy (shockwaveClone.gameObject, 1);
			Destroy (smokeBlackClone.gameObject, 1);

	}

}
