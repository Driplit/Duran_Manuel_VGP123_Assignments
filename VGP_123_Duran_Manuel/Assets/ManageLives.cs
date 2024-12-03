using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageLives : MonoBehaviour
{
    public int lives;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {

        GetComponent<Rigidbody2D>();
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            lives--;
        }
        
    }
    private void Dead()
    {
        if (lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
