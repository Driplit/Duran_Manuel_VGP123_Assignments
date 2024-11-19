using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public LayerMask wallLayer; // Define which layer is considered "Wall"
    public float slideSpeed = 2f; // Speed of sliding down the wall
    public float wallCheckDistance = 0.5f; // Distance to check for walls

    private Rigidbody2D rb;
    private bool isSliding;
    private bool isTouchingWall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckForWall();
        HandleWallSlide();
    }

    private void CheckForWall()
    {
        // Raycast to check if the player is touching a wall
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left; // Check in the facing direction
        isTouchingWall = Physics2D.Raycast(transform.position, direction, wallCheckDistance, wallLayer);
    }

    private void HandleWallSlide()
    {
        if (isTouchingWall && rb.velocity.y < 0) // Player is touching a wall and moving downwards
        {
            isSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, -slideSpeed); // Set the slide speed

        }
        else
        {
            isSliding = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the wall check ray in the editor
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction * wallCheckDistance);
    }
}