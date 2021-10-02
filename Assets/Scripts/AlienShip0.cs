using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip0 : AlienShip // INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        speedX = 15;
        speedY = 0;
        health = 1;
        damage = 5;

    }

    // POLYMORPHISM
    public override void Fire()
    {
        
    }

}
