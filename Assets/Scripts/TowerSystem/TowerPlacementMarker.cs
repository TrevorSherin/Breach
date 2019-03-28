using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementMarker : MonoBehaviour {

    public Vector2 direction;
    private Vector3 startPosition;
    public Camera gameCamera;
    public GameObject tower;
    public float range;
    private int cost = 0;

    void Start()
    {
        startPosition = this.transform.position;
        gameCamera = GameObject.Find("GameCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        /*RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, direction);

        //If something was hit.
        if (hit.collider != null)
        {
            //Display the point in world space where the ray hit the collider's surface.
            this.transform.position = hit.point;
        }*/

        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //FaceCamera();
        
        if (Physics.Raycast (ray, out hitInfo))
        {
            this.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.05f, hitInfo.point.z);
        }

        if (Input.GetMouseButtonDown (0))
        {
            BuildTower();
            gameCamera.GetComponent<GameUI>().SetToNormalMode();
        }
    }
    
    private void FaceCamera()
    {
        Vector3 targetVector = this.transform.position - gameCamera.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, gameCamera.transform.rotation * Vector3.up);

    }

    public void SetTower(GameObject newTower)
    {
        float range;
        tower = newTower;
        if (tower.GetComponent<Tower>() != null)
        {
            cost = tower.GetComponent<Tower>().towerCost;
            range = tower.GetComponent<Tower>().Range;
            this.GetComponent<SpriteRenderer>().size = new Vector2(range, range);
        }
        if (tower.GetComponent<SlowTower>() != null)
        {
            cost = tower.GetComponent<SlowTower>().towerCost;
            range = tower.GetComponent<SlowTower>().Range;
            this.GetComponent<SpriteRenderer>().size = new Vector2(range, range);
        }
        if (tower.GetComponent<AoeTower>() != null)
        {
            cost = tower.GetComponent<AoeTower>().towerCost;
            range = tower.GetComponent<AoeTower>().Range;
            this.GetComponent<SpriteRenderer>().size = new Vector2(range, range);
        }
    }

    public void BuildTower()
    {
        GameObject.Find("GameCamera").GetComponent<GameUI>().useMoney(cost);
        Instantiate(tower, this.transform.position, new Quaternion(0,0,0,0));
    }

    public void Reset()
    {
        this.transform.position = startPosition;
    }
}
