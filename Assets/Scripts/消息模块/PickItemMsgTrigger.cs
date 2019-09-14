using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemMsgTrigger : MonoBehaviour
{

    public void ShowPickItemMsg(Item item)
    {
        MeassageManager.INS.ShowMsg(item.Data.ItemImage,String.Format("获得物品[{0}]",item.Data.ItemName));
    }
    public void ShowPickItemMsg(InventoryItem item)
    {
        MeassageManager.INS.ShowMsg(item.ItemImage,String.Format("获得物品[{0}]",item.ItemName));
    }
}
