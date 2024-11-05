using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private float lifetime;
    [SerializeField, Range(1, 10)] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0) lifetime = 2;
        Destroy(gameObject, lifetime);
    }

    public void SetVelocity(Vector2 velocity)
    {
        GetComponent<Rigidbody2D>().velocity = velocity * speed;
    }
}
