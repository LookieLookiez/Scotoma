using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DarkroomScript : MonoBehaviour
{
    public GameObject player;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public GameObject overlay;
    // Use this for initialization
    void Start()
    {
        overlay = GameObject.FindGameObjectWithTag("Overlay");
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Continue(1, 1));
        }
    }

    IEnumerator Continue(float aValue, float aTime)
    {
        var thisInst = overlay.gameObject.GetComponent<Image>();
        float alpha = thisInst.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColour = new Color(thisInst.color.r, thisInst.color.g, thisInst.color.b, Mathf.Lerp(alpha, aValue, t));
            thisInst.color = newColour;
            StartCoroutine(SceneChange());
            yield return null;
        }
    }

    IEnumerator SceneChange()
    {
        controller.m_WalkSpeed = 0;
        controller.m_RunSpeed = 0;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
}
