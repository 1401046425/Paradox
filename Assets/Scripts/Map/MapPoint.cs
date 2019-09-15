using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
 [SerializeField] private string PointName;
 public string GetPointName
 {
  get { return PointName; }
 }

 [SerializeField] private PolygonCollider2D BoundingShape2D;

 public PolygonCollider2D BoundingShape
 {
  get { return BoundingShape2D; }
 }

 private void OnDrawGizmos()
 {
  Gizmos.DrawIcon(transform.position,"mappoint.png");
 }
}
