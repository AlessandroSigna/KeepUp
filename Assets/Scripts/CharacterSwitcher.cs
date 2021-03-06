﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour {

    public GameObject[] playableCharacters;
    [HideInInspector]
    public GameObject currentCharacter;
    private int currentIndex = 0;

    public AudioClip cough;

    public static CharacterSwitcher Instance = null;
	// Use this for initialization
	void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        playableCharacters[0].GetComponent<CharacterBehaviour>().enabled = true;
        currentCharacter = playableCharacters[0];
        currentIndex = 0;
        currentCharacter.GetComponent<CharacterBehaviour>().ShowArrow();
        for (int i = 1; i < playableCharacters.Length; i++)
        {
            playableCharacters[i].GetComponent<CharacterBehaviour>().enabled = false;
            playableCharacters[i].GetComponent<CharacterBehaviour>().HideArrow();
            playableCharacters[i].GetComponent<CharacterBehaviour>().BeInactive();
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }
        if (currentIndex == 0 && Mathf.CeilToInt(Time.time) % 10 == 0 && Time.time != 0)
        {
            GetComponent<AudioSource>().clip = cough;
            GetComponent<AudioSource>().Play();
        }
	}

    public void SwitchCharacter()
    {

        currentCharacter.GetComponent<CharacterBehaviour>().BeInactive();
        currentCharacter.GetComponent<CharacterBehaviour>().HideArrow();
        playableCharacters[currentIndex].GetComponent<CharacterBehaviour>().enabled = false;
        currentIndex = ++currentIndex % playableCharacters.Length;
        currentCharacter = playableCharacters[currentIndex];
        playableCharacters[currentIndex].GetComponent<CharacterBehaviour>().enabled = true;
        currentCharacter.GetComponent<CharacterBehaviour>().ShowArrow();

    }
    

    public void DisablePlayers()
    {
        foreach (GameObject character in playableCharacters)
        {
            character.GetComponent<CharacterBehaviour>().enabled = false;
        }
    }
}
