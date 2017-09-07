using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Monster.Instance.monster = Monster.States.Toying;
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Monster.Instance.monster = Monster.States.Agressive;
    }
}
