using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHpController : MonoBehaviour {

    private int baseHP;
    private Text baseHpText;

	// Use this for initialization
	void Start () {
        baseHP = 0;
        baseHpText = transform.GetChild(0).gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHP(int moneyToSet)
    {
        baseHP = moneyToSet;
        baseHpText.text = "Base HP: " + baseHP;
    }

    public int CheckHP
    {
        get { return baseHP; }
    }
}
