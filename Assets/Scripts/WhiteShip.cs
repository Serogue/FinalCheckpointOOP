using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteShip : PlayerController
{
    // Start is called before the first frame update
    public override void Start()
    {
        speed = 5;
        maxHull = 10;
        damage = 3;
        projectileSpeed = 10f;
        rateOfFire = 0.4f;
        projectileOffset = new Vector2(0.65f, -0.34f);
        base.Start();
    }


}
