using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory m_Inventory;
    [SerializeField] private ItemInfoView m_ItemInfoView;
    [SerializeField] private List<ItemGridView> GridViews=new List<ItemGridView>();
  [SerializeField] private CanvasGroup m_CanvasGroup;
  [SerializeField] private float CanvasUpdateSpeed=1;
  [SerializeField] private Vector2 TargetPos;
  [SerializeField] private Vector2 OriginPos;
  [SerializeField] private bool AutoHideOnStart;
  public float TransitionSpeed;
  private ItemSaveData NowSlectData;
  public ItemSaveData _NowSlectData
  {
      get => NowSlectData;
      set
      {
          NowSlectData = value;
          if (NowSlectData == null)
          {
              CloseItemInfoView();
              return;
          }
          if (m_ItemInfoView)
          {
              m_ItemInfoView.ShowItemInfo(NowSlectData);
          }
          if(m_ItemInfoView.GetComponent<CanvasGroup>().alpha<1)
          ShowItemInfoView();
      }
  }
  
  private void Awake()
  {
      if (!m_Inventory)
        {
            Debug.LogError("警告未指定 库存管理器");
            return;
        }
      if (GridViews.Count <= 0)
        {
            foreach (var VARIABLE in GetComponentsInChildren<ItemGridView>())
            {
                VARIABLE._InventoryView = this; 
                GridViews.Add(VARIABLE);
            }
        }

        if (AutoHideOnStart)
        {
            m_CanvasGroup.alpha = 0;
            m_CanvasGroup.blocksRaycasts = false;
        }
        m_Inventory.OnItemSave+=RefreshAllInventoryView;
        m_Inventory.OnItemInit+= RefreshAllInventoryView;

        
  }
  [ContextMenu("设置目标移动坐标")]
  private void SetTargetPos()
  {
      TargetPos = transform.position;
  }
  [ContextMenu("设置初始坐标")]
  private void SetOriginPos()
  {
      OriginPos = transform.position;
  }

  private Coroutine MoveCoroutine;
  private Coroutine ShowCoroutine;
  public void ShowItemInfoView()
  {
      if(ShowCoroutine!=null)
          StopCoroutine(ShowCoroutine);
      ShowCoroutine= StartCoroutine(ShowView(m_ItemInfoView.GetComponent<CanvasGroup>()));
      if(MoveCoroutine!=null)
          StopCoroutine(MoveCoroutine);
      MoveCoroutine= StartCoroutine(Move(TargetPos));
  }
  public void CloseItemInfoView()
  {
      if(ShowCoroutine!=null)
          StopCoroutine(ShowCoroutine);
      ShowCoroutine= StartCoroutine(CloseView(m_ItemInfoView.GetComponent<CanvasGroup>()));
      if(MoveCoroutine!=null)
          StopCoroutine(MoveCoroutine);
      MoveCoroutine= StartCoroutine(Move(OriginPos));
  }
  IEnumerator Move(Vector2 Pos)
  {
      var _originTime = Time.unscaledTime;
      while (Vector2.Distance(transform.position,Pos)>0.01f)
      {
          transform.position= Vector2.Lerp(transform.position,Pos,(Time.unscaledTime - _originTime)*TransitionSpeed);
          yield return  new  WaitForFixedUpdate();
      }
  }
  private void RefreshAllInventoryView(InventorySaveData arg0)
    {
        for (int i = 0; i < arg0.Datas.Count; i++)
        {
            GridViews[i].DrawItemIcon(arg0.Datas[i]);
        }
    }

    public void ShowItemView()
    {
        StartCoroutine(ShowView(m_CanvasGroup));
    }



    IEnumerator ShowView(CanvasGroup canvasGroup)
    {
        while (canvasGroup.alpha<1)
        {
            canvasGroup.alpha += Time.fixedUnscaledDeltaTime*CanvasUpdateSpeed;
            yield return new WaitForFixedUpdate();
        }
        canvasGroup.blocksRaycasts = true;
    }
    IEnumerator CloseView(CanvasGroup canvasGroup)
    {
        while (canvasGroup.alpha>0)
        {
            canvasGroup.alpha -= Time.fixedUnscaledDeltaTime*CanvasUpdateSpeed;
            yield return new WaitForFixedUpdate();
        }
        canvasGroup.blocksRaycasts = false;
    }
    public void CloseItemView()
    {
        CloseItemInfoView();
        StartCoroutine(CloseView(m_CanvasGroup));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.magenta;
        Gizmos.DrawWireSphere(TargetPos,20f);
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(OriginPos,20f);
    }
}
