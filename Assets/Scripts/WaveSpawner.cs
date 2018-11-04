using System;
using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public Transform enemy;

    public Transform spawnPoint;

    public float timer = 5f;
    private float first = 2f;
    private int waveNo = 0;

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
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        } 
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
