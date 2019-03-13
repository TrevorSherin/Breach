using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability{

    private BasicInfo basicInfo;
    private List<AbilityBehaviours> behaviours;
    private bool requiresTarget;
    private bool canCastOnSelf;
    private float cooldown;
    private GameObject abilityPrefab;
    private float castTime;
    private float cost;

    public Ability(BasicInfo aBasicInfo)
    {
        basicInfo = aBasicInfo;
        behaviours = new List<AbilityBehaviours>();
        cooldown = 3f;
        requiresTarget = false;
        canCastOnSelf = false;
    }

    public Ability(BasicInfo aBasicInfo, List<AbilityBehaviours> aBehaviours)
    {
        basicInfo = aBasicInfo;
        behaviours = aBehaviours;
        cooldown = 0f;
        requiresTarget = false;
        canCastOnSelf = false;
    }

    public Ability(BasicInfo aBasicInfo, List<AbilityBehaviours> aBehaviours, float aCooldown, GameObject aPrefab)
    {
        basicInfo = aBasicInfo;
        behaviours = aBehaviours;
        cooldown = aCooldown;
        requiresTarget = false;
        canCastOnSelf = false;
        abilityPrefab = aPrefab;
    }

    public BasicInfo BasicInfo
    {
        get { return basicInfo; }
    }

    public List<AbilityBehaviours> Behaviours
    {
        get { return behaviours; }
    }

    public float Cooldown
    {
        get { return cooldown; }
    }

    public GameObject AbilityPrefab
    {
        set { abilityPrefab = value; }
    }

    public virtual void Activate(GameObject player)
    {
        foreach (AbilityBehaviours b in Behaviours)
        {
            b.Activate(player, abilityPrefab);
        }
    }
}
