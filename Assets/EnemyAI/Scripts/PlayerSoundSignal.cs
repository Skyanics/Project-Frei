using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundSignal : MonoBehaviour {

	public GameObject enemy;
	HearingScript enemyHearing;
	AudioSource source;

	// Use this for initialization
	void Start () {
		enemyHearing = enemy.GetComponent<HearingScript> ();
		source = GetComponent<AudioSource> ();
	}

	void Update() {
		if (source.isPlaying) {
			enemyHearing.HearNoise (gameObject);
		}
	}
}
