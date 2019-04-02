using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballMove : MonoBehaviour {
    private int enemiesHit;
    public int damage;
	// Use this for initialization
	void Start () {
        enemiesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemiesHit >= 3)
        {
            Destroy(gameObject);
        }
	}

    public void Shoot(Vector3 startPosition, float lifeDistance)
    {
        StartCoroutine(CheckDistance(startPosition, lifeDistance));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            enemiesHit++;
            other.gameObject.GetComponent<Enemy>().Hit(damage);
        }
    }
    
    private IEnumerator CheckDistance(Vector3 startPosition, float lifeDistance)
    {
        float tempDistance = Vector3.Distance(startPosition, gameObject.transform.position);

        while (tempDistance < lifeDistance)
        {
            gameObject.transform.position += transform.forward * Time.deltaTime * 20;
            tempDistance = Vector3.Distance(startPosition, gameObject.transform.position);

            yield return null;
        }

        GameObject.Destroy(gameObject);
        yield return null;
    }
}
