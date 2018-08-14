using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    public GameObject blockPrefab;
    public CharacterSwitcher characterSwitcher;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && characterSwitcher.currentCharacter.GetComponent<CharacterBehaviour>().canBuild)
        {
            var mousePos = Input.mousePosition;
            var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0;
            Instantiate(blockPrefab, objectPos, Quaternion.identity);
        }
    }
}
