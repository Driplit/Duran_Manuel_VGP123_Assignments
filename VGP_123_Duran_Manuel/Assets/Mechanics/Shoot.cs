using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;


    [SerializeField] public Vector2 initalShotVelocity = Vector2.zero;
    [SerializeField] IInventory inventory;


    public Transform spawnPointRight;
    public Transform spawnPointLeft;

    public Projectile projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        inventory = GetComponent<IInventory>();


        if (initalShotVelocity == Vector2.zero)
        {
            Debug.Log("Initial shot velocity is zero, changing it to a default value");
            initalShotVelocity.x = 1.0f;
        }

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log($"Please set default values on the shoot script for {gameObject.name}");

    }

    public void Fire()
    {
        // Instantiate the projectile based on the facing direction
        Projectile curProjectile;
        if (!sr.flipX)
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            curProjectile.SetVelocity(initalShotVelocity);
        }
        else
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            curProjectile.SetVelocity(-initalShotVelocity);
        }
    }
}
