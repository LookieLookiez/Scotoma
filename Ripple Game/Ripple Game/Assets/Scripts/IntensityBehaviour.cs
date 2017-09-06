using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityBehaviour : MonoBehaviour {

    public static IntensityBehaviour Instance;

    public enum States
    {
        FAR,
        INTERMEDIATE,
        CLOSE
    }
    States curState;
    
    public GameObject player;
    public GameObject monster;

    public bool far;
    public bool intermediate;
    public bool close;

    public float dist;
    public Vector3 direction;
	// Use this for initialization
	void Start () {
        Instance = this;
        curState = States.FAR;
        far = false;
        intermediate = false;
        close = false;   
	}
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(player.transform.position, monster.transform.position);

        if (dist > 25f)
            curState = States.FAR;

        if (dist < 25 && dist > 15f)
            curState = States.INTERMEDIATE;

        if (dist < 15f)
            curState = States.CLOSE;

        switch(curState)
        {
            case States.FAR:
                Debug.Log("FAR");
                far = true;
                intermediate = false;
                close = false;
                FAR();
                break;

            case States.INTERMEDIATE:
                Debug.Log("INTERMEDIATE");
                intermediate = true;
                far = false;
                close = false;
                FAR();
                break;

            case States.CLOSE:
                Debug.Log("CLOSE");
                close = true;
                intermediate = false;
                far = false;
                FAR();
                break;

        }
    }

    public void FAR()
    {
        if(far)
        {
            AudioManager.Instance.intensity = 2.5f;
            AudioManager.Instance.volume = 1.5f;
        }
        else
        {
            far = false;
        }

        if (intermediate)
        {
            AudioManager.Instance.intensity = 1.5f;
            AudioManager.Instance.volume = 2f;
        }
        else
        {
            intermediate = false;
        }

        if (close)
        {
            AudioManager.Instance.intensity = .5f;
            AudioManager.Instance.volume = 2.5f;
        }
        else
        {
            close = false;
        }
    }
}
