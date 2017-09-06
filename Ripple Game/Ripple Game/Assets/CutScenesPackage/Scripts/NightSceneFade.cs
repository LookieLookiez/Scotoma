using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSceneFade : MonoBehaviour {

    public Animator anim;

    public Transform topLid;
    public Transform bottomLid;
    public float speed = .8f;

    void Update()
    {
        float step = speed * Time.deltaTime;
        bottomLid.position = Vector3.MoveTowards(transform.position, new Vector3 (0, -38, 0), step);
    }
}
