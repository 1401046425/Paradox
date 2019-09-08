
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [Header("仓库名称")]
    public string InventoryName;//仓库名称
    [Header("仓库类型")]
    public InventoryType InventoryType;
    [Header("仓库最大存储数据量")]
    public uint MaxInventorySize;
    [Header("仓库存储的物品数据")] 
    public InventorySaveData SaveData;
    [Header("可存储的物品类型")]
    public List<ItemType> CanDepositTypes=new List<ItemType>();//可装在的物品类型
    public UnityAction<InventorySaveData>  OnItemInit;
    public UnityAction<InventorySaveData>  OnItemSave;
    public UnityAction<ItemData> OnItemCountFull;
    // Start is called before the first frame update
    private void Awake()
    {
        InitSaveData();
    }

    void Start()
    {
        OnItemInit?.Invoke(SaveData);
    }
    private void InitSaveData()
    {
        if (!ES3.KeyExists(SceneManager.GetActiveScene().name + "Inventory"))
        {
            SaveData=new InventorySaveData();
            ES3.Save<InventorySaveData>(SceneManager.GetActiveScene().name+"Inventory",SaveData);
        }
        SaveData =ES3.Load < InventorySaveData>(SceneManager.GetActiveScene().name + "Inventory");

    }

    /// <summary>
/// 存入物品
/// </summary>
public bool DepositItem(ItemData data)
    {
        if(!CanDepositTypes.Contains(data.Type))//判断是否可以储存在此仓库
            return false;
        if (SaveData.Datas.Count >= MaxInventorySize)
            return false;
        return SaveItemData(data);;

    }
    /// <summary>
    /// 储存物品数据到本地
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    private bool SaveItemData(ItemData data)
    {
        bool SaveResult = false;
        var Data = GetData(data);//获取已存储的物品数据
        if (Data != null)//如果物品数据不为空
        {
            if (Data.Count < data.MaxItemNumber)
            {
                Data.Count++;//增加物品数量
                SaveResult = true;
            }
            else
            {
                OnItemCountFull?.Invoke(data);
            }
        }
        else
        {//如果没有存储过呢新增加一个物品存储数据
            Data = new ItemSaveData();
            Data.Data = data;
            Data.Count = 1;
            SaveData.Datas.Add(Data);
            SaveResult = true;
        }
        ES3.Save<InventorySaveData>(SceneManager.GetActiveScene().name+"Inventory",SaveData);
        OnItemSave?.Invoke(SaveData);
        return SaveResult;
    }

    private ItemSaveData GetData(ItemData data)
    {
        foreach (var VARIABLE in  SaveData.Datas)
        {
            if (VARIABLE.Data == data)
            {
                return VARIABLE;
            }
        }
        return null;
    }

// Update is called once per frame
    void Update()
    {
        
    }
}
