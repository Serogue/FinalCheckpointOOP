using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip2 : AlienShip
{

    private Vector2 moveDir;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        speedX = 3;
        speedY = 0;
        damage = 10;
        rateOfFire = 5;

        moveDir = (Vector2)transform.position - FindPlayerPos();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        TurnToPlayer();
    }

    public override void Move()
    {
        //Vector2 move = new Vector2(-speedX * Time.deltaTime, 0);
        transform.position = (Vector2)transform.position + moveDir.normalized * -speedX * Time.deltaTime;
    }

   
    private void TurnToPlayer()
    {
        Vector2 lookAt = (Vector2)transform.position - FindPlayerPos();

        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public override void Fire()
    {
        if (timeToFire <= 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timeToFire = rateOfFire;

        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
        
    }
}
