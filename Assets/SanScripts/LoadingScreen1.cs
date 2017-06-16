using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScreen1 : MonoBehaviour {

	AsyncOperation ao;
	public Slider progBar;
	public Text loadingText;

	public bool isFakeLoadingBar = false;

	// Use this for initialization
	void Start () {
		LoadLevel();
	}

	public void LoadLevel()
	{
		loadingText.text = "LOADING...";

		if(!isFakeLoadingBar)
		{
			StartCoroutine(LoadLevelWithRealProgress());
		}
	}

	IEnumerator LoadLevelWithRealProgress()
	{
		yield return new WaitForSeconds(1);

		ao = SceneManager.LoadSceneAsync(2);
		ao.allowSceneActivation = false;

		while(!ao.isDone)
		{
			progBar.value = ao.progress;

			if (ao.progress == 0.9f)
			{
				loadingText.text = "Press any key to continue";
				if (Input.anyKeyDown)
				{
					ao.allowSceneActivation = true;
				}
			}
			
			Debug.Log(ao.progress);
			yield return null;
		}
	}
}


