using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour {

    public GameObject hero;
    public GameObject support;
    [HideInInspector]
    public GameObject currentCharacter;
	// Use this for initialization
	void Start ()
    {
        hero.GetComponent<CharacterBehaviour>().enabled = true;
        support.GetComponent<CharacterBehaviour>().enabled = false;
        currentCharacter = hero;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentCharacter == hero)
            {
                PlaySupport();
            }
            else
            {
                PlayHero();
            }
        }
	}

    private void PlayHero()
    {
        hero.GetComponent<CharacterBehaviour>().enabled = true;
        support.GetComponent<CharacterBehaviour>().enabled = false;
        currentCharacter = hero;
    }

    private void PlaySupport()
    {
        hero.GetComponent<CharacterBehaviour>().enabled = false;
        support.GetComponent<CharacterBehaviour>().enabled = true;
        currentCharacter = support;
    }
}
