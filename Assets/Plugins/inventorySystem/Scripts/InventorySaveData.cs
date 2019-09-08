using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventorySaveData : ScriptableObject
{
    public List<ItemSaveData> Datas=new List<ItemSaveData>();
}
public class ItemSaveData
{
    public ItemData Data;
    public uint Count;
}
