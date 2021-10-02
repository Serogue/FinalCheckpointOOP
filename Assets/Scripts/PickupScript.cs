using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        damage = -3;
        dir = -1;
        gameObject.tag = "Pickup";
    }

}
