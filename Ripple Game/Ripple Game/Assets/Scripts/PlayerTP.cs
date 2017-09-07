using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour {
    public static PlayerTP Instance;
    private GameObject player;
    public GameObject TPSafeObject;
    public bool needsToTP = false;
    public bool safeToTP = false;
    public GameObject[] doors;

    public Camera cam;
	// Use this for initialization
	void Start () {
        Instance = this;
        player = this.gameObject;
        needsToTP = false;
        safeToTP = false;
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject == TPSafeObject)
            {
                safeToTP = true;
            }
        }
            

        if (needsToTP && safeToTP)
        {
            var chosenDoor = Random.Range(0, doors.Length);
            var currentDoor = doors[chosenDoor];
            var TPPos = new Vector3(Random.Range(currentDoor.transform.position.x - 50, currentDoor.transform.position.x + 50),
            0.5f, (Random.Range(currentDoor.transform.position.z - 50,
            currentDoor.transform.position.z + 50)));

            var dist = Vector3.Distance(currentDoor.transform.position, TPPos);
            if (dist > 30)
            {
                this.gameObject.transform.position = TPPos;
            
            }
            else
            {
                return;
            }
        }
	}
}
