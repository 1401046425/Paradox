using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventorySaveData : ScriptableObject
{
    public List<ItemSaveData> Datas=new List<ItemSaveData>();
    public List<InventoryItem> OnceItemSaveData=new List<InventoryItem>();
}
public class ItemSaveData
{
    public InventoryItem Data;
    public uint Count;
}
