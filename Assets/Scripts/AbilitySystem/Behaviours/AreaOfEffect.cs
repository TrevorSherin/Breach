using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AreaOfEffect : AbilityBehaviours {

    private const string behaviourName = "Area of Effect";
    private const string behaviourDescription = "An area of effect attack";
    private const BehaviourStartTimes startTime = BehaviourStartTimes.Beginning;
    //private const Sprite icon = Resources.Load();

    private float areaRadius;
    private float effectDuration;
    private float effectDamage;
    private Stopwatch durationTimer = new Stopwatch();
    private bool isOccupied;
    private float damageTickDuration;


    public AreaOfEffect(float radius, float duration, float damage)
        : base(new BasicInfo(behaviourName, behaviourDescription), startTime)
    {
        areaRadius = radius;
        effectDuration = duration;
        effectDamage = damage;
        isOccupied = false;
    }

    public override void Activate(GameObject playerObject, GameObject objectHit)
    {
        SphereCollider sc;
        if (this.gameObject.GetComponent<SphereCollider>() == null)
            sc = this.gameObject.AddComponent<SphereCollider>();
        else
            sc = this.gameObject.GetComponent<SphereCollider>();

        sc.radius = areaRadius;
        sc.isTrigger = true;

        StartCoroutine(AOE());
    }

    private IEnumerator AOE()
    {
        durationTimer.Start();

        while(durationTimer.Elapsed.TotalSeconds <= effectDuration)
        {
            if (isOccupied)
            {
                //do damage
            }

            yield return new WaitForSeconds(damageTickDuration);
        }

        durationTimer.Stop();
        durationTimer.Reset();

        yield return null;
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
