using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoHider : MonoBehaviour
{
    [SerializeField] private float HideTime;
    [SerializeField] private UnityEvent OnHide;
    private bool IsInit = true;
    private void OnEnable()
    {
        StartCoroutine(Wait2Hide());
    }

    IEnumerator Wait2Hide()
    {
        yield return new WaitForSecondsRealtime(HideTime);
        OnHide?.Invoke();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        OnHide.AddListener(Hide);
        OnHide?.Invoke();
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
