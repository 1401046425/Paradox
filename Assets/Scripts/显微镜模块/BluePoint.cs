using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BluePoint : MonoBehaviour,IPointerDownHandler
{
    private Microscope Master;

    private void Awake()
    {
        Master = GetComponentInParent<Microscope>();
    }

    public void AddPoint()
    {
        Master.AddBluePoint();
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AddPoint();
    }
}
