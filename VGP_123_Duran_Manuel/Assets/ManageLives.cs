using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageLives : MonoBehaviour
{
    public int lives; // Set this in the Inspector or initialize here (e.g., lives = 3;)

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        // Initialize components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found!");
        }

        if (anim == null)
        {
            Debug.LogError("Animator not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Check if the player is falling and their position is above the enemy
            if (rb.velocity.y < 0 && transform.position.y > other.transform.position.y)
            {
                // Player landed on the enemy's head, don't decrease lives
                Debug.Log("Landed on enemy!");
                // Optional: Add logic to destroy the enemy or trigger its animation
            }
            else
            {
                // Player hit the enemy from the side or below
                lives--;
                CheckLives();
            }
        }
    }

    private void CheckLives()
    {
        // Check if lives are zero and load GameOver scene
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}