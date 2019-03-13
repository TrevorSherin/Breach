using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class Ranged : AbilityBehaviours {

    private const string behaviourName = "Ranged";
    private const string behaviourDescription = "A ranged attack";
    //private const Sprite icon = Resources.Load();

    private float minDistance;
    private float maxDistance;
    private float lifeDistance;
    private Vector3 direction;
    private Camera mainCamera;

    public Ranged(float minDist, float maxDist)
        :base(new BasicInfo(behaviourName, behaviourDescription))
    {
        minDistance = minDist;
        maxDistance = maxDist;

    }

    public override void Activate(GameObject playerObject, GameObject abilityPrefab)
    {
        lifeDistance = maxDistance;
        Vector3 target = getTarget();
        abilityPrefab.transform.LookAt(new Vector3(target.x, abilityPrefab.transform.position.y, target.z));
        //Job.Make(CheckDistance(playerObject.transform.position, abilityPrefab), true);
        //StartCoroutine(abilityPrefab.GetComponent<fireballMove>().CheckDistance(playerObject.transform.position, lifeDistance));
        abilityPrefab.GetComponent<fireballMove>().Shoot(playerObject.transform.position, lifeDistance);
    }

    /*private IEnumerator CheckDistance(Vector3 startPosition, GameObject abilityPrefab)
    {
        float tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);

        while (tempDistance < lifeDistance)
        {
            abilityPrefab.transform.position += transform.forward * Time.deltaTime * 10;
            tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);

            yield return null;
        }

        GameObject.Destroy(abilityPrefab);
        yield return null;
    }*/

    private Vector3 getTarget()
    {
        mainCamera = FindObjectOfType<Camera>();
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        groundPlane.Raycast(cameraRay, out rayLength);
        return cameraRay.GetPoint(rayLength);
    }

    public float MinDistance
    {
        get { return minDistance;  }
    }

    public float MaxDistance
    {
        get { return maxDistance; }
    }
}
