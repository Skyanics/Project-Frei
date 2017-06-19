using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingScript : MonoBehaviour {

	public float range;
	UnlockDoor doorNoise;
	public float dist;

	Chase chaseScript;

	void Start () {
		chaseScript = GetComponent<Chase> ();
	}

	public void HearNoise(GameObject noise) {
		dist = Vector3.Distance(noise.transform.position, transform.position);
		if (dist < range) {
			chaseScript.agent.SetDestination (noise.transform.position);
		}
	}
}
