using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class HidingScript : MonoBehaviour {

	public bool playerIsNear;
	public bool playerIsHidden;
	public GameObject player;
	public GameObject exitPoint;
	public GameObject enterPoint;
	public int timesActivated = 0;
	public Text interactText; 

	void Update () {
		
		if(playerIsNear == true && timesActivated < 2 && Input.GetButtonDown("Activate"))
		{
			playerIsHidden = true;
			player.transform.SetParent(enterPoint.transform);

			player.GetComponent<Rigidbody>().useGravity = false;
			player.GetComponent<RigidbodyFirstPersonController>().enabled = false;

			player.transform.position = enterPoint.transform.position;
			player.transform.rotation = enterPoint.transform.rotation;

			timesActivated += 1;
		}

		else
		{
			playerIsHidden = false;
		}

		if(playerIsHidden == true && timesActivated == 2 && Input.GetButtonDown("Activate"))
		{
			player.transform.SetParent(exitPoint.transform);

			player.GetComponent<Rigidbody>().useGravity = true;
			player.GetComponent<RigidbodyFirstPersonController>().enabled = true;

			player.transform.position = exitPoint.transform.position;
			player.transform.rotation = Quaternion.Euler(0,15,0);
			
			playerIsHidden = false;
			timesActivated = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == ("Player"))
		{
			playerIsNear = true;
			interactText.text = "(A) Hide";
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == ("Player"))
		{
			playerIsNear = false;
			playerIsHidden = false;
			interactText.text = " ";
		}
	}
}
