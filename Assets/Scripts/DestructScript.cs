using UnityEngine;
using System.Collections;

public class DestructScript : MonoBehaviour {
	
		void OnTriggerExit(Collider col)
		{
			Destroy(col.gameObject);
		}
	}
