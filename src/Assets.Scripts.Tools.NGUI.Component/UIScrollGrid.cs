using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIScrollGrid : MonoBehaviour
	{
		public UIScrollView ScrollView;

		public GameObject TargetCenter;

		public float CellWidth;

		public float StartPos;

		public float StartRange;

		public Vector3 CenterOffset;

		public Vector3 MaxScale;

		public Vector3 MinScale;

		public bool UseLateUpdate;

		private List<Transform> children;

		private void OnEnable()
		{
			this.Reset();
		}

		public void Reset()
		{
			if (this.children == null)
			{
				this.children = new List<Transform>();
			}
			else
			{
				this.children.Clear();
			}
			foreach (Transform item in base.transform)
			{
				this.children.Add(item);
			}
		}

		private void Update()
		{
			if (!this.UseLateUpdate)
			{
				this.UpdateGird();
			}
		}

		private void LateUpdate()
		{
			if (this.UseLateUpdate)
			{
				this.UpdateGird();
			}
		}

		private void UpdateGird()
		{
			if (this.children == null)
			{
				return;
			}
			for (int i = 0; i < this.children.Count; i++)
			{
				Transform transform = this.children[i];
				if (transform == null)
				{
					this.children.RemoveAt(i);
					i--;
				}
				else
				{
					float num = Mathf.Abs(transform.position.x - this.TargetCenter.transform.position.x);
					Vector3 vector;
					Vector3 vector2;
					if (num < this.StartRange)
					{
						float d = (this.StartRange - num) / this.StartRange;
						vector = (this.MaxScale - this.MinScale) * d + this.MinScale;
						vector2 = this.CenterOffset * d;
					}
					else
					{
						vector = this.MinScale;
						vector2 = Vector3.zero;
					}
					if (transform.localScale != vector)
					{
						transform.localScale = vector;
					}
					if (Math.Abs(vector2.x) > 0.0001f)
					{
						transform.localPosition = new Vector3(vector2.x, transform.localPosition.y, transform.localPosition.z);
					}
					if (Math.Abs(vector2.y) > 0.0001f)
					{
						transform.localPosition = new Vector3(transform.localPosition.x, vector2.y, transform.localPosition.z);
					}
				}
			}
		}
	}
}
