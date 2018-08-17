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
    public GameObject PausePanel;

    public Sprite[] TimeImages;
    public Image TimeSprite;
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

    public void UpdateTime(float maxTime, float realTime)
    {
        int dim = TimeImages.Length - 1;
        float f = maxTime / dim;
        int index = Mathf.CeilToInt( realTime / f);
        index = dim - index;
        if (realTime <= 0)
            index = dim;
        print(realTime + " -> " + index);
        TimeSprite.sprite = TimeImages[index];
        
    }

    public void ShowPausePanel()
    {
        PausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {
        PausePanel.SetActive(false);
    }

    //public void UpdateTime(float time)
    //{
    //    timeText.text ="" + "Time left: " + Mathf.CeilToInt(time).ToString();
    //}

    public void UpdateBlocks(int n)
    {
        blocksText.text = " x " + n;
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
