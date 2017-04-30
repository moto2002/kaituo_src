using Assets.Script.Mvc.Pool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class ProjectileLine : MonoBehaviour
	{
		private class LineItemPool : Pool<GameObject>
		{
			private GameObject prefab;

			public LineItemPool(GameObject prefabGameObject)
			{
				this.MaxCount = 100;
				this.prefab = prefabGameObject;
			}

			protected override object CreateObject()
			{
				return UnityEngine.Object.Instantiate<GameObject>(this.prefab);
			}
		}

		public Transform Coordinate;

		public GameObject Arrows;

		public Transform Target;

		public Transform LintRoot;

		public GameObject LineItemPrefab;

		public float LineItemWidth;

		public float Speed = 0.05f;

		public float Height = 10f;

		public float HeightCoefficient;

		private float funcA;

		private float funcB;

		private float startLen;

		private List<GameObject> lineObjects = new List<GameObject>();

		private static ProjectileLine.LineItemPool lineLtemPool;

		private Vector3 maxArrowsRotation;

		private Vector3 nonDistanceLocalPosition;

		private Quaternion nonDistanceRotation;

		public static void DisposeProjectileLine()
		{
			if (ProjectileLine.lineLtemPool != null)
			{
				ProjectileLine.lineLtemPool.Clear();
				ProjectileLine.lineLtemPool = null;
			}
		}

		private void Awake()
		{
			this.nonDistanceLocalPosition = new Vector3(0f, 0f, 8.455587f);
			this.nonDistanceRotation = Quaternion.Euler(new Vector3(310.8096f, 47.13741f, 320.5949f));
		}

		public void SetTargetLocalPosition(Vector3 position)
		{
			this.Target.localPosition = position;
		}

		public void SetTargetPosition(Vector3 position)
		{
			this.Target.position = position;
		}

		public void Refresh()
		{
			if (ProjectileLine.lineLtemPool == null)
			{
				ProjectileLine.lineLtemPool = new ProjectileLine.LineItemPool(this.LineItemPrefab);
			}
			this.Update();
		}

		private void Start()
		{
			this.Refresh();
		}

		private void Update()
		{
			float num = Vector3.Distance(this.LintRoot.localPosition, this.Target.localPosition);
			if ((double)Math.Abs(num) < 0.0001)
			{
				for (int i = 0; i < this.lineObjects.Count; i++)
				{
					GameObject gameObject = this.lineObjects[i];
					gameObject.SetActive(false);
					ProjectileLine.lineLtemPool.ReturnInstance(gameObject);
				}
				this.lineObjects.Clear();
				this.Arrows.transform.localPosition = this.nonDistanceLocalPosition;
				this.Arrows.transform.rotation = this.nonDistanceRotation;
				return;
			}
			this.Init(num);
			Vector3 position = this.Target.position;
			this.LintRoot.LookAt(position, this.Coordinate.up);
			int num2 = Mathf.RoundToInt(num / this.LineItemWidth);
			if (num2 > 99)
			{
				num2 = 99;
			}
			if (this.lineObjects.Count < num2)
			{
				while (this.lineObjects.Count < num2)
				{
					GameObject instance = ProjectileLine.lineLtemPool.GetInstance();
					instance.transform.parent = this.LintRoot;
					instance.transform.localRotation = Quaternion.identity;
					instance.transform.localScale = Vector3.one;
					instance.gameObject.SetActive(true);
					this.lineObjects.Add(instance);
				}
			}
			else if (this.lineObjects.Count > num2)
			{
				while (this.lineObjects.Count > num2)
				{
					GameObject gameObject2 = this.lineObjects[this.lineObjects.Count - 1];
					this.lineObjects.RemoveAt(this.lineObjects.Count - 1);
					gameObject2.SetActive(false);
					ProjectileLine.lineLtemPool.ReturnInstance(gameObject2);
				}
			}
			float num3 = num / (float)num2;
			this.SetPosition(this.Arrows, num, num);
			for (int j = 0; j < this.lineObjects.Count; j++)
			{
				GameObject obj = this.lineObjects[j];
				float x = num3 * (float)j + this.startLen;
				this.SetPosition(obj, x, num);
			}
			this.startLen += this.Speed;
			if (this.startLen >= num3)
			{
				this.startLen = 0f;
			}
		}

		private void Init(float distanceToTarget)
		{
			float num = distanceToTarget / 2f;
			float num2 = distanceToTarget * distanceToTarget;
			float num3 = num * num;
			float num4 = num;
			float num5 = (this.HeightCoefficient <= 0f) ? this.Height : (this.Height * (distanceToTarget / this.HeightCoefficient));
			float num6 = num2 / num3;
			this.funcB = num5 * num6 / (num4 * num6 - distanceToTarget);
			this.funcA = -distanceToTarget * this.funcB / num2;
		}

		private float GetAlpha(float x, float y, float distanceToTarget)
		{
			float num = (this.HeightCoefficient <= 0f) ? this.Height : (this.Height * (distanceToTarget / this.HeightCoefficient));
			float num2 = this.LineItemWidth / 2f;
			float num3 = Mathf.Min(x, distanceToTarget - x - num2 - (distanceToTarget - num2) / num);
			return num3 / num2;
		}

		private void SetPosition(GameObject obj, float x, float distanceToTarget)
		{
			float y = this.GetY(x);
			obj.transform.localPosition = new Vector3(0f, y, x);
			float num = x + this.LineItemWidth / 20f;
			this.LineItemPrefab.transform.localPosition = new Vector3(0f, this.GetY(num), num);
			obj.transform.LookAt(this.LineItemPrefab.transform.position, this.Coordinate.up);
			obj.GetComponentInChildren<Renderer>().material.SetFloat("_Alpha", this.GetAlpha(x, y, distanceToTarget));
		}

		private float GetY(float value)
		{
			return this.funcA * value * value + this.funcB * value;
		}
	}
}
