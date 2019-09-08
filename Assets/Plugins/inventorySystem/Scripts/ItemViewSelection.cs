using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemViewSelection : MonoBehaviour
{
	/// the speed at which the selection marker will move from one slot to the other
		public float TransitionSpeed=5f;
		/// the threshold distance at which the marker will stop moving
		public float MinimalTransitionDistance=0.01f;

		protected RectTransform _rectTransform;
		protected GameObject _currentSelection;
		protected Vector3 _originPosition;
		protected Vector3 _originLocalScale;
		protected Vector3 _originSizeDelta;
		protected float _originTime;
		protected bool _originIsNull=true;
		protected float _deltaTime;

		private Transform mytrans;
		 public GameObject _current
		 {
			 get { return _currentSelection; }
		 }

		/// <summary>
		/// On Start, we get the associated rect transform
		/// </summary>
		void Start () 
		{
			_rectTransform = GetComponent<RectTransform>();
			mytrans = transform;
		}

		/// <summary>
		/// On Update, we get the current selected object, and we move the marker to it if necessary
		/// </summary>


		private void FixedUpdate()
		{
			_currentSelection = EventSystem.current.currentSelectedGameObject;
			if (_currentSelection==null)
				return;
			if (Vector3.Distance(transform.position,_currentSelection.transform.position) > MinimalTransitionDistance)
			{
				if (_originIsNull)
				{
					_originIsNull=false;
					_originPosition = transform.position;
					_originLocalScale = _rectTransform.localScale;
					_originSizeDelta = _rectTransform.sizeDelta;
					_originTime = Time.unscaledTime;
				} 
				_deltaTime =  (Time.unscaledTime - _originTime)*TransitionSpeed;
				mytrans.position= Vector3.Lerp(_originPosition,_currentSelection.transform.position,_deltaTime);
				var _currentTrans = _currentSelection.GetComponent<RectTransform>();
				_rectTransform.localScale = Vector3.Lerp(_originLocalScale, _currentTrans.localScale,_deltaTime);
				_rectTransform.sizeDelta = Vector3.Lerp(_originSizeDelta, _currentTrans.sizeDelta, _deltaTime);
			}
			else
			{
				_originIsNull=true;
			}
		}
}
