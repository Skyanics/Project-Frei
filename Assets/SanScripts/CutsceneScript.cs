using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour {
	

	void Update () {
		if(Input.GetButtonDown("Activate"))
		{
			Application.LoadLevel(3);
		}
	}

	public void animEvent()
	{
		Application.LoadLevel(3);
	}
}
