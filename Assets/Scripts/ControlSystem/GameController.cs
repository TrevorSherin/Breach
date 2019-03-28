using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private WaveSpawner waveSpawner;
    private bool isPaused;
    private GameObject gameOverPanel;
    private GameObject pauseMenu;
    private BaseHpController baseHpController;
    private PlayerMovement playerMoveScript;

	// Use this for initialization
	void Start () {
        playerMoveScript = GameObject.Find("PlayerContainer").GetComponent<PlayerMovement>();
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        isPaused = false;
        gameOverPanel = GameObject.Find("GameOverPanel");
        baseHpController = GameObject.Find("BaseInfo").GetComponent<BaseHpController>();
        gameOverPanel.SetActive(false);
        waveSpawner = transform.GetComponent<WaveSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		if (waveSpawner.IsGameOver)
        {
            GameOver(1);
        }
        if (!baseHpController.IsBaseAlive)
        {
            GameOver(0);
        }
	}

    void GameOver(int type)
    {
        if (type == 1)
            gameOverPanel.GetComponentInChildren<Text>().text = "You Won";
        else
            gameOverPanel.GetComponentInChildren<Text>().text = "You Lost";

        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        foreach (GameObject tower in towers)
            Destroy(tower);
        GameObject.Find("PlayerBase").GetComponent<PlayerBase>().ResetHealth();
        GameObject.Find("PlayerContainer").GetComponent<PlayerMovement>().Reset();
        this.GetComponent<GameUI>().Reset();
        baseHpController.Reset();
        waveSpawner.Reset();
        gameOverPanel.SetActive(false);
    }

    public void Pause()
    {
        if(isPaused)
        {
            playerMoveScript.enabled = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            playerMoveScript.enabled = false;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void Quit()
    {

    }
}
