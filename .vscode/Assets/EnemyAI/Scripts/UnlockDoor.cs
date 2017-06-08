using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	PickUpKey pickupKey;
	public Rigidbody rb;

	HearingScript enemyHearing;


	// Use this for initialization
	void Start () {
		pickupKey = player.GetComponent<PickUpKey>();
		enemyHearing = enemy.GetComponent<HearingScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && pickupKey.hasKey == true) {
			rb.isKinematic = false;
			pickupKey.hasKey = false;
			enemyHearing.HearNoise (gameObject);
			//play unlock sound
		}
	}

}
