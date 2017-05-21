using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroScript : MonoBehaviour {
	public Transform[] target;
	public float speed;
	private int current;

	public float Damping = 100.0f;

	public bool playerIsNear = false;

	public bool nextStation;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
		{
			nextStation = true;
		}

			if (playerIsNear == true && nextStation == true){

				if(transform.position != target[current].position)
				{
					
					Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
					var rotation = Quaternion.LookRotation (target[current].position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * Damping);
					GetComponent<Rigidbody>().MovePosition(pos);
					speed = 5;
				}

				else {
					current = (current + 1) % target.Length;
					nextStation = false;
					
				}
			}

		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			playerIsNear = true;		
		

		}
	}


	

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			playerIsNear = false;
		}
	}

	void OnGui()
	{
		if (playerIsNear == true)
		{
			 GUI.Label(new Rect(Screen.width /2, Screen.height / 2, 100, 20), "Hello World!");
		}
	}
}
