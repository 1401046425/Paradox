using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnInitEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent OnInit;
    // Start is called before the first frame update
    private void Awake()
    {
        OnInit?.Invoke();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
