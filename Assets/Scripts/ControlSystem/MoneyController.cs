using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour {

    private int money;
    private Text moneyText;

	// Use this for initialization
	void Start () {
        money = 0;
        moneyText = transform.GetChild(0).gameObject.GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMoney(int moneyToSet)
    {
        money = moneyToSet;
        moneyText.text = "GOLD: " + money;
    }

    public int CheckMoney
    {
        get { return money; } 
    }
}
