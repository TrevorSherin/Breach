using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHpController : MonoBehaviour {

    private float baseHP;
    private Text baseHpText;
    private bool baseAlive;
    private Image healthbar;

	// Use this for initialization
	void Start () {
        baseHP = 0;
        baseAlive = true;
        baseHpText = transform.GetChild(0).gameObject.GetComponent<Text>();
        healthbar = GameObject.Find("HealthBarImage").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void SetHP(int hpToSet)
    {
        baseHP = hpToSet;
        baseHpText.text = "Base Health: " + baseHP;
        healthbar.fillAmount = baseHP / 500f;
        if (baseHP == 0)
            baseAlive = false;
    }

    public float CheckHP
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
