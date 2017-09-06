using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
