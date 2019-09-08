using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public static StoryManager INS;
    public List<StoryTrigger> StoryTriggers=new List<StoryTrigger>();
    Dictionary<string,bool> StoryData=new Dictionary<string, bool>();
    public Action OnStoryInitFinish;
    private void Awake()
    {
        INS = this;
        SceneName=  SceneManager.GetActiveScene().name;
        InitStoryData();
    }
    
    private string SceneName;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void InitStoryData()
    {
        if (!ES3.KeyExists(SceneName))
        {
        ES3.Save<Dictionary<string,bool>>(SceneName,StoryData);
        }
        StoryData=ES3.Load<Dictionary<string, bool>>(SceneName);
        if (StoryTriggers.Count <= 0)
        {
            foreach (var VARIABLE in transform.GetComponentsInChildren<StoryTrigger>())
            {
                StoryTriggers.Add(VARIABLE);
            }
        }

        foreach (var VARIABLE in StoryTriggers)
        {
            OnStoryInitFinish += VARIABLE.AutoInvokeStory;
            if (StoryData.ContainsKey(VARIABLE.StoryName))
            {
                VARIABLE.StoryIsFinish=StoryData[VARIABLE.StoryName];
            }
        }
        OnStoryInitFinish?.Invoke();
    }

    public void FinishStory(string storyName, bool storyIsFinish)
    {
      if(StoryData.ContainsKey(storyName))
      {
          StoryData[storyName] = storyIsFinish;
      }
      else
      {
          StoryData.Add(storyName,storyIsFinish);
      }
      ES3.Save<Dictionary<string,bool>>(SceneName,StoryData);
    }
    }
