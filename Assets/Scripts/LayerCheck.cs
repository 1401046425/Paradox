using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCheck : MonoBehaviour
{
    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer=GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        var targetrender = other.transform.GetComponent<SpriteRenderer>();
        
        if (targetrender)
        {
            if (transform.position.y > other.transform.position.y)
            {
                renderer.sortingOrder =
                    targetrender.sortingOrder - 1;
            }
            else
            {
                renderer.sortingOrder =
                    targetrender.sortingOrder + 1;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var targetrender = other.transform.GetComponent<SpriteRenderer>();
        
        if (targetrender)
        {
            if (transform.position.y > other.transform.position.y)
            {
                renderer.sortingOrder =
                    targetrender.sortingOrder - 1;
            }
            else
            {
                renderer.sortingOrder =
                    targetrender.sortingOrder + 1;
            }
        }
    }
}
