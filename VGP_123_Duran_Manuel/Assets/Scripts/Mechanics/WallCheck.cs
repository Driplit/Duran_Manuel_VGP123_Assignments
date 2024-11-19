using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    Rigidbody2D rb;
    GroundCheck gc;
    Animator anim;
    [SerializeField] private Transform wallCheck;
    [SerializeField, Range(0.01f, 1)] private float wallCheckRadius = 0.2f;
    [SerializeField] private LayerMask wallCheckLayerMask;
    [Range(3, 10)]
    public float wallSlidingSpeed = 3f;
    public bool isWallSliding = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = GetComponent<GroundCheck>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
        //creating wall check object - this assumes pivot is at bottom center
        if (!wallCheck)
        {
            Debug.Log("Hey, no wall check set - creating one assuming that the pivot is bottom center");
            GameObject newGameObject = new GameObject();
            newGameObject.transform.SetParent(transform);
            newGameObject.transform.localPosition = Vector3.zero;
            newGameObject.name = "WallCheck";
            wallCheck = newGameObject.transform;
        }
    }
    private void Update()
    {
        
        WallSlide();
        anim.SetBool("WallSliding",isWallSliding);
    }
    public bool IsWalled()
    {
        if (!wallCheck) return false;
        return Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallCheckLayerMask);
    }
   
    
    private void WallSlide()
    {
        if (IsWalled() && !gc.IsGrounded() && rb.velocity.y <0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
        }
        else
        {
            isWallSliding = false;
        }
    }
}
