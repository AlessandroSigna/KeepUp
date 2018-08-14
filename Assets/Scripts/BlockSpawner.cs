using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    public GameObject blockPrefab;
    public int maxBlocks = 3;
    private int nBlocks = 0;


    public static BlockSpawner Instance = null;
    // Use this for initialization
    void Start ()
    {
        UIController.Instance.UpdateBlocks(nBlocks, maxBlocks);
        if (Instance == null)
        {
            Instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && CharacterSwitcher.Instance.currentCharacter.GetComponent<CharacterBehaviour>().canBuild)
        {
            if (nBlocks < maxBlocks)
            {
                var mousePos = Input.mousePosition;
                var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.z = 0;
                Instantiate(blockPrefab, objectPos, Quaternion.identity);
                UIController.Instance.UpdateBlocks(++nBlocks, maxBlocks);
            }
        }
    }
}
