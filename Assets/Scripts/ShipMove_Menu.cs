using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove_Menu : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn1;
    public Transform shotSpawn2;

    [Range(10, 1000)]
    public float depth;

    // Use this for initialization
    void Start () {
        InvokeRepeating("FireWeapon", 4, 4);
        InvokeRepeating("FireWeapon", 4.5f, 4);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FireWeapon()
    {
        Vector3 worldPos = new Vector3(-1.2f, 21.8f, depth);
        shotSpawn1.transform.LookAt(worldPos);
        shotSpawn2.transform.LookAt(worldPos);

        Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
    }


}
