using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abilityButtons : MonoBehaviour {
    public KeyCode key;
    public GameObject playerObject;
    private AbilityUse a;
    private Image buttonImage;
    // Use this for initialization
    void Start () {
        buttonImage = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        a = playerObject.GetComponent<AbilityUse>();
	}
	
	// Update is called once per frame
	void Update () {
        if(buttonImage.fillAmount == 0)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                a.OnAbilityUse(gameObject);
            }
        }
	}
}
