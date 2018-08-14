using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public static UIController Instance = null;

    public Text timeText;
    public Text blocksText;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
	// Use this for initialization
	void Start () {
        if (Instance == null)
        {
            Instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateTime(float time)
    {
        timeText.text = Mathf.CeilToInt(time).ToString();
    }

    public void UpdateBlocks(int n, int max)
    {
        blocksText.text = "" + n + "/" + max;
    }

    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
}
