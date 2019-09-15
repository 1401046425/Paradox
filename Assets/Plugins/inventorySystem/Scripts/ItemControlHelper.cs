using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControlHelper : MonoBehaviour
{
    private Inventory Master;

    private void Awake()
    {
        Master = FindObjectOfType<Inventory>();
    }

    public void DepositItem(InventoryItem item)
    {
        Master.DepositItem(item);
    }

    public void DeleteItem(InventoryItem item)
    {
        Master.DeleteItem(item);
    }

}
