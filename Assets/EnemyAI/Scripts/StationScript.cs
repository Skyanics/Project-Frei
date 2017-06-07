using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationScript : MonoBehaviour {

	public GameObject metro;
	public bool isLastStation;
	public bool isFirstStation;
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			metro.GetComponent<MetroScript>().nextStation = false;
			metro.GetComponent<AudioSource>().Stop();
			
			if( isLastStation == true)
			{
				metro.GetComponent<MetroScript>().current = (metro.GetComponent<MetroScript>().current - 1) % metro.GetComponent<MetroScript>().target.Length;
			}

			if( isFirstStation == true)
			{
				metro.GetComponent<MetroScript>().current = (metro.GetComponent<MetroScript>().current + 1) % metro.GetComponent<MetroScript>().target.Length;
			}
		}
	}

}
