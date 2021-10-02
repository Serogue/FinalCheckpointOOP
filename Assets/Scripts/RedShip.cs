using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShip : PlayerController
{
    // Start is called before the first frame update
    public override void Start()
    {
        speed = 10;
        maxHull = 5;
        damage = 1;
        projectileSpeed = 20f;
        rateOfFire = 0.2f;
        base.Start();
    }

}
