using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : MonoBehaviour, IInventory
{
    [SerializeField] public int redMushroom { get => _redMushroom; set => _redMushroom = value; }

    private int _redMushroom = 0;
}