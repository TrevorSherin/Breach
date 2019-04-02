using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private WaveSpawner waveSpawner;
    private bool isPaused;
    private int highscore;
    private GameObject gameOverPanel;
    private GameObject pauseMenu;
    private BaseHpController baseHpController;
    private PlayerMovement playerMoveScript;
    private ScoreController scoreController;

	// Use this for initialization
	void Start () {
        playerMoveScript = GameObject.Find("PlayerContainer").GetComponent<PlayerMovement>();
        pauseMenu = GameObject.Find("PauseMenu");
        waveSpawner = transform.GetComponent<WaveSpawner>();
        baseHpController = GameObject.Find("BaseInfo").GetComponent<BaseHpController>();
        scoreController = GameObject.Find("ScoreInfo").GetComponent<ScoreController>();
        pauseMenu.SetActive(false);
        isPaused = false;
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
        highscore = SaveLoadController.LoadScore();
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
        int score = scoreController.CheckScore;
        if (score > highscore)
        {
            highscore = score;
            SaveLoadController.SaveScore(highscore);
        }
        if (type == 1)
            gameOverPanel.GetComponentInChildren<Text>().text = "You Won\nScore: " + score + "\nHighscore: " + highscore;
        else
            gameOverPanel.GetComponentInChildren<Text>().text = "You Lost\nScore: " + score + "\nHighscore: " + highscore;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject tower in towers)
            Destroy(tower);
        foreach (GameObject enemy in enemies)
            Destroy(enemy);
        GameObject.Find("PlayerBase").GetComponent<PlayerBase>().ResetHealth();
        GameObject.Find("PlayerContainer").GetComponent<PlayerMovement>().Reset();
        this.GetComponent<GameUI>().Reset();
        baseHpController.Reset();
        waveSpawner.Reset();
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        if (isPaused)
            Pause();
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
        Application.Quit();
    }
}
