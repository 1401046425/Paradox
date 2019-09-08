using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemGridView : Button
{
    
    [SerializeField] private Image ItemSprite;
   [SerializeField] private TextMeshProUGUI CountText;
   [SerializeField] private UnityEvent OnSelect;
   private ItemSaveData KeepData;
   [HideInInspector]
   public InventoryView _InventoryView;


   public override void OnPointerDown(PointerEventData eventData)
   {
       base.OnPointerDown(eventData);
       _InventoryView._NowSlectData = KeepData;
   }

   public void DrawItemIcon(ItemSaveData data)
   {
       KeepData = data;
        ItemSprite.sprite = data.Data.ItemImage;
        CountText.text = data.Count.ToString();
        ItemSprite.color=Color.white;
   }
}
