using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class StoryTrigger : MonoBehaviour
{
    public string StoryName;

    public bool StoryIsFinish;

    [SerializeField] private UnityEvent StoryAction;
    public void AutoInvokeStory()
    {
        if(StoryIsFinish)
            return;
        StoryAction?.Invoke();
        
    }

    public void Finish()
    {
        StoryIsFinish = true;
        StoryManager.INS.FinishStory(StoryName, StoryIsFinish);
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
