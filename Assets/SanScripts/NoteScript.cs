using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteScript : MonoBehaviour {

	public Image noteImg;
	public Sprite tex;
	public bool playerIsNear;
	public Text interactText;
	public MetroScript mscript1;
	public MetroScript mscript2;


	void Start()
	{
		noteImg.enabled = false;
	}

	void Update () {

		if (playerIsNear == true && noteImg.enabled == false) {
			interactText.text = "(A) Read Note";
		}

		if (playerIsNear == true && Input.GetButtonDown ("Activate")) {
			noteImg.enabled = true;
			noteImg.sprite = tex;
			interactText.text = "(B) Close Note";
		} 

		if (noteImg.enabled == true && Input.GetButtonDown ("Exit")) {
				interactText.text = " ";
				noteImg.enabled = false;
		}
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			playerIsNear = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			playerIsNear = false;
			interactText.text = " ";
		}
	}
}
