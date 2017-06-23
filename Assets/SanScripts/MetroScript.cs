using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetroScript : MonoBehaviour {

	public Transform[] target;
	public float speed;
	[SerializeField]
	public int current;

	public float Damping = 100.0f;

	public bool playerIsNear = false;

	public bool nextStation;
	
	public int EndPoint;

	private Collider other;
	public Text interactText;

	

	void Update () {

		other = GameObject.Find("Player").GetComponent<CapsuleCollider>();

		if (nextStation == false && playerIsNear == true) {
			interactText.text = "(A) Ride the metro";
		} 

		if(nextStation == true){
			interactText.text = " ";
		}

		if(Input.GetKeyDown(KeyCode.E) && playerIsNear == true && nextStation == false || Input.GetButtonDown("Activate") && playerIsNear == true && nextStation == false)
		{
			nextStation = true;
			other.transform.SetParent(this.gameObject.transform,true);
			GetComponent<AudioSource>().Play();
		}

		if (playerIsNear == true && nextStation == true){

				if(transform.position != target[current].position)
				{
					
					Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
					var rotation = Quaternion.LookRotation (target[current].position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * Damping);
					transform.position = pos;
					speed = 5;
					
				}

				else {
					current = (current + 1) % target.Length;
					
				}
			}
		}

	void OnTriggerEnter()
	{
		if(other.tag == "Player")
		{
				
			playerIsNear = true;	
		}
	}

	void OnTriggerExit()
	{
		if(other.tag == "Player")
		{
			other.transform.SetParent(null);
			playerIsNear = false;
			interactText.text = " ";
			
		}
	}

	void OnGui()
	{
		if (playerIsNear == true)
		{
			
			 GUI.Label(new Rect(Screen.width /2, Screen.height / 2, 100, 20), "A - Activate");
		}
	}
}
