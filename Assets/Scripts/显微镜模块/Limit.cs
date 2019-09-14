using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
   [SerializeField] private Vector2 Offsite;
  // [SerializeField] private Vector2 center;
   private RectTransform mytrans;

   private void Awake()
   {
      mytrans = GetComponent<RectTransform>();
   }
   

   private void FixedUpdate()
   {
      if (mytrans.anchoredPosition.x > Offsite.x)
         mytrans.anchoredPosition= new Vector2(Offsite.x,mytrans.anchoredPosition.y);
      if (mytrans.anchoredPosition.x <  -Offsite.x)
         mytrans.anchoredPosition = new Vector2(-Offsite.x,mytrans.anchoredPosition.y);
      if (mytrans.anchoredPosition.y >  Offsite.y)
         mytrans.anchoredPosition = new Vector2(mytrans.anchoredPosition.x, Offsite.y);
      if (mytrans.anchoredPosition.y <  -Offsite.y)
         mytrans.anchoredPosition = new Vector2(mytrans.anchoredPosition.x,-Offsite.y);

   }

   private void OnDrawGizmos()
   {
    //  Gizmos.color=Color.green;
    //  Gizmos.DrawWireCube(center,Offsite);
   }
}
