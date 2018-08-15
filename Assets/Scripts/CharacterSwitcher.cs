using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour {

    public GameObject[] playableCharacters;
    [HideInInspector]
    public GameObject currentCharacter;
    private int currentIndex = 0;

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
        for (int i = 1; i < playableCharacters.Length; i++)
        {
            playableCharacters[i].GetComponent<CharacterBehaviour>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }
	}

    public void SwitchCharacter()
    {
        playableCharacters[currentIndex].GetComponent<CharacterBehaviour>().enabled = false;
        currentIndex = ++currentIndex % playableCharacters.Length;
        currentCharacter = playableCharacters[currentIndex];
        playableCharacters[currentIndex].GetComponent<CharacterBehaviour>().enabled = true;

    }
    

    public void DisablePlayers()
    {
        foreach (GameObject character in playableCharacters)
        {
            character.GetComponent<CharacterBehaviour>().enabled = false;
        }
    }
}
