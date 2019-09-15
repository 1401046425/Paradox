using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Microscope : MonoBehaviour
{
    [SerializeField] private  uint TargetBLuePoint;
    [SerializeField] private UnityEvent OnMicroscopeFinish;
    private uint Point;
    [SerializeField] private TextMeshProUGUI PointText;
    public void AddBluePoint()
    {
        Point++;
        PointText.text = Point+"/12";
        if (Point >= TargetBLuePoint)
            OnMicroscopeFinish?.Invoke();
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
