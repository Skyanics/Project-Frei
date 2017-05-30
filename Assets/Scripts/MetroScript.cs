using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroScript : MonoBehaviour {

	public Transform[] target;
	public float speed;
	[SerializeField]
	private int current;

	public float Damping = 100.0f;

	public bool playerIsNear = false;

	public bool nextStation;
	
	public int EndPoint;

	private Collider other;

	

	void Update () {

	other = GameObject.Find("Player").GetComponent<CapsuleCollider>();
		if(Input.GetKeyDown(KeyCode.E) && playerIsNear == true)
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
					if (current == EndPoint)
						{
							nextStation = false;
							GetComponent<AudioSource>().Stop();
						}
					
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
