﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckItem : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> CheckItemData;
   [SerializeField] private UnityEvent HasItem;
   [SerializeField] private UnityEvent NoItem;
    private Inventory Master;
  [SerializeField]  private bool CheckOnGameStart;

    private void Awake()
    {
        Master=FindObjectOfType<Inventory>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(CheckOnGameStart)
            CheckHasItem();
    }

    public void CheckHasItem()
    {
        if(CheckItemData.Count<=0)
            return;
        if(CheckItemData==null)
            return;
        var result = false;
        for (int i = 0; i < CheckItemData.Count; i++)
        {
            result = Master.Contains(CheckItemData[i]);
            if(result==false)
                break;
        }
        if(result)
            HasItem?.Invoke();
        else
        {
            NoItem?.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
