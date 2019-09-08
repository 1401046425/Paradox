using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemDataInspector : Editor
{
    // 
    public SerializedProperty ItemName;

    
    private void OnEnable()
    {
        ItemName = serializedObject.FindProperty("ItemName");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.indentLevel = 1;

        EditorGUILayout.PropertyField(ItemName, new GUIContent("物品名称"));
        GUILayout.Space(5);

        // 打印数据
        if (GUILayout.Button("Debug"))
        {
            Debug.Log("ItemName    :" + ItemName.enumValueIndex);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }

        serializedObject.ApplyModifiedProperties();
    }

}
