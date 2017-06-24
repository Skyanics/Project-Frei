using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightScript : MonoBehaviour {

	private GameObject flashLight;
	private bool isTurnedOn;
	private Light lt;
	[SerializeField]
	public float batteryLife = 8;

	public Slider flashLightUI;
	public Image filler;

	public AudioSource aS;
	public AudioClip charge;
	public AudioClip onAndOff;

	public bool isPlaying = false;

	public Animator anmr;

	public float rechargeMultiplier;

	// Use this for initialization
	void Start () {
		flashLight = this.gameObject;
		isTurnedOn = false;
		lt = flashLight.GetComponent<Light>();
		aS = GetComponent<AudioSource>();
		anmr = GameObject.Find("FPS ARMS RIG 1").GetComponent<Animator>();
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

		if(Input.GetKey(KeyCode.R) && batteryLife < 8 || Input.GetButton("Recharge") && batteryLife < 8)
		{
			batteryLife += Time.deltaTime * rechargeMultiplier;
		}

		if(Input.GetKey(KeyCode.R) || Input.GetButton("Recharge"))
		{
			anmr.SetBool("charging", true);
		}

		else if (Input.GetKeyUp(KeyCode.R) || Input.GetButtonUp("Recharge"))
		{
			aS.Stop();
			anmr.SetBool("charging", false);
			anmr.StopPlayback();
		}


		if(Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Recharge"))
		{
			aS.clip = charge;
			aS.Play();
		}
		

		if(Input.GetKeyDown(KeyCode.F) && isTurnedOn == false || Input.GetButtonDown("EnableFlashlight") && isTurnedOn == false)
		{
			flashLight.GetComponent<Light>().enabled = true;
			isTurnedOn = true;
			aS.PlayOneShot(onAndOff);
		}

		else if (Input.GetKeyDown(KeyCode.F) && isTurnedOn == true || Input.GetButtonDown("EnableFlashlight") && isTurnedOn == true)
		{
			flashLight.GetComponent<Light>().enabled = false;
			isTurnedOn = false;
			aS.PlayOneShot(onAndOff);
		}
		
	}
}