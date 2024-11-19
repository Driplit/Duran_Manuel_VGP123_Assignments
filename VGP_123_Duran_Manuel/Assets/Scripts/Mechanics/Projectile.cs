using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private float lifetime = 2f;
    [SerializeField, Range(1, 10)] private float speed = 5f;
    private Animator anim;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool isWallHit = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        

    }
    private void Update()
    {

        if (rb.velocity.x != 0)
        {
            sr.flipX = rb.velocity.x < 0;
        }
        if (isWallHit)
        {
            Debug.Log("Projectile hit wall, freezing X position.");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            anim.SetBool("StuckInWall", true);
            return;
        }
        if(lifetime <=0)
        {
            Destroy(gameObject);
        }
    }

    public void SetVelocity(Vector2 velocity) => rb.velocity = velocity * speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            // Log when it hits the wall
            Debug.Log("Projectile hit the wall.");

            // Set the flag and update animation
            isWallHit = true;
            anim.SetBool("Wall", true);
        }
        else
        {
            anim.SetBool("Wall", false);
        }
    }
}