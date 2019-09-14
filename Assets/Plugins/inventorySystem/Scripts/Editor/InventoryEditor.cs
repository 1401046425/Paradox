using System;
using System.Collections;
using System.Collections.Generic;
using ES3Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class InventoryEditor : EditorWindow
{

    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    private Inventory inventory;
    [MenuItem("Inventory/InventoryEditor")]
    static void Init()
    {
        Application.runInBackground = true;
        EditorWindow.GetWindow(typeof(InventoryEditor),false,"InventoryEditor",true);
    }
    bool[] Foldouttype;
    bool[] OnceItemEdits;
    bool[] Edits;
    bool Itemfoldout;
    private bool OnceItemSaveInfofoldout;
    private InventoryItem Item;
    private void OnEnable()
    {
        if (inventory!=null)
        {
            Foldouttype = new Boolean[inventory.MaxInventorySize];
            Edits=new Boolean[inventory.MaxInventorySize];
            OnceItemEdits=new bool[inventory.SaveData.OnceItemSaveData.Count+1];
        }
    }

    
    void OnGUI()
    {
        if (inventory == null)
        {
            EditorGUILayout.HelpBox("请选择一个库存管理器",MessageType.Info);
            return;
        }
        EditorGUILayout.LabelField("库存物品编辑器");
        EditorGUILayout.ObjectField("库存管理器:", inventory,typeof(Inventory) ,true);


        //绘制成功就继续绘制
        
        if (ES3.KeyExists(inventory.GetSaveName))
        {
            var data= ES3.Load<InventorySaveData>(inventory.GetSaveName);
            inventory.SaveData = data;

            Itemfoldout = EditorGUILayout.Foldout(Itemfoldout, "物品库存");
            if (Itemfoldout)//物品库存编辑
            {
                for (int i = 0; i < data.Datas.Count; i++)
                {
                    Foldouttype[i]= EditorGUILayout.BeginFoldoutHeaderGroup(Foldouttype[i],data.Datas[i].Data.ItemName);
                    if (Foldouttype[i])
                    {
                        Edits[i]=  EditorGUILayout.BeginToggleGroup("编辑模式",Edits[i]);
                        data.Datas[i].Data=(InventoryItem)EditorGUILayout.ObjectField("物品:", data.Datas[i].Data, typeof(InventoryItem), true);
                        data.Datas[i].Count=(uint)EditorGUILayout.IntField("数量",(int)data.Datas[i].Count);
                        EditorGUILayout.EndToggleGroup();
                        if (Edits[i])
                        {
                            if (GUILayout.Button("删除物品"))
                            {
                                inventory.DeleteItem(data.Datas[i].Data);
                            }  
                            ES3.Save<InventorySaveData>(inventory.GetSaveName,inventory.SaveData);
                            inventory.OnItemSave?.Invoke(inventory.SaveData);
                        }
                    
                    }
                    EditorGUILayout.EndFoldoutHeaderGroup();
                }
            }
            OnceItemSaveInfofoldout = EditorGUILayout.Foldout(OnceItemSaveInfofoldout, "一次性储存物品储存信息"); 
            if (OnceItemSaveInfofoldout)//一次性存储物品信息
            {
                for (int i = 0; i < data.OnceItemSaveData.Count; i++)
                {
                    OnceItemEdits[i]=  EditorGUILayout.BeginToggleGroup("编辑模式",OnceItemEdits[i]);
                    data.OnceItemSaveData[i]=(InventoryItem)EditorGUILayout.ObjectField("储存信息:", data.OnceItemSaveData[i], typeof(InventoryItem), true);
                    EditorGUILayout.EndToggleGroup();
                    if (OnceItemEdits[i])
                    {
                           if (GUILayout.Button("删除储存信息"))
                           {
                               inventory.SaveData.OnceItemSaveData.Remove( data.OnceItemSaveData[i]);
                           }  
                            ES3.Save<InventorySaveData>(inventory.GetSaveName,inventory.SaveData);
                            inventory.OnItemSave?.Invoke(inventory.SaveData);
                    }
                }
  
            }

            EditorGUILayout.Space();
            Item=  (InventoryItem)EditorGUILayout.ObjectField("被存物品:", Item, typeof(InventoryItem), true);
            if (GUILayout.Button("存入物品"))
            {
               if(inventory.DepositItem(Item))
                   Debug.Log("存入物品成功!");
            }  
            
        }
        else
        {
            EditorGUILayout.HelpBox("该库存还未存储过任何物品",MessageType.Info);
        }

    }

    private void OnHierarchyChange()
    {
        if(inventory!=null)
            OnceItemEdits=new bool[inventory.SaveData.OnceItemSaveData.Count+1];
    }

    private void OnInspectorUpdate()
    {
        Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel|SelectionMode.ExcludePrefab);
        foreach (var VARIABLE in transforms)
        {
            inventory = VARIABLE.GetComponent<Inventory>();
        }
    }
}
