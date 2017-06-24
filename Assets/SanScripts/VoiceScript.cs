using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceScript : MonoBehaviour {
	public float count = 0;

	public AudioSource aS;
	public AudioClip aud1;
	public AudioClip aud2;
	public AudioClip aud3;
	public AudioClip aud4;
	public AudioClip aud5;

	public FlashlightScript flashScript;

	private IEnumerator coroutine;

	void Start()
	{
		aS = GetComponent<AudioSource> ();
		aS.PlayOneShot (aud1, 1);

		coroutine = Voice ();
		StartCoroutine (coroutine);
	}

	// Update is called once per frame
	void Update () {

		if (flashScript.batteryLife == 0) {
			aS.PlayOneShot (aud2, 1);
		}


		
	}

	private IEnumerator Voice()
	{
		yield return new WaitForSeconds (30);
		aS.PlayOneShot (aud3, 1);
		yield return new WaitForSeconds (120);
		aS.PlayOneShot (aud4, 1);
		yield return new WaitForSeconds (50);
		aS.PlayOneShot (aud5, 1);
	}


}
