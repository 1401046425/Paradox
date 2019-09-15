using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager INS;
    
    [SerializeField] private CinemachineVirtualCamera PlayerCamera;
    public Transform PlayerTransForm;
    public UnityAction<MapPoint> OnMapAdd;
    public UnityAction<MapPoint> OnMapDelete;
    private List<MapPoint> _Points=new List<MapPoint>();

    public string NowPlayerPosName;
    private void SaveMapData()
    {
        ES3.Save<List<MapPoint>>(GetSaveName,_Points);
    }

    public string GetSaveName
    {
        get { return SceneManager.GetActiveScene().name+"Map"; }
    }
    private void Awake()
    {
        INS = this;
        if (!ES3.KeyExists(GetSaveName))
            ES3.Save<List<MapPoint>>(GetSaveName,_Points);
       _Points=ES3.Load<List<MapPoint>>(GetSaveName);
       if (ES3.KeyExists(GetSaveName + "NowPos"))
       {
           NowPlayerPosName = ES3.Load<string>(GetSaveName + "NowPos");
           TransToMapPoint(NowPlayerPosName);
       }
    }

    public void TransToMapPoint(string Name)
    {
        foreach (var VARIABLE in _Points)
        {
            if (VARIABLE.GetPointName == Name)
            {
                try
                {
                    Destroy(PlayerCamera.GetComponent<CinemachineConfiner>());
                    PlayerCamera.gameObject.AddComponent<CinemachineConfiner>().m_BoundingShape2D = VARIABLE.BoundingShape;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
                PlayerTransForm.position = VARIABLE.transform.position;
                NowPlayerPosName = VARIABLE.GetPointName;
                ES3.Save<string>(GetSaveName+"NowPos",NowPlayerPosName);
            }
        }
    }
    public void AddMapPoint(MapPoint point)
    {
        if(_Points.Contains(point))
            return;
        _Points.Add(point);
        OnMapAdd?.Invoke(point);
        SaveMapData();
    }

    public void DeleteMapPoint(MapPoint point)
    {
        if(_Points.Count<=0)
            return;
        _Points.Remove(point);
        OnMapDelete?.Invoke(point);
        SaveMapData();
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
