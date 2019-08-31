using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableEvent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEvent Enable;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Enable?.Invoke();
       // Debug.Log(1111);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
