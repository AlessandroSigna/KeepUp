using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public float MAX_TIME = 30;
    private bool gameOver;
    public static GameOverManager Instance = null;
    public bool paused = false;


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
            //UIController.Instance.UpdateTime(remainigTime);
            UIController.Instance.UpdateTime(MAX_TIME, remainigTime);
        }
        else if (remainigTime <= 0)
        {
            //UIController.Instance.UpdateTime(0);
            UIController.Instance.UpdateTime(MAX_TIME, 0);
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
                Pause();
            else
            {
                Resume();
            }
        }


	}

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        UIController.Instance.ShowPausePanel();
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        UIController.Instance.HidePausePanel();
    }

    public void Quit()
    {
        paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GoToNextLevel()
    {
        if (SceneManager.sceneCount == SceneManager.GetActiveScene().buildIndex)
        {
            Quit();
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        AudioManager.Instance.PlayVictory();
        gameOver = true;
    }
    

}
