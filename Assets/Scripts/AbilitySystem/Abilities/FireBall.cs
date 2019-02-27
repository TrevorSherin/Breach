using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ability{

    private const string abilityName = "FireBall";
    private const string abilityDescription = "A blast of fire that damages on impact";
    //private const Sprite icon = Resources.Load();

    public FireBall()
        :base(new BasicInfo(abilityName, abilityDescription))
    {
        this.Behaviours.Add(new Ranged(10f, 20f));
        this.Behaviours.Add(new AreaOfEffect(2f, 2.3f, 50f));
    }

}
