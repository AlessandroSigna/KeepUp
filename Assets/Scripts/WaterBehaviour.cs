using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Phill")
        {
            GameOverManager.Instance.GameOver();
        }

        CharacterBehaviour character = collision.gameObject.GetComponent<CharacterBehaviour>();
        if (character != null)
        {
            character.isSwimming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CharacterBehaviour character = collision.gameObject.GetComponent<CharacterBehaviour>();
        if (character != null)
        {
            character.isSwimming = false;
        }
    }
}
