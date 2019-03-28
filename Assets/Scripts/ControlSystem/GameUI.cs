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
    public int money;
    private int startingMoney;
    private MoneyController moneyController;
    private BaseHpController baseHpController;
    private int baseHealth;

    void SetState(State newState)
    {
        if (state == newState)
        {
            return;
        }
        state = newState;
    }

    public void TryBuilding(int towerCost, GameObject towerType)
    {
        if (money >= towerCost)
        {
            towerMarker.GetComponent<TowerPlacementMarker>().SetTower(towerType);
            SetToBuildMode();
        }
    }

    public void SetToBuildMode()
    {
        if (state != State.Building)
        {
            SetState(State.Building);
            CreateTowerMarker();
        }
    }

    public void SetToNormalMode()
    {
        if (state != State.Normal)
        {
            SetState(State.Normal);
        }
        DestroyTowerMarker();
    }

    void CreateTowerMarker()
    {
        towerMarker.SetActive(true);
    }

    void DestroyTowerMarker()
    {
        towerMarker.SetActive(false);
    }

    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }

    public void useMoney(int moneyToUse)
    {
        money -= moneyToUse;
    }


    // Use this for initialization
    void Start ()
    {
        baseHealth = 0;
        moneyController = GameObject.Find("GoldInfo").GetComponent<MoneyController>();
        baseHpController = GameObject.Find("BaseInfo").GetComponent<BaseHpController>();
        startingMoney = money = 500;
        towerMarker.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == State.Building)
            {
                SetToNormalMode();
            }
        }
        if (baseHealth != GameObject.Find("PlayerBase").GetComponent<PlayerBase>().GetHealth)
        {
            baseHealth = GameObject.Find("PlayerBase").GetComponent<PlayerBase>().GetHealth;
            baseHpController.SetHP(baseHealth);
        }

        if (baseHealth == 0)
        {
            //Game Over!
        }

        if (moneyController.CheckMoney != money)
        {
            moneyController.SetMoney(money);
        }

        if (state == State.Building)
        {
            //if
        }
    }
    public void Reset()
    {
        SetToNormalMode();
        money = startingMoney;
    }
}
