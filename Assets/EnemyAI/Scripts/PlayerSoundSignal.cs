using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundSignal : MonoBehaviour {

	public GameObject enemy;
	HearingScript enemyHearing;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		enemyHearing = enemy.GetComponent<HearingScript> ();
		audio = GetComponent<AudioSource> ();
	}

	void Update() {
		if (audio.isPlaying) {
			enemyHearing.HearNoise (gameObject);
		}
	}
}
