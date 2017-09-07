using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviourScript : MonoBehaviour {

    public GameObject player;
    public Animator anim;
    public bool follow = true;
    public GameObject myChild;

	// Use this for initialization
	void Start () {
        anim = myChild.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

	
	// Update is called once per frame
	void Update () {
        var dir = (this.gameObject.transform.position - player.transform.position).normalized;
        var updatedDir = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        if (follow)
            // transform.LookAt(updatedDir);
            transform.LookAt(updatedDir);

	}

    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            follow = false;
            anim.SetBool("open", true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            follow = true;
            anim.SetBool("open", false);
        }
    }
}
