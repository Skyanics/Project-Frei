using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			GameObject.Find("Metro").GetComponent<MetroScript>().nextStation = false;
		}
	}
}
