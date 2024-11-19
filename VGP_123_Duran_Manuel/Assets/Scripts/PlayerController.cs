using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent(typeof(GroundCheck), typeof(Jump), typeof(Shoot))]
public class PlayerController : MonoBehaviour
{
    //Component References
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    GroundCheck gc;
    WallCheck wc;
    WallSlide ws;
    LedgeCheck lc;

    //Movement variables
    [Range(3, 10)]
    public float speed = 5.5f;
    [Range(3, 10)]
    public float jumpForce = 3f;
    


    public bool isGrounded = false;
    public bool isSliding = false;
    public bool isLedged = false;
    //public bool isWalled = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gc = GetComponent<GroundCheck>();
        wc = GetComponent<WallCheck>();
        lc =  GetComponent<LedgeCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        IsGrounded();
        
        

        float hInput = Input.GetAxis("Horizontal");

        if (curPlayingClips.Length > 0)
        {
            if (!(curPlayingClips[0].clip.name == "Player_Attack"))
            {
                rb.velocity = new Vector2(hInput * speed, rb.velocity.y);
            }
            else 
            {
                rb.velocity = new Vector2(hInput * speed, 0);
            }

        }

        //sprite flipping
        if (hInput != 0) sr.flipX = (hInput < 0);

        //inputs for firing and jump attack
        if (Input.GetButtonDown("Fire1") && isGrounded) anim.SetTrigger("Attack");

        //Jump attack will need later
        if (Input.GetButtonDown("Fire2")) anim.SetTrigger("ThrowAttack");
        //alternate way to sprite flip
        //if (hInput > 0 && sr.flipX || hInput < 0 && !sr.flipX) sr.flipX = !sr.flipX;

        anim.SetBool("Run", hInput != 0);
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("Falling",IsFalling() && !isGrounded);
        anim.SetBool("Rising",IsRising() && !isGrounded);
        anim.SetBool("OnWall", isSliding);
        //anim.SetBool("LedgeGrab", isLedged);


    }

    private void IsGrounded()
    {
        if (!isGrounded)
        {
            if (rb.velocity.y <= 0) isGrounded = gc.IsGrounded();
        }
        else isGrounded = gc.IsGrounded(); 
    }
    private void IsWalled()
    {
        if (!isSliding)
        {
            if (rb.velocity.y <= 0) isSliding = wc.IsWalled();
        }
        else isSliding = wc.IsWalled();
    }
    //private void IsLedged()
    //{
    //    if (!isLedged)
    //    {
    //        if(rb.velocity.y <= 0) isLedged = lc.IsLedged();
    //    }
    //    else isLedged = lc.IsLedged();
    //}
    bool IsFalling()
    {
        return rb.velocity.y < 0;
    }
    bool IsRising()
    {
        return rb.velocity.y > 0;
    }


    //bool HasDager()
    //{
    //    return IInventory.
    //}
}