using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public enum State
    {
        Normal,
        Building
    }

    public State state { get; private set; }
    public GameObject towerMarker;
    PlaceTower buildButton;

    void SetState(State newState)
    {
        if (state == newState)
        {
            return;
        }
        state = newState;
    }

    public void SetToBuildMode()
    {
        if (state != State.Building)
        {
            SetState(State.Building);
            CreateTowerMarker();
        }
    }

    void CreateTowerMarker()
    {
        Instantiate(towerMarker);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        buildButton = GameObject.Find("BuildTowerButton").GetComponent<PlaceTower>();
        if (buildButton.IsBuilding())
        {
            SetToBuildMode();
        }
	}
}
