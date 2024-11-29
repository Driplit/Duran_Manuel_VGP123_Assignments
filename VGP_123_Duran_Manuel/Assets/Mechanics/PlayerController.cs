using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
//[RequireComponent(typeof(GroundCheck), typeof(Jump),typeof(Shoot))]
public class PlayerController : MonoBehaviour
{
    //Component References
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    GroundCheck gc;
    Jump jump;
    RedMushroom M_red;
    ManagePower power;

    //Movement variables
    [Range(3, 10)]
    public float speed = 5.5f;
    //Inventory

    public bool isBig = false;
    public bool isFire = false;
    public bool isDead = false;

    public bool isGrounded = false;
    //public bool isWalled = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gc = GetComponent<GroundCheck>();
        M_red = GetComponent<RedMushroom>();
        power = GetComponent<ManagePower>();
    }

    // Update is called once per frame
    void Update()
    {
        
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        Mushroom();
        

        float hInput = Input.GetAxis("Horizontal");
        IsGrounded();
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
        if (Input.GetButtonDown("Fire1")) anim.SetTrigger("Attack");

        //Jump attack will need later
        if (Input.GetButtonDown("Fire2")) anim.SetTrigger("ThrowAttack");
        //alternate way to sprite flip
        //if (hInput > 0 && sr.flipX || hInput < 0 && !sr.flipX) sr.flipX = !sr.flipX;
        anim.SetBool("onGround", isGrounded);
        anim.SetBool("Run", hInput != 0);
        anim.SetBool("isSmall", power.Small);
        anim.SetBool("isBig", power.Large);
        anim.SetBool("FireFlower", power.FireFlower);
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

    bool IsFalling()
    {
        rb.AddForce(Vector2.down * jump.jumpFallForce);
        return rb.velocity.y < 0;
    }
    bool IsRising()
    {
        return rb.velocity.y > 0;
    }
    bool Mushroom()
    {
        if (M_red.redMushroom == 1)
        {
            GrowEvent();
            return true;
        }
        else return false;
    }
    bool ET_Grow;
    bool ET_Shrink;
    void GrowEvent()
    {
        if (!ET_Grow) 
        {
            ET_Shrink= false;
            anim.SetTrigger("Grow");
            ET_Grow = true;
        }
    }
    void ShrinkEvent()
    {
        if(!ET_Shrink)
        {
            ET_Grow=false;
            anim.SetTrigger("Shrink");
            ET_Shrink = true;
        }
    }
}