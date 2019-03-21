﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { Spawning, Waiting, Completed, Ready };

    [System.Serializable]
	public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.Completed;
    private bool gameOver = false;
    private GameObject nextWaveButton;
    private Text waveInfo;
    private bool gameWon = false;


    void Start()
    {
        nextWaveButton = GameObject.Find("NextWaveButton");
        nextWaveButton.SetActive(true);
        waveInfo = GameObject.Find("WaveInfo").GetComponent<Text>();
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (!gameOver)
        {
            if (state == SpawnState.Waiting)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (state == SpawnState.Completed && !gameOver)
            {
                DisplayButton();
            }

            if (state != SpawnState.Ready)
                return;

            if (waveCountdown <= 0)
            {
                waveInfo.text = "";
                if (state != SpawnState.Spawning)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveInfo.text = Math.Ceiling(waveCountdown).ToString();
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Over.");
        state = SpawnState.Completed;

        if (nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("GameOver");
            gameWon = true;
            gameOver = true;
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log("Spawning Wave: " + wave.name);
        state = SpawnState.Spawning;

        for(int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void DisplayButton()
    {
        nextWaveButton.SetActive(true);
    }
    
    public void StartNextWave()
    {
        nextWaveButton.SetActive(false);
        state = SpawnState.Ready;
        waveCountdown = timeBetweenWaves;
    }

    public bool IsGameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public bool IsGameWon
    {
        get { return gameWon; }
        set { gameWon = value; }
    }

    void SpawnEnemy(Transform enemy)
    {
        Debug.Log("Spawning Enemy: " + enemy.name);
        Transform sp = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
}