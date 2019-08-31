using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class DialogueStateChecker : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;

    [SerializeField] private UnityEvent OnRunning;
    [SerializeField] private UnityEvent OnStoping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if(!dialogueRunner)
            return;
        dialogueRunner.OnDialogStateChange+=CheckState;
    }

    private void CheckState(bool running)
    {
        if (running)
        {
            OnRunning?.Invoke();
        }
        else
        {
            OnStoping?.Invoke();
        }
    }

    private void FixedUpdate()
    {

            
    }
}
