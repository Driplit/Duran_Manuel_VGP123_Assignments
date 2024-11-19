using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEditor.Tilemaps;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public Sprite[] pickupSprites;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(1,pickupSprites.Length);

        sr.sprite = pickupSprites[randomIndex];

    }
}
