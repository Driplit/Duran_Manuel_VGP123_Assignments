using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCheck : MonoBehaviour
{
    [SerializeField] private Transform ledgeCheck;
    [SerializeField, Range(0.01f, 1)] private float ledgeCheckRadius = 0.02f;
    [SerializeField] private LayerMask ledgeCheckLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        //creating ground check object - this assumes pivot is at bottom center
        if (!ledgeCheck)
        {
            Debug.Log("Hey, no ground check set - creating one assuming that the pivot is bottom center");
            GameObject newGameObject = new GameObject();
            newGameObject.transform.SetParent(transform);
            newGameObject.transform.localPosition = Vector3.zero;
            newGameObject.name = "LedgeCheck";
            ledgeCheck = newGameObject.transform;
        }
    }

    public bool IsLedged()
    {
        if (!ledgeCheck) return false;
        return Physics2D.OverlapCircle(ledgeCheck.position, ledgeCheckRadius, ledgeCheckLayerMask);
    }
}
