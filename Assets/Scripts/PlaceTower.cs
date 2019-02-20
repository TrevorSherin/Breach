using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour {
    public bool building = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void SetBuilding()
    {
        building = true;
    }

    public bool IsBuilding()
    {
        return building;
    }
}
