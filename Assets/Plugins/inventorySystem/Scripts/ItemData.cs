using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemData:ScriptableObject
{
    [Header("物品名称")]
    public string ItemName;
    [Header("物品类型")]
    public ItemType Type;
    [Header("物品图片")]
    public Sprite ItemImage;
    [Header("物品预制物")]
    public GameObject ItemPrefab;
    [Header("默认仓库类型")]
   readonly public InventoryType TargetInventoryType;
    [Header("该物品可拥有的最大数量")]
    public uint MaxItemNumber;
    [TextArea(2,5)]
    [Header("物品信息")] public string ItemInfo;
}