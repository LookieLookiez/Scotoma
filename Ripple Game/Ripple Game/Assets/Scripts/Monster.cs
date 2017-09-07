using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public static Monster Instance;
    public GameObject player;
    public float speed;
    public float timeBetweenToyingJumps;
    public float timeBetweenAgressiveJumps;
    private float timerWhenToying;
    private float timerWhenAgressive;
    public enum States {Passive, Toying, Agressive};
    public States monster;
	// Use this for initialization
	void Start () {
        Instance = this;
        monster = States.Passive;
        timerWhenToying = timeBetweenToyingJumps;
	}
	
	// Update is called once per frame
	void Update () {

        if(monster == States.Passive)
        {
            
        }


        if(monster == States.Toying)
        {
            speed = 2.2f;
            timerWhenToying -= Time.deltaTime;
            if (timerWhenToying <= 0f)
            {
                Teleport();
            }
        }


         if (monster == States.Agressive)
        {
            speed = 3.8f;
            timerWhenAgressive -= Time.deltaTime;
            if(timerWhenAgressive <= 0f)
            {
                Teleport();
            }

        }
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
 
    }

    public void Teleport()
    {
        var jumpPos = new Vector3(Random.Range(player.transform.position.x - 50, player.transform.position.x + 50), 
            0.5f, (Random.Range(player.transform.position.z - 50, 
            player.transform.position.z + 50)));
        var dist = Vector3.Distance(player.transform.position, jumpPos);
        if (dist > 25)
        {
            this.gameObject.transform.position = jumpPos;
            timerWhenToying = timeBetweenToyingJumps;
            timerWhenAgressive = timeBetweenAgressiveJumps;
        }
        else
        {
            Teleport();  
        }
        
    }
}
