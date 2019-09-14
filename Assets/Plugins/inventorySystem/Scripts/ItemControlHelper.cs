using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControlHelper : MonoBehaviour
{

    public void DepositItem(InventoryItem item)
    {
        FindObjectOfType<Inventory>().DepositItem(item);
    }

    public void DeleteItem(InventoryItem item)
    {
        FindObjectOfType<Inventory>().DeleteItem(item);
    }

}
