using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ripple : MonoBehaviour {
    public static Ripple Instance;

    public GameObject monsterRipple;
    public GameObject doorRipple;
    public GameObject playerRipple;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    public enum WhatAmI
    {
        Player,
        Monster,
        Door
    }
    public WhatAmI Iam;
    // Use this for initialization
    void Start () {
        Instance = this;
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        InvokeRepeating("MakeRippleGoNow", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeRippleGoNow()
    {
        if (Iam == WhatAmI.Player && controller.ripple)
        {
            var ripple = Instantiate(playerRipple, transform.position, transform.rotation);
            ripple.GetComponent<RippleBehaviour>().whoOwnsMe = "RippleP";
        }
        if (Iam == WhatAmI.Monster)
        {
            var ripple = Instantiate(monsterRipple, transform.position, transform.rotation);
            ripple.GetComponent<RippleBehaviour>().whoOwnsMe = "RippleM";
        }
        if (Iam == WhatAmI.Door)
        {
            var ripple = Instantiate(doorRipple, transform.position, transform.rotation);
            ripple.GetComponent<RippleBehaviour>().whoOwnsMe = "RippleD";
        }
    }

    public void PlayerStep()
    {
        
    }
    
        
    
}
