using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public float MAX_TIME = 30;
    private bool gameOver;
    public static GameOverManager Instance = null;


    private float computedMaxTime;

    // Use this for initialization
    void Start () {
        if (Instance == null)
            Instance = this;

        gameOver = false;
        computedMaxTime = Time.time + MAX_TIME;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
            return;
        
        float remainigTime = computedMaxTime - Time.time;
        if (remainigTime > 0)
        {
            UIController.Instance.UpdateTime(remainigTime);
        }
        else if (remainigTime <= 0)
        {
            UIController.Instance.UpdateTime(0);
            GameOver();
        }


	}

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GameOver()
    {
        print("GAMEOVER");
        CharacterSwitcher.Instance.DisablePlayers();
        UIController.Instance.ShowGameOverPanel();
        CharacterSwitcher.Instance.gameObject.SetActive(false);
        BlockSpawner.Instance.gameObject.SetActive(false);
        gameOver = true;
    }

    public void Win()
    {
        print("Win");
        CharacterSwitcher.Instance.DisablePlayers();
        UIController.Instance.ShowWinPanel();
        CharacterSwitcher.Instance.gameObject.SetActive(false);
        BlockSpawner.Instance.gameObject.SetActive(false);
        gameOver = true;
    }
    

}
