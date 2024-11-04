using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterInventory : MonoBehaviour, IInventory
{
    public int Dager { get => _dager; set => _dager = value; }

    private int _dager = 0;
}