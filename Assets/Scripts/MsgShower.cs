using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgShower : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string info;

    public void ShowMsgInfo()
    {
        MeassageManager.INS.ShowMsg(sprite,info);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
