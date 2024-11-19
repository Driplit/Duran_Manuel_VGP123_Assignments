using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DaggerAdd : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.CompareTag("Player"))
            {

                if (collision.TryGetComponent<IInventory>(out var inventory))
                {
                    inventory.Dager = inventory.Dager + 1;
                    print("Player has " + inventory.Dager);
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
