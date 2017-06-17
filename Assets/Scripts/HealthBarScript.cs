using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
	
	//public UIProgressBar bar;
	//public UILabel label;
	GameObject player;
	Player playerScript;


	/*
	void Start()
	{
		player = GameObject.Find ("Player");
		playerScript = player.GetComponent<Player> ();

		if (this.bar == null)
			this.bar = this.GetComponent<UIProgressBar>();
	}

	void Update(){
		UpdateLabel ();
	}
	

	
	public void UpdateLabel()
	{
		if (this.label != null && this.bar != null) {
			this.bar.value = (playerScript.health / playerScript.maxHp);
			this.label.text = (playerScript.health).ToString ("0");
		}

	}
*/
}
