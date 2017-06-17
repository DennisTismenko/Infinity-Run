using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float maxHp;
	public float health;
	public float armour;

	//GUI Text Elements
	//public Text healthText;
	//public Text armourText;
	//public Text powerUp;
	//public Text timer;


	public static bool isAlive;
	public static int damageMultiplier;
	public static int scoreMultiplier;
	public bool godMode;
	private bool upgraded;
	public static bool hasNuke;

	private string armourUp = "Armor Up";
	private string healthUp = "Health Up";
	private string damageUp = "Damage x2";
	private string fireRateActive = "Fire Rate x2";
	private string homingMissile = "Homing Missiles";
	private string nukeActive = "Nuke";
	private string scoreUp = "Score x2";
	private string speedUp = "Speed Up";
	private string timeSlow = "Slow Time";
	private float powerUpTimer;

	//Loads the resources for the Health GUI Texture
	Rect healthRect;
	float healthSize;
	Texture healthTexture;
	//Loads the resources for the Armor GUI Texture
	Rect armorRect;
	float armorSize;
	Texture armorTexture;
	

	public GameObject basicModel;
	public GameObject armourModel;

	// Use this for initialization
	void Start () {

		//Initializes and sets-up components for the Health GUI Texture
		healthSize = Screen.width * 0.05f;
		healthTexture = Resources.Load ("Textures/health") as Texture;
		healthRect = new Rect ((Screen.width-75) - healthSize/2, (Screen.height-75) -healthSize/2, healthSize, healthSize);

		//Initializes and sets-up components for the Armor GUI Texture
		armorSize = Screen.width * 0.06f;
		armorTexture = Resources.Load ("Textures/armor123") as Texture;
		armorRect = new Rect ((Screen.width - 175) - armorSize / 2, (Screen.height - 75) - armorSize / 2, armorSize, armorSize);

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

//		if (armour > 0 && upgraded == false) {
//			UpgradeModel ();
//		}
//		if (armour == 0 && upgraded == true) {
//			DowngradeModel ();
//		}

	

	}

	void OnGUI(){
		//GUI.DrawTexture (healthRect, healthTexture);
		//GUI.DrawTexture (armorRect, armorTexture);

//		healthText.text = health.ToString ();
//		armourText.text = armour.ToString ();
//		if (armour == 0) {
//			armourText.fontSize = 24;
//			armourText.text = "    0";
//		}
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

		if (col.gameObject.name == "Mine" || col.gameObject.name == "Mine(Clone)") {
			TakeDamage (65);
		}
		if (col.gameObject.name == "sFlare" || col.gameObject.name == "sFlare(Clone)") {
			TakeDamage (40);
		}

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Health Pack" || col.gameObject.name == "Health Pack(Clone)") {
			health += 25;
			if (health > maxHp) {
				health = maxHp;
			}
			//powerUp.text = healthUp;
		}

			if (col.gameObject.name == "ArmorPack" || col.gameObject.name == "ArmorPack(Clone)") {
				armour += 100;
			//powerUp.text = armourUp;
			}

			if (col.gameObject.name == "DamagePack" || col.gameObject.name == "DamagePack(Clone)") {
				damageMultiplier = 2;
			//powerUp.text = damageUp;
			}

		if (col.gameObject.name == "FireRatePack" || col.gameObject.name == "FireRatePack(Clone)") {
			this.gameObject.GetComponent<PlayerController> ().fireRate = 0.125f;
			//powerUp.text = fireRateActive;
		}

		if (col.gameObject.name == "HomingPack" || col.gameObject.name == "HomingPack(Clone)") {
			//powerUp.text = homingMissile;
		}

		if (col.gameObject.name == "NukePack" || col.gameObject.name == "NukePack(Clone)") {
			//powerUp.text = nukeActive;
			hasNuke = true;
		}
		if (col.gameObject.name == "ScorePack" || col.gameObject.name == "ScorePack(Clone)") {
			scoreMultiplier = 2;
			//powerUp.text = scoreUp;
		}
		if (col.gameObject.name == "SpeedPack" || col.gameObject.name == "SpeedPack(Clone)") {
			this.gameObject.GetComponent<PlayerController> ().speed = 500;
			//powerUp.text = speedUp;
		}
		if (col.gameObject.name == "TimePack" || col.gameObject.name == "TimePack(Clone)") {
			//powerUp.text = timeSlow;
			Time.timeScale = 0.5f;
			scoreMultiplier = scoreMultiplier * 2;
			this.gameObject.GetComponent<PlayerController> ().speed = 600;
		}
		if (col.gameObject.name == "enemybolt" || col.gameObject.name == "enemybolt(Clone)") {
			TakeDamage (10);
		}

				


			

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

	void UpgradeModel(){
		basicModel.GetComponent<MeshRenderer> ().enabled = false;
		armourModel.SetActive (true);
		upgraded = true;
	}

	void DowngradeModel(){
		armourModel.SetActive (false);
		basicModel.GetComponent<MeshRenderer> ().enabled = true;
		upgraded = false;
	}


					
}
