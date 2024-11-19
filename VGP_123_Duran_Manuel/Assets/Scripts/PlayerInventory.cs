using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IInventory
{
    [SerializeField] public int Dager { get => _dager; set => _dager = value; }

    private int _dager = 0;
}