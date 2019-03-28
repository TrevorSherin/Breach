using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SlowTower : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public float range = 4f;
    public float fireRate = 1f;
    public int cost;
    private float fireReload = 0f;
    private float spin = 0f;
    private float spinCounter = 0f;
    private int enemyCount;
    private Animator slowAnimator;

    [Header("Setup")]
    public string enemyTag = "enemy";
    public Transform partToRotate;
    //public float turnSpeed = 10f;
    //public GameObject bulletPrefab;
    //public Transform firePoint;


    void Start()
    {
        slowAnimator = this.GetComponent<Animator>();
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
                enemy.GetComponent<Enemy>().Slow();
            }
        }
    }

    void Update()
    {
        if (spinCounter <= 0)
        {
            slowAnimator.SetBool("IsActive", false);
            return;
        }
            
        spinCounter -= 1f * Time.deltaTime;
        slowAnimator.SetBool("IsActive", true);
        spin += 200 * Time.deltaTime;
        partToRotate.rotation = Quaternion.Euler(0f, spin, 0f);

    }

    public int towerCost
    {
        get { return cost; }
        set { cost = value; }
    }

    public float Range
    {
        get { return range; }
        set { range = value; }
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
