using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandomSoundScript : MonoBehaviour {

	public int randomizer;
	public AudioSource aS;
	private IEnumerator coroutine;

	public int minVal = 10;
	public int maxVal = 40;
	
	void Start()
	{
		coroutine = RandomPlaySound();
		StartCoroutine(coroutine);
	}

	private IEnumerator RandomPlaySound()
	{
		while(true){
			yield return new WaitForSeconds(randomizer);
			aS.Play();
			randomizer = Random.Range(minVal, maxVal);
		}
	}
}
