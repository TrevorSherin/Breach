using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour {
    public bool building = false;
    public GameUI gameCamera;
    public int cost;
    public GameObject tower;

	// Use this for initialization
	void Start () {
        gameCamera = GameObject.Find("GameCamera").GetComponent<GameUI>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void TryBuild()
    {
        gameCamera.TryBuilding(cost, tower);
    }

    public void SetBuilding()
    {
        building = true;
    }

    public void SetNotBuilding()
    {
        building = false;
    }

    public bool IsBuilding()
    {
        return building;
    }
}
