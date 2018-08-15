using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip vicotrySound;
    public AudioClip jumpSound;
    public AudioClip[] boxSounds;

    public static AudioManager Instance = null;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        if (Instance == null)
            Instance = this;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayVictory()
    {
        audioSource.clip = vicotrySound;
        audioSource.Play();
    }


    public void PlayJump()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    public void PlayBox()
    {
        audioSource.clip = boxSounds[0];
        audioSource.Play();
    }
}
