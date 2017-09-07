using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2Changer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(TimedSceneChange());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TimedSceneChange()
    {
        Debug.Log("im running");
        yield return new WaitForSeconds(25f);
        Debug.Log("im running");
        SceneManager.LoadScene(2);
    }
}
