using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;

    public GameObject projectilePrefab;
    public Vector3 projectileOffset = new Vector2(1.04f, -0.25f);

    protected float speed;
    public float maxHull;
    public float currentHull; //no encapsulation without a backing field!
    protected float projectileSpeed;

    protected int damage;

    protected float rateOfFire;
    protected float timeToFire;



    // Start is called before the first frame update
    public virtual void Start()
    {
        GameManager.instance.player = gameObject.GetComponent<PlayerController>();
        playerRb = GetComponent<Rigidbody2D>();
        currentHull = maxHull;

    }

    // Update is called once per frame
    void Update()
    {
        timeToFire -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timeToFire <= 0)
        {
            Fire();
            timeToFire = rateOfFire;
        }
    }



    public void Fire()
    {
        Projectile projectile = projectilePrefab.GetComponent<Projectile>();
        projectile.damage = damage;
        projectile.dir = 1;
        projectile.speed = projectileSpeed;

        projectile.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 200);
        projectile.gameObject.tag = "Player";

        Instantiate(projectilePrefab, transform.position + projectileOffset, projectilePrefab.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision) //for projectiles
    {
        if (!collision.CompareTag("Player"))
        {
            GetDamaged(collision.gameObject.GetComponent<Projectile>().damage);
            
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(GameManager.instance.explosionPrefab, transform.position, GameManager.instance.explosionPrefab.transform.rotation);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //for ships
    {
        GetDamaged(collision.gameObject.GetComponent<AlienShip>().GetCollisionDamage());
        Instantiate(GameManager.instance.explosionPrefab, transform.position, GameManager.instance.explosionPrefab.transform.rotation);
        Destroy(collision.gameObject);
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 playerPos = transform.position;

        Vector2 newPos = new Vector2((horizontalInput * speed * Time.deltaTime), (verticalInput * speed * Time.deltaTime)) + playerPos;

        if (newPos.x < -GameManager.instance.xRange || newPos.x > GameManager.instance.xRange)
        {
            newPos.x = playerPos.x;
        }
        if (newPos.y < -GameManager.instance.yRange || newPos.y > GameManager.instance.yRange)
        {
            newPos.y = playerPos.y;

        }

        transform.position = newPos;
    }

    void GetDamaged(int damage) //or healed
        // using encapsulation causes stack overflow for some reasons
    {
        currentHull -= damage;
        if (currentHull > maxHull)
        {
            currentHull = maxHull;
        }
    }

}
