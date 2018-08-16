using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    public GameObject blockPrefab;
    private int maxBlocks = 3;
    private int nBlocks = 0;
    private GameObject currentCharacter;


    public static BlockSpawner Instance = null;
    // Use this for initialization
    void Start ()
    {
        currentCharacter = CharacterSwitcher.Instance.currentCharacter;
        UIController.Instance.UpdateBlocks(currentCharacter.GetComponent<CharacterBehaviour>().boxesAvailable);
        if (Instance == null)
        {
            Instance = this;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //print(currentCharacter.name);
        currentCharacter = CharacterSwitcher.Instance.currentCharacter;
        if (Input.GetKeyDown(KeyCode.Mouse0) && CharacterSwitcher.Instance.currentCharacter.GetComponent<CharacterBehaviour>().boxesAvailable > 0)
        {
            CharacterSwitcher.Instance.currentCharacter.GetComponent<CharacterBehaviour>().boxesAvailable--;
            var mousePos = Input.mousePosition;
            var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0;
            Instantiate(blockPrefab, objectPos, Quaternion.identity);
            AudioManager.Instance.PlayBox();
        }

        UIController.Instance.UpdateBlocks(currentCharacter.GetComponent<CharacterBehaviour>().boxesAvailable);
    }
}
