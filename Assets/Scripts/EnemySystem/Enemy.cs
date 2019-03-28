using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform _destination;
    public float maxHealth;
    public float health;
    public float speed;
    public bool isSlowed;
    private float slowTime;
    private Animator animator;
    private float animatorSpeed;
    private Canvas healthCanvas;
    private Image healthImage;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start ()
    {
        healthCanvas = GetComponentInChildren<Canvas>();
        healthImage = GetComponentInChildren<Image>();
        animator = this.GetComponent<Animator>();
        maxHealth = health;
        animatorSpeed = animator.speed;
        _destination = GameObject.Find("PlayerBase").transform;
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
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
        healthImage.fillAmount = health / maxHealth;
        healthCanvas.transform.forward = Camera.main.transform.forward;
        if (slowTime > 0)
        {
            slowTime -= 1f * Time.deltaTime;
            SetSpeed(speed / 2);
            animator.speed = animatorSpeed / 2;
        }
        else
        {
            SetSpeed(speed);
            animator.speed = animatorSpeed;
        }
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
