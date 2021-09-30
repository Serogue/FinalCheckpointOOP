using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f; //projectile speed
    public float dir; //1 for player, -1 for enemies
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = Vector2.right * dir * speed * Time.deltaTime;
        transform.position += moveTo;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
