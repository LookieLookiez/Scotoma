using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RippleBehaviour : MonoBehaviour {

    public GameObject myOwner;
    Vector3 temp;
    public Color myColour;
    public string whoOwnsMe;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    // Use this for initialization
    void Start () {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        myOwner = GameObject.FindGameObjectWithTag(whoOwnsMe);
        Invoke("Death", 5f); 
	}
	
	// Update is called once per frame
	void Update () {

        if(myOwner.GetComponent<Ripple>().Iam == Ripple.WhatAmI.Player)
        {
            temp = transform.localScale;
            temp.x += Time.deltaTime;
            temp.z += Time.deltaTime;
            transform.localScale = temp;
        }
        if (myOwner.GetComponent<Ripple>().Iam == Ripple.WhatAmI.Player && !controller.m_IsWalking)
        {
            temp = transform.localScale;
            temp.x += Time.deltaTime * 2;
            temp.z += Time.deltaTime * 2;
            transform.localScale = temp;
        }
        if (myOwner.GetComponent<Ripple>().Iam == Ripple.WhatAmI.Player)
        {
            temp = transform.localScale;
            temp.x += Time.deltaTime;
            temp.z += Time.deltaTime;
            transform.localScale = temp;
        }
        if (myOwner.GetComponent<Ripple>().Iam == Ripple.WhatAmI.Monster)
        {
            temp = transform.localScale;
            temp.x += Time.deltaTime;
            temp.z += Time.deltaTime;
            transform.localScale = temp;
        }
        if (myOwner.GetComponent<Ripple>().Iam == Ripple.WhatAmI.Door)
        {
            temp = transform.localScale;
            temp.x += Time.deltaTime / 10;
            temp.z += Time.deltaTime / 10;
            transform.localScale = temp;
        }


    }

    void Death()
    {
        StartCoroutine(FadeAndDestroy(0,1));
    }

    IEnumerator FadeAndDestroy(float aValue, float aTime)
    {
        var thisInst = this.gameObject.GetComponent<MeshRenderer>().material;
        float alpha = thisInst.color.a;

        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColour = new Color(thisInst.color.r, thisInst.color.g, thisInst.color.b, Mathf.Lerp(alpha, aValue, t));
            thisInst.color = newColour;
            StartCoroutine(Destroy());
            yield return null;       
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}

