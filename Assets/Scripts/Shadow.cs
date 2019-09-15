using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer TargetRender;

    private SpriteRenderer ShadowRender;

    private void Awake()
    {
        ShadowRender = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        ShadowRender.sprite = TargetRender.sprite;
        ShadowRender.flipX = !TargetRender.flipX;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
