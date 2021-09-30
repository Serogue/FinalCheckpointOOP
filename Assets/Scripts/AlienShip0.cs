using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip0 : AlienShip
{
    // Start is called before the first frame update
    void Start()
    {
        speedX = 20;
        speedY = 0;
        health = 1;
        damage = 5;

    }

    public override void Fire()
    {
        
    }

}
