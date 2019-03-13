using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviours : MonoBehaviour
{
    private BasicInfo basicInfo;

    public AbilityBehaviours(BasicInfo bBasicInfo)
    {
        basicInfo = bBasicInfo;
    }

    public virtual void Activate(GameObject playerObject, GameObject objectHit)
    {

    }

    public BasicInfo BasicInfo
    {
        get { return basicInfo; }
    }
}
