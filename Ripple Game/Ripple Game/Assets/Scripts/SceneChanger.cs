using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	bool onceItGoesBlackItllNeverGoBack = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (!onceItGoesBlackItllNeverGoBack) {
			
			if (Input.anyKeyDown)
				ChangeScenes (1);
		}
	}

	public void ChangeScenes(int buildIndex)
	{
		onceItGoesBlackItllNeverGoBack = true;
		SceneManager.LoadScene (buildIndex);
	}

	

}
