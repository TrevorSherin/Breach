using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementMarker : MonoBehaviour {

    public Vector2 direction;
    public Camera gameCamera;
    public GameObject tower;

    void Start()
    {
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
            this.transform.position = hitInfo.point;
        }

        if (Input.GetMouseButtonDown (0))
        {
            BuildTower();
        }
    }

    private void FaceCamera()
    {
        Vector3 targetVector = this.transform.position - gameCamera.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, gameCamera.transform.rotation * Vector3.up);

    }

    public void BuildTower()
    {
        Instantiate(tower, this.transform.position, new Quaternion(0,0,0,0));
    }
}
