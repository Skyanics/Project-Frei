using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

	private AudioSource playSound;

	// Use this for initialization
	void Start () {
		playSound = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter() {
		playSound.Play ();
	}
}
