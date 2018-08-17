using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour {

    List<GameObject> characters = null;
	// Use this for initialization
	void Start () {
        characters = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterBehaviour>() != null)
        {
            if (!characters.Contains(other.gameObject))
            {
                characters.Add(other.gameObject);
                if (characters.Count == CharacterSwitcher.Instance.playableCharacters.Length)
                {
                    GameOverManager.Instance.Win();
                }
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterBehaviour>() != null)
        {
            if (!characters.Contains(other.gameObject))
            {
                characters.Remove(other.gameObject);
            }
        }
    }
}
