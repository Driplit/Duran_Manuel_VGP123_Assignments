using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundCheckLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        //creating ground check object - this assumes pivot is at bottom center
        if (!groundCheck)
        {
            Debug.Log("Hey, no ground check set - creating one assuming that the pivot is bottom center");
            GameObject newGameObject = new GameObject();
            newGameObject.transform.SetParent(transform);
            newGameObject.transform.localPosition = Vector3.zero;
            newGameObject.name = "GroundCheck";
            groundCheck = newGameObject.transform;
        }
    }

    public bool IsGrounded()
    {
        if (!groundCheck) return false;

        // Assuming groundCheck is the transform of the object where the ground detection happens
        // Assuming boxCollider is the BoxCollider2D component attached to your object
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (!boxCollider) return false;

        // Cast a box slightly below the collider to check for ground
        Vector2 boxCenter = (Vector2)groundCheck.position + boxCollider.offset;
        Vector2 boxSize = boxCollider.size;
        float raycastDistance = 0.1f; // Small distance below the collider
        Vector2 raycastDirection = Vector2.down; // Check downwards

        // Perform the BoxCast
        RaycastHit2D hit = Physics2D.BoxCast(boxCenter, boxSize, 0.1f, raycastDirection, raycastDistance, groundCheckLayerMask);

        // Return true if a collider was hit
        return hit.collider != null;
    }

}
