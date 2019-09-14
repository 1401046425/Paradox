using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    public InventoryItem Data;
    private Inventory TargetInventory;
   [HideInInspector] public SpriteRenderer Item_SpriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        Item_SpriteRenderer = GetComponent<SpriteRenderer>();
        foreach (var VARIABLE in FindObjectsOfType<Inventory>())
        {
            if (VARIABLE.InventoryType == Data.TargetInventoryType)
                TargetInventory = VARIABLE;
        }
        if(!TargetInventory)
            Debug.LogError("警告未找到仓库管理器");


    }

    private void OnEnable()
    {
        if (Data.JustCanPickUpOnce)
            if (TargetInventory.SaveData.OnceItemSaveData.Contains(Data))
                Destroy(this.gameObject);
    }

    void Start()
    {
        if (!Data)
        {
          Debug.LogError("未指定物品数据");
            return;  
        }

        if (Item_SpriteRenderer.sprite == null)
        {
            Item_SpriteRenderer.sprite = Data.ItemImage;
        }
    }

    public void AddItem2Inventory()
    {
       if(TargetInventory.DepositItem(Data))
           Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
