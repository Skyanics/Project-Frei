using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightScript : MonoBehaviour {

	private GameObject flashLight;
	private bool isTurnedOn;
	private Light lt;
	private float batteryLife = 8;

	public Slider flashLightUI;
	public Image filler;
	// Use this for initialization
	void Start () {
		flashLight = this.gameObject;
		isTurnedOn = false;
		lt = flashLight.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

		lt.intensity = batteryLife;
		flashLightUI.value = batteryLife;

		if(batteryLife > 4)
		{
			filler.color = Color.green;
		}

		if(batteryLife < 4)
		{
			filler.color = Color.yellow;
		}

		if(batteryLife < 2)
		{
			filler.color = Color.red;
		}
		
		

		if(isTurnedOn == true && batteryLife > 0)
		{
			batteryLife -= Time.deltaTime / 10;
		}

		if (batteryLife < 0)
		{
			lt.intensity = 0;
			
		}

		if(Input.GetKey(KeyCode.R) && batteryLife < 8)
		{
			batteryLife += Time.deltaTime / 5;
		}
		

		if(Input.GetKeyDown(KeyCode.F) && isTurnedOn == false)
		{
			flashLight.GetComponent<Light>().enabled = true;
			isTurnedOn = true;
		}

		else if (Input.GetKeyDown(KeyCode.F) && isTurnedOn == true)
		{
			flashLight.GetComponent<Light>().enabled = false;
			isTurnedOn = false;
		}
		
	}
}
