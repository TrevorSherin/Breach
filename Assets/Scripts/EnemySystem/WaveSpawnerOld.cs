using System;
using UnityEngine;
using System.Collections;

public class WaveSpawnerOld : MonoBehaviour {

    public Transform enemy;

    public Transform spawnPoint;

    public float timer = 5f;
    private float first = 2f;
    private int waveNo = 0;
    private bool gameOver = false;

    void Update()
    {
        if (first <= 0f)
        {
            StartCoroutine(SpawnWave());
            first = timer;
        }
        first -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNo++;
        for (int i = 0; i < waveNo; i++)
        {
            if (gameOver)
                break;
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        } 
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public void NewGame()
    {
        gameOver = false;
        waveNo = 0;
    }
}
