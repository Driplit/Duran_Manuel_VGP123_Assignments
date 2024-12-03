using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private Transform PlayerFeet;
    [SerializeField] private float bounceForce = 5f; // Adjust the bounce force as needed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a Rigidbody2D
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Check the collision direction
            ContactPoint2D[] contacts = collision.contacts;
            foreach (var contact in contacts)
            {
                // Check if the collision is from below the platform
                if (contact.normal.y > 0.5f) // Adjust this threshold as needed
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0); // Reset Y velocity
                    rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse); // Add bounce force
                    break;
                }
            }
        }
    }
}
