using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHpController : MonoBehaviour {

    private int baseHP;
    private Text baseHpText;
    private bool baseAlive;

	// Use this for initialization
	void Start () {
        baseHP = 0;
        baseAlive = true;
        baseHpText = transform.GetChild(0).gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void SetHP(int hpToSet)
    {
        baseHP = hpToSet;
        baseHpText.text = "Base HP: " + baseHP;
        if (baseHP == 0)
            baseAlive = false;
    }

    public int CheckHP
    {
        get { return baseHP; }
    }

    public bool IsBaseAlive
    {
        get { return baseAlive; }
        set { baseAlive = value; }
    }

    public void Reset()
    {
        baseAlive = true;
    }
}
