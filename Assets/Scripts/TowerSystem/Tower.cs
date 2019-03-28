using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    public float range = 4f;
    public float fireRate = 1f;
    private float fireReload = 0f;
    public int cost;

    [Header("Setup")]
    public string enemyTag = "enemy";
    public Transform headPivot;
    public Transform cannonPivot;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private Animator projAnimator;


    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        projAnimator = this.GetComponentInChildren<Animator>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    
	void Update () {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(headPivot.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        headPivot.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //Vector3 cannonRotation = Quaternion.Lerp(cannonPivot.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //cannonPivot.rotation = Quaternion.Euler(rotation.x, cannonPivot.rotation.y, cannonPivot.rotation.z);

        if (fireReload <= 0f)
        {
            projAnimator.ResetTrigger("Shoot");
            projAnimator.SetTrigger("Shoot");
            Shoot();
            fireReload = 1f / fireRate;
        }
        fireReload -= Time.deltaTime;

	}

    void Shoot()
    {
        GameObject bulletObj = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Chase(target);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
