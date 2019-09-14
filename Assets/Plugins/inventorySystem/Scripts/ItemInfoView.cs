using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoView : MonoBehaviour
{

    [SerializeField] private Image ItemIconRenderer;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Count;
    [SerializeField] private TextMeshProUGUI Info;
    [SerializeField] private CanvasGroup m_CanvasGroup;
    [SerializeField] private Button UseButton;
    [SerializeField] private Button DropButton;

    public void ShowItemInfo(ItemSaveData data)
    {   
        ItemIconRenderer.sprite = data.Data.ItemImage;
        ItemIconRenderer.SetNativeSize();
        Name.text = String.Format("名称:{0}",data.Data.ItemName);
        Count.text = String.Format("数量:{0}",data.Count.ToString());
        Info.text = data.Data.ItemInfo;
        UseButton.gameObject.SetActive(data.Data.CanUse);
        DropButton.gameObject.SetActive(data.Data.CanDrop);
        UseButton.onClick.AddListener(data.Data.OnUse);
        DropButton.onClick.AddListener(data.Data.OnDrop);
    }
}
