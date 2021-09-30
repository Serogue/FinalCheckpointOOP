using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;

    public GameObject projectilePrefab;
    public Vector3 projectileOffset = new Vector2(1.04f, -0.25f);

    public float speed = 10;
    public float maxHull = 5;
    public float currentHull;

    public int damage = 2;



    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = gameObject.GetComponent<PlayerController>();
        playerRb = GetComponent<Rigidbody2D>();
        currentHull = maxHull;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void Fire()
    {
        Projectile projectile = projectilePrefab.GetComponent<Projectile>();
        projectile.damage = damage;
        projectile.dir = 1;
        projectile.speed = 20f;
        
        projectile.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 200);
        projectile.gameObject.tag = "Player";

        Instantiate(projectilePrefab, transform.position + projectileOffset, projectilePrefab.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) //for projectiles
    {
        if (collision.CompareTag("Enemy"))
        {
            currentHull -= collision.gameObject.GetComponent<Projectile>().damage;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //for ships
    {
        currentHull -= collision.gameObject.GetComponent<AlienShip>().GetCollisionDamage();
        Destroy(collision.gameObject);
    }



}
