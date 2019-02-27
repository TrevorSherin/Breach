using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviours : MonoBehaviour
{
    private BasicInfo basicInfo;
    private BehaviourStartTimes startTime;

    public AbilityBehaviours(BasicInfo bBasicInfo, BehaviourStartTimes bStartTime)
    {
        basicInfo = bBasicInfo;
        startTime = bStartTime;
    }

    public enum BehaviourStartTimes
    {
        Beginning,
        Middle,
        End
    }

    public virtual void Activate(GameObject playerObject, GameObject objectHit)
    {

    }

    public BasicInfo BasicInfo
    {
        get { return basicInfo; }
    }

    public BehaviourStartTimes StartTime
    {
        get { return startTime; }
    }

}
