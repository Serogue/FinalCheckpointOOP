using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    BoxCollider2D backgroundCollider;

    [SerializeField] float initialX, endX;
    public float scrollSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        initialX = transform.position.x;
        endX = initialX - (backgroundCollider.size.x/2);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= endX)
        {
            transform.position = new Vector2(initialX, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - scrollSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
