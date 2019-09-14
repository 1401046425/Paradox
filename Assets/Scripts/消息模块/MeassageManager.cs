using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MeassageManager : MonoBehaviour
{
   private Queue<MsgInfo>MsgList=new Queue<MsgInfo>();
   private bool isPlayeing;
   private Coroutine MsgPlayCoroutine;
   public UnityAction<MsgInfo> OnNewMsgShow;
   public UnityAction OnMsgFinish;
   [SerializeField] private float ShowMsgTime;
   public static MeassageManager INS;
   private void Awake()
   {
      INS = this;
   }
   /// <summary>
   /// 显示消息
   /// </summary>
   /// <param name="info"></param>
   public void ShowMsg(string info)
   {
      if (isPlayeing)
         return;
      var msg=new MsgInfo();
      msg.info = info;
      if(MsgList.Contains(msg))
         return;
      MsgList.Enqueue(msg);
      if (!isPlayeing)
         MsgPlayCoroutine = StartCoroutine(ScrollingMsg());
   }
/// <summary>
/// 显示消息
/// </summary>
/// <param name="sprite"></param>
/// <param name="info"></param>
   public void ShowMsg(Sprite sprite,string info)
   {
      if (isPlayeing)
         return;
      var msg=new MsgInfo();
      msg.info = info;
      msg.Msgimage = sprite;
      if(MsgList.Contains(msg))
         return;
      MsgList.Enqueue(msg);
      if (!isPlayeing)
         MsgPlayCoroutine = StartCoroutine(ScrollingMsg());
   }

   public IEnumerator ScrollingMsg()
   {
      isPlayeing = true;
      for (int i = 0; i < MsgList.Count; i++)
      {
         var msg = MsgList.Dequeue();
         OnNewMsgShow.Invoke(msg);
         yield return  new  WaitForSecondsRealtime(ShowMsgTime);
      }
      OnMsgFinish.Invoke();
      isPlayeing = false;
   }
}

public struct MsgInfo
{  public Sprite Msgimage;
   public string info;
}
