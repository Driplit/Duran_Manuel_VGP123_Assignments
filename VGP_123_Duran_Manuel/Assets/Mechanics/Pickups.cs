using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int effect; 
    public Sprite[] pickupSprites;
    private SpriteRenderer sr;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        

        sr.sprite = pickupSprites[effect];

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup(collision);
        }
    }
    void Pickup(Collider2D player)
    {
        ManagePower power = player.GetComponent<ManagePower>();
        power.Large = true;
        gameObject.SetActive(false);
    }
}
