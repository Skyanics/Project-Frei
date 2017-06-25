using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	PickUpKey pickupKey;
	public Rigidbody rb;

    private AudioSource unlock;
	HearingScript enemyHearing;


	// Use this for initialization
	void Start () {
		pickupKey = player.GetComponent<PickUpKey>();
		enemyHearing = enemy.GetComponent<HearingScript> ();
        unlock = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && pickupKey.hasKey == true) {
			rb.isKinematic = false;
			pickupKey.hasKey = false;
			enemyHearing.HearNoise (gameObject);
            rb.AddForce(new Vector3(0,0, 10));
            unlock.Play();
		}
	}

}
