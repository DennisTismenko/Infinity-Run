using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float speed;
	public float turnSpeed;

	public float leftBorder;
	public float rightBorder;
	public float topBorder;
	public float bottomBorder;

	//private Player player;
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public float fireRate;
	private float nextFire;

	[Range (10,600)]
	public float depth;

	private Rigidbody rb;
	bool canShoot;

	// Use this for initialization
	void Start () {

		canShoot = true;
		rb = GetComponent <Rigidbody> ();

	
	}


	// Update is called once per frame
	void Update () {

	Move ();

		if (!Player.alive) 
		{
			gameObject.GetComponent<PlayerController>().enabled = false;
		}

		if (Input.GetButton ("Fire1") && canShoot)
		{
			StopCoroutine ("FireWeapon");
			StartCoroutine ("FireWeapon", shotSpawn1);
			StartCoroutine ("FireWeapon", shotSpawn2);

		}

		//rb.position = new Vector3 (rb.position.x, rb.position.y, 2.921f);
	}

	void FixedUpdate()
	{

		if (Input.GetKey (KeyCode.Q)) {
			rb.AddTorque (transform.forward * turnSpeed * Time.deltaTime, ForceMode.Force);
		}

		else if (Input.GetKey (KeyCode.E)) {
			rb.AddTorque (-transform.forward * turnSpeed * Time.deltaTime, ForceMode.Force);
		}
		

		if (rb.transform.position.x <=leftBorder || rb.transform.position.x >=rightBorder)
		{
			// Create values between this range (minX to maxX) and store in xPos
			float xPos = Mathf.Clamp(rb.transform.position.x, leftBorder, rightBorder);

			// Assigns these values to the Transform.position component of the Player
			rb.transform.position = new Vector3(xPos, rb.transform.position.y,2.921f);
		}

		if (rb.transform.position.y <= bottomBorder || rb.transform.position.y >=topBorder)
		{
			// Create values between this range (minY to maxY) and store in yPos
			float yPos = Mathf.Clamp(rb.transform.position.y, bottomBorder, topBorder);

			// Assigns these values to the Transform.position component of the Player
			rb.transform.position = new Vector3(rb.transform.position.x, yPos,2.921f);
		}

		rb.transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);


	}

	IEnumerator FireWeapon(Transform weapon){
		Vector3 direction = Input.mousePosition;
		direction.z = depth;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (direction);
		weapon.transform.LookAt (worldPos);
		Instantiate (shot, weapon.position, weapon.rotation);
		canShoot = false;
		yield return new WaitForSeconds(fireRate);
		canShoot = true;
		
	}

	void Move(){
		Vector3 direction = Input.mousePosition;
		direction.z = 10;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (direction);
		worldPos.y -= 4;
		worldPos = (worldPos - transform.position);
		rb.AddForce (worldPos * speed,ForceMode.Force);

	}

	void OnCollisionEnter(Collision col){
		
	}
		
}	
