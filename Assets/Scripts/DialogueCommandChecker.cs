using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;
using Yarn.Unity.Example;

public class DialogueCommandChecker : MonoBehaviour
{
    public DialogueUI DialogueUI;
    // Start is called before the first frame update
    [SerializeField] private string CheckCommand;
    [SerializeField] private UnityEvent OnCommand;
    private void Awake()
    {
        DialogueUI.OnDialogueCommand+=CheckCompleteEvent;
    }

    private void CheckCompleteEvent(string obj)
    {
        if(CheckCommand.Contains(obj))
            OnCommand?.Invoke();

    }
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
