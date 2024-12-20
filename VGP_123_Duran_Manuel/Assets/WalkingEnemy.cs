using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkingEnemy : Enemy
{
    private Rigidbody2D rb;

    [SerializeField] private float xVel;

    public override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;

        if (xVel <= 0) xVel = 3;
    }

    private void Update()
    {
        rb.velocity = (sr.flipX) ? new Vector2(-xVel, rb.velocity.y) : new Vector2(xVel, rb.velocity.y);
    }

    public override void TakeDamage(int damageValue)
    {
        if (damageValue >= 9999)
        {
            anim.SetTrigger("Squish");
            Destroy(transform.parent.gameObject, 0.5f);
            return;
        }

        base.TakeDamage(damageValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            sr.flipX = !sr.flipX;
        }
    }
}
