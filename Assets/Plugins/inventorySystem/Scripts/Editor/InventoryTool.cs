using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class InventoryTool : Editor
{
    [MenuItem("Inventory/CreateItemData")]
    static void Create()
    {

        ScriptableObject Data = ScriptableObject.CreateInstance<ItemData>();

        // 如果实例化 Bullet 类为空，返回
        if (!Data)
        {
            Debug.LogWarning("ItemDataAeeet not found");
            return;
        }

        // 自定义资源保存路径
        string path = Application.dataPath + "/ItemDataAeeet";

        // 如果项目总不包含该路径，创建一个
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        //将类名 Bullet 转换为字符串
        //拼接保存自定义资源（.asset） 路径
        path = string.Format("Assets/ItemDataAeeet/{0}.asset", (typeof(ItemData).ToString()));

        // 生成自定义资源到指定路径
        AssetDatabase.CreateAsset(Data, path);
    }
}
