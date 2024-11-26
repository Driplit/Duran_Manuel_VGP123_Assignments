//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerInventory : MonoBehaviour, IInventory
//{
//    private Dictionary<ItemType, int> inventory = new Dictionary<ItemType, int>();

//    public bool HasItem(ItemType itemType)
//    {
//        return inventory.ContainsKey(itemType) && inventory[itemType] > 0;
//    }

//    public void AddItem(ItemType itemType)
//    {
//        if (inventory.ContainsKey(itemType))
//        {
//            inventory[itemType]++;
//        }
//        else
//        {
//            inventory[itemType] = 1;
//        }

//        Debug.Log($"Inventory updated: {itemType} count = {inventory[itemType]}");
//    }
//}