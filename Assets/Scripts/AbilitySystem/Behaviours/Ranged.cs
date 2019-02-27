using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class Ranged : AbilityBehaviours {

    private const string behaviourName = "Ranged";
    private const string behaviourDescription = "A ranged attack";
    private const BehaviourStartTimes startTime = BehaviourStartTimes.Beginning;
    //private const Sprite icon = Resources.Load();

    private float minDistance;
    private float maxDistance;
    private float lifeDistance;

    public Ranged(float minDist, float maxDist)
        :base(new BasicInfo(behaviourName, behaviourDescription), startTime)
    {
        minDistance = minDist;
        maxDistance = maxDist;

    }

    public override void Activate(GameObject playerObject, GameObject abilityPrefab)
    {
        lifeDistance = maxDistance;
        //Job.Make(CheckDistance(playerObject.transform.position, abilityPrefab), true);
        StartCoroutine(CheckDistance(playerObject.transform.position, abilityPrefab));
    }

    private IEnumerator CheckDistance(Vector3 startPosition, GameObject abilityPrefab)
    {
        float tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);
        while (tempDistance < lifeDistance)
        {
            tempDistance = Vector3.Distance(startPosition, abilityPrefab.transform.position);

            yield return null;
        }

        GameObject.Destroy(abilityPrefab);
        yield return null;
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
