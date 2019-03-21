using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private WaveSpawner waveSpawner;
    private GameObject gameOverPanel;
    private BaseHpController baseHpController;

	// Use this for initialization
	void Start () {
        gameOverPanel = GameObject.Find("GameOverPanel");
        baseHpController = GameObject.Find("BaseHpPanel").GetComponent<BaseHpController>();
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
}
