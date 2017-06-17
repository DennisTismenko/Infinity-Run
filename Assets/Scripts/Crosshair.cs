using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	Rect crosshairRect;
	Texture crosshairTexture;
	Texture crosshairHitTexture;
	float crosshairSize;
	bool isHit;
	Ray ray;
	RaycastHit hit;


	// Use this for initialization
	void Start () {
		crosshairSize = Screen.width * 0.025f;

		crosshairTexture = Resources.Load ("Textures/square") as Texture;
		crosshairHitTexture = Resources.Load ("Textures/squareHit") as Texture;

		crosshairRect = new Rect (Screen.width/2 - crosshairSize/2, Screen.height/2 - crosshairSize/2, crosshairSize, crosshairSize);
	}

	// Update is called once per frame
	void Update () {
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit))
		{
			if (hit.collider.tag == "Enemy") {
				isHit = true;
			} 
		}
		else {
			isHit = false;
		}

		
	}

	void OnGUI(){
		crosshairRect = new Rect (Input.mousePosition.x - (crosshairSize / 2), (Screen.height - Input.mousePosition.y) - (crosshairSize / 2), crosshairSize, crosshairSize);
		if (isHit) {
			GUI.DrawTexture (crosshairRect, crosshairHitTexture);
		} else {
			GUI.DrawTexture (crosshairRect, crosshairTexture);
		}

	}
		
}
