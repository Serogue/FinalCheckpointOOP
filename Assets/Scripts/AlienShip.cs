using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlienShip : MonoBehaviour // INHERITANCE
{
    protected int health = 1;
    protected float speedX = 1;
    protected float speedY = 1;

    [SerializeField] protected int damage = 1;
    protected float rateOfFire = 1;
    protected float timeToFire = 0.0f;

    protected Vector2 playerPos;

    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Vector2 projectileOffset;

    bool canFire = false; //don't spam when spawned



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        if (canFire)
        {
            Fire();
        }
        
    }

    //ABSTRACTION // POLYMORPHISM
    public virtual void Move()
    {
        Vector2 whereToY = Vector2.zero;

        if (FindPlayerPos().y - transform.position.y < 0)
        {
            whereToY = Vector2.down;
        }
        else
        {
            whereToY = Vector2.up;
        }

        transform.Translate(new Vector2(-speedX * Time.deltaTime, whereToY.y * speedY * Time.deltaTime));

    }

    protected Vector2 FindPlayerPos()
    {
        return GameManager.instance.playerPos;
    }

    //ABSTRACTION
    protected void OnTriggerEnter2D(Collider2D collision) //for projectiles
    {
        if (!collision.CompareTag("Enemy") && !collision.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            health -= collision.GetComponent<Projectile>().damage;

            if (health <= 0)
            {
                GameManager.instance.AddScore(damage);
                Instantiate(GameManager.instance.explosionPrefab, transform.position, GameManager.instance.explosionPrefab.transform.rotation);
                Destroy(gameObject);
            }
        }


    }

    public virtual void Fire() // POLYMORPHISM //ABSTRACTION
    {
        if (timeToFire <= 0)
        {
            Projectile projectile = projectilePrefab.GetComponent<Projectile>();
            projectile.damage = damage;
            projectile.dir = -1;
            projectile.speed = 10f;

            projectile.gameObject.GetComponent<SpriteRenderer>().color = new Color(200, 0, 0);
            projectile.gameObject.tag = "Enemy";

            Instantiate(projectilePrefab, transform.position, projectile.transform.rotation);

            timeToFire = rateOfFire;

        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
               

    }

    public int GetCollisionDamage() //ABSTRACTION
    {
        return damage;
    }

    private void OnBecameVisible()
    {
        canFire = true;
    }

    private void OnBecameInvisible()
    {
        canFire = false;
    }

}
