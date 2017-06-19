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

    Vector2 mousePos;
    bool locked = false;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        crosshairSize = Screen.width * 0.025f;
		crosshairTexture = Resources.Load ("Textures/square") as Texture;
		crosshairHitTexture = Resources.Load ("Textures/squareHit") as Texture;
		crosshairRect = new Rect (Screen.width/2 - crosshairSize/2, Screen.height/2 - crosshairSize/2, crosshairSize, crosshairSize);
	}

    void OnEnable()
    {
        EventHandler.pauseEvent += PauseHandler;
        EventHandler.unpauseEvent += UnpauseHandler;
    }

    void OnDisable()
    {
        EventHandler.pauseEvent -= PauseHandler;
        EventHandler.unpauseEvent -= UnpauseHandler;
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
        if (!locked)
        {
            crosshairRect = new Rect(Input.mousePosition.x - (crosshairSize / 2), (Screen.height - Input.mousePosition.y) - (crosshairSize / 2), crosshairSize, crosshairSize);
            if (isHit)
            {
                GUI.DrawTexture(crosshairRect, crosshairHitTexture);
            }
            else
            {
                GUI.DrawTexture(crosshairRect, crosshairTexture);
            }
        } 
	}

    void PauseHandler()
    {
        locked = true;
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Cursor.visible = true;
    }

    void UnpauseHandler()
    {
        locked = false;
        Cursor.visible = false;
    }
		
}
