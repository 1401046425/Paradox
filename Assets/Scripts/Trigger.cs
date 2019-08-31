using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;
    public bool JustOne;
    private bool IsInvoked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (JustOne)
        {
            if(IsInvoked)
                return;
        }

        OnEnter?.Invoke();
        IsInvoked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (JustOne)
        {
            if(IsInvoked)
                return;
        }
        OnEnter?.Invoke();
        IsInvoked = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnExit?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit?.Invoke();
    }
}
