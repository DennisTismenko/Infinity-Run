using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

    public Slider healthBar;

	GameObject player;
	Player playerScript;


	
	void Start()
	{
		player = GameObject.Find ("Player");
		playerScript = player.GetComponent<Player>();
        
        

		
	}

	void Update(){
		
	}
	


}
