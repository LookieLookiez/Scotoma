using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;

    public AudioClip chord1;
    public AudioClip chord2;
    public float intensity;
    public float intensityNormal;
    public bool firstClipPlayedLast;
    public AudioSource audioSource;
    private float timer;
    public float volume; 

    // Use this for initialization
    void Start () {
        Instance = this;
        intensityNormal = 2.5f;
        intensity = intensityNormal;
        firstClipPlayedLast = false;
        timer = intensity;
        volume = 1.5f;
    }
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            PlayChords();
            timer = intensity;
        }

	}

    void PlayChords()
    {
        if (!firstClipPlayedLast)
        {
            audioSource.PlayOneShot(chord1, volume);
            firstClipPlayedLast = true;
            return;
        }
        
        if (firstClipPlayedLast)
        {
            audioSource.PlayOneShot(chord2, volume);
            firstClipPlayedLast = false;
            return;
        }
    }
}
