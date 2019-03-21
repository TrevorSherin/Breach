using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {
    private int startingHealth;
    private int health;

	// Use this for initialization
	void Start () {
        startingHealth = health = 500;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack(int atk)
    {
        if (health >= atk)
            health -= atk;
        else health = 0;
    }

    public int GetHealth
    {
        get { return health; }
    }

    public void ResetHealth()
    {
        health = startingHealth;
    }
}
