using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AoeTower : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public float range = 4f;
    public float tickRate = 1f;
    private float tickReload = 0f;
    private float spin = 0f;
    public int damage = 5;
    private float spinCounter = 0f;
    private int enemyCount;

    [Header("Setup")]
    public string enemyTag = "enemy";
    public Transform partToRotate;
    //public float turnSpeed = 10f;
    //public GameObject bulletPrefab;
    //public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        enemyCount = 0;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemy != null && distanceToEnemy <= range)
            {
                Spin();
                if (tickReload <= 0f)
                {
                    enemy.GetComponent<Enemy>().Hit(damage);
                    tickReload = 1f / tickRate;
                }
                tickReload -= 0.5f;
            }
        }
    }

    void Update()
    {
        if (spinCounter <= 0)
            return;
        spinCounter -= 1f * Time.deltaTime;
        spin += 200 * Time.deltaTime;
        partToRotate.rotation = Quaternion.Euler(0f, spin, 0f);

    }

    public void Spin()
    {
        spinCounter = 1f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
