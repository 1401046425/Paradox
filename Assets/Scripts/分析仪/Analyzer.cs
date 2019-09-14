using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Analyzer : MonoBehaviour
{
    [SerializeField] private TextMeshPro Text;
    [Multiline(5)]
    [SerializeField]private string Info;

    [SerializeField] private UnityEvent OnPlayFinish;
    [SerializeField] private float UpdateTime;
    [SerializeField] private float WaitTime;
    public void PlayInfo()
    {
        StartCoroutine(RunInfo());
    }

    IEnumerator RunInfo()
    {
        var infoline = Info.Split('\n');
        foreach (var VARIABLE in infoline)
        {
            Text.text=String.Empty;
            foreach (var item in VARIABLE)
            {
                Text.text += item;
                yield return new WaitForSecondsRealtime(UpdateTime);
            }
;
        yield return new WaitForSecondsRealtime(WaitTime);
        }
        
        OnPlayFinish?.Invoke();
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
