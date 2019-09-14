
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
    public UnityAction<InventoryItem> OnItemCountFull;

   public string GetSaveName
    {
        get { return SceneManager.GetActiveScene().name+InventoryName+"Inventory"; }
    }

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
        if (!ES3.KeyExists(GetSaveName))
        {
            SaveData=new InventorySaveData();
            ES3.Save<InventorySaveData>(GetSaveName,SaveData);
            OnItemSave?.Invoke(SaveData);
        }
        SaveData =ES3.Load < InventorySaveData>(GetSaveName);

    }

    /// <summary>
    /// 存入物品
    /// </summary>
    public bool DepositItem(InventoryItem data)
    {
        if (data == null)
        {
            Debug.LogError("不能存入空物品");
            return false;
        }

        if(!CanDepositTypes.Contains(data.Type))//判断是否可以储存在此仓库
            return false;
        if (SaveData.Datas.Count >= MaxInventorySize)
            return false;
        return SaveItemData(data);;

    }
/// <summary>
/// 删除物品
/// </summary>
/// <param name="data"></param>
/// <returns></returns>
    public bool DeleteItem(InventoryItem data)
    {
        if (GetData(data) == null)
            return false;
        return DeleteItemData(data);;
    }
/// <summary>
    /// 储存物品数据到本地
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns></returns>
    private bool SaveItemData(InventoryItem data)
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
            if (Data.Data.JustCanPickUpOnce)
            {
                if(!SaveData.OnceItemSaveData.Contains(Data.Data))
                     SaveData.OnceItemSaveData.Add(Data.Data);
            }

            
            SaveResult = true;
        }
        ES3.Save<InventorySaveData>(GetSaveName,SaveData);
        OnItemSave?.Invoke(SaveData);
        return SaveResult;
    }
    /// <summary>
    /// 删除物品
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private bool DeleteItemData(InventoryItem data)
    {
        bool SaveResult = false;
         var Data = GetData(data);//获取已存储的物品数据
    
            if (Data.Count > 1)
            {
                Data.Count--;//增加物品数量
                SaveResult = true;
            }
            else 
            {//如果小于等于1直接删除这个物品
                SaveData.Datas.Remove(Data);
                SaveResult = true;
            }
            
        ES3.Save<InventorySaveData>(GetSaveName,SaveData);
        return SaveResult;
    }
    public ItemSaveData GetData(InventoryItem data)
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

    public bool Contains(InventoryItem data)
    {
        return GetData(data) != null;
    }

    /// <summary>
    /// 清理所有存储物品数据
    /// </summary>
    public void ClearAllSaveItem()
    {
        SaveData.Datas.Clear();
        ES3.Save<InventorySaveData>(GetSaveName,SaveData);
        OnItemSave?.Invoke(SaveData);
    }
/// <summary>
/// 清理所有已经存储过物品的数据信息
/// </summary>
    public void ClearAllHasSavedItems()
    {
        SaveData.OnceItemSaveData.Clear();
        ES3.Save<InventorySaveData>(GetSaveName,SaveData);
        OnItemSave?.Invoke(SaveData);
    }
/// <summary>
/// 清理所有物品数据
/// </summary>
    public void ClearAllItemData()
    {
        SaveData.Datas.Clear();
        SaveData.OnceItemSaveData.Clear();
        ES3.Save<InventorySaveData>(GetSaveName,SaveData);
        OnItemSave?.Invoke(SaveData);
    }

// Update is called once per frame
    void Update()
    {
        
    }
}
