using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeassageView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MsgText;
    [SerializeField] private Image MsgImage;
    [SerializeField] private CanvasGroup MsgCanvas;
    private MeassageManager Master;
    private void Awake()
    {
        if(Master==null)
            Master= FindObjectOfType<MeassageManager>();
        Master.OnNewMsgShow += ShowMsg;
        Master.OnMsgFinish += CloseMsg;
        MsgCanvas.alpha = 0;
    }
    
    private void CloseMsg()
    {
        StartCoroutine(FadeOutCanvas());
    }

    private void ShowMsg(MsgInfo msg)
    {
        MsgText.text = msg.info;
        MsgImage.sprite = msg.Msgimage;
        if(MsgImage.sprite!=null)
            MsgImage.color=Color.white;
        else
        {
            MsgImage.color=Color.clear;
        }
        MsgImage.SetNativeSize();
        if((MsgCanvas.alpha<1))
        StartCoroutine(FadeInCanvas());
    }
    
    IEnumerator FadeInCanvas()
    {
        while (MsgCanvas.alpha<1)
        {
        MsgCanvas.alpha += Time.fixedDeltaTime;
        yield return  new  WaitForFixedUpdate();
        }
    }
    IEnumerator FadeOutCanvas()
    {
        while (MsgCanvas.alpha>0)
        {
            MsgCanvas.alpha -= Time.fixedDeltaTime;
            yield return  new  WaitForFixedUpdate();
        }
    }
}