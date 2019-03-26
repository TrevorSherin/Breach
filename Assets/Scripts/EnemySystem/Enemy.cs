using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    public int health;
    public float speed;
    public bool isSlowed;
    private float slowTime;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start ()
    {
        _destination = GameObject.Find("PlayerBase").transform;
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        health = 50;
        slowTime = 0f;
        isSlowed = false;
        if (_navMeshAgent == null)
        {
            //Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
        
    }

    void Update()
    {
        if (slowTime > 0)
        {
            slowTime -= 1f * Time.deltaTime;
            SetSpeed(speed / 2);
        }
        else
            SetSpeed(speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBase>() != null)
        {
            other.gameObject.GetComponent<PlayerBase>().Attack(25);
            Destroy(gameObject);
        }
    }

    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    public bool IsSlowed
    {
        get { return isSlowed; }
        set { isSlowed = value; }
    }

    public void Slow()
    {
        slowTime = 1f;
    }

    private void SetSpeed(float speedToSet)
    {
        _navMeshAgent.speed = speedToSet;
    }

    public void Hit(int damage)
    {
        //_navMeshAgent.
        health -= damage;
        if (health <= 0)
        {
            GameObject.Find("GameCamera").GetComponent<GameUI>().addMoney(20);
            Destroy(gameObject);
        }
    }
}
