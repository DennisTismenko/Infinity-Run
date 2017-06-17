using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {

	public ParticleSystem muzzleFlash;

	public void PlayMuzzleFlash(){
		ParticleSystem muzzleFlashClone = (ParticleSystem)Instantiate (muzzleFlash, transform.position, transform.rotation);
		Destroy (muzzleFlashClone.gameObject, 0.09f);
	}
}