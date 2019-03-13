using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AreaOfEffect : AbilityBehaviours {

    private const string behaviourName = "Area of Effect";
    private const string behaviourDescription = "An area of effect attack";
    //private const Sprite icon = Resources.Load();

    private float areaRadius;
    private float effectDuration;
    private float effectDamage;
    private Stopwatch durationTimer = new Stopwatch();
    private bool isOccupied;
    private float damageTickDuration;
    private Camera mainCamera;


    public AreaOfEffect(float radius, float duration, float damage)
        : base(new BasicInfo(behaviourName, behaviourDescription))
    {
        areaRadius = radius;
        effectDuration = duration;
        effectDamage = damage;
        isOccupied = false;
    }

    public override void Activate(GameObject playerObject, GameObject abilityPrefab)
    {
        SphereCollider sc;
        Vector3 target = getTarget();
        if (abilityPrefab.GetComponent<SphereCollider>() == null)
            sc = abilityPrefab.AddComponent<SphereCollider>();
        else
            sc = abilityPrefab.GetComponent<SphereCollider>();

        sc.radius = areaRadius;
        sc.isTrigger = true;

        //StartCoroutine(AOE());
    }

    private IEnumerator AOE()
    {
        durationTimer.Start();

        while(durationTimer.Elapsed.TotalSeconds <= effectDuration)
        {
            if (isOccupied)
            {
                UnityEngine.Debug.Log("HIT");
            }

            yield return new WaitForSeconds(damageTickDuration);
        }

        durationTimer.Stop();
        durationTimer.Reset();

        yield return null;
    }

    private Vector3 getTarget()
    {
        mainCamera = FindObjectOfType<Camera>();
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        groundPlane.Raycast(cameraRay, out rayLength);
        return cameraRay.GetPoint(rayLength);
    }

    private void OnTriggerEnter(Collider other)
    {

        isOccupied = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
    }
}
