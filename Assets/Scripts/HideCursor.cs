using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}

	void Update(){
		if (Cursor.visible) {
			Cursor.visible = false;
		}
	}

}
