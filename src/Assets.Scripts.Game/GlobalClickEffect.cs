using Assets.Script.Mvc.Pool;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Lua.Utility;

namespace Assets.Scripts.Game
{
	public class GlobalClickEffect : MonoBehaviour
	{
		private class EffectPool : Pool<GameObject>
		{
			private readonly GameObject prefab;

			private readonly Transform root;

			public EffectPool(GameObject prefab, Transform root)
			{
				this.prefab = prefab;
				this.root = root;
				this.MaxCount = 10;
			}

			public override bool ReturnInstance(object obj)
			{
				GameObject gameObject = obj as GameObject;
				gameObject.transform.parent = this.root;
				return base.ReturnInstance(obj);
			}

			protected override object CreateObject()
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefab);
				Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
				Renderer[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					Renderer renderer = array[i];
					for (int j = 0; j < renderer.materials.Length; j++)
					{
						Material material = renderer.materials[j];
						material.renderQueue = 999999;
					}
				}
				return gameObject;
			}

			public override void Clear()
			{
				foreach (object current in this.AvailableObjects)
				{
					UnityEngine.Object.Destroy((UnityEngine.Object)current);
				}
				base.Clear();
			}
		}

		public static GlobalClickEffect Instance;

		public GameObject Prefab;

		private GlobalClickEffect.EffectPool effectPool;

		private List<GameObject> playingList;

		private void Start()
		{
			GlobalClickEffect.Instance = this;
			this.Init();
		}

		public void SetPrefab(GameObject prefab)
		{
			this.Prefab = prefab;
			this.Init();
		}

		private void Init()
		{
			if (this.playingList != null)
			{
				for (int i = 0; i < this.playingList.Count; i++)
				{
					GameObject obj = this.playingList[i];
					UnityEngine.Object.Destroy(obj);
				}
			}
			if (this.effectPool != null)
			{
				this.effectPool.Clear();
			}
			this.effectPool = new GlobalClickEffect.EffectPool(this.Prefab, base.transform);
			this.playingList = new List<GameObject>();
		}

		public void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				UICamera topUICamera = NGUITool.GetTopUICamera();
				if (topUICamera != null)
				{
					GameObject instance = this.effectPool.GetInstance();
					instance.SetActive(true);
					if (instance.layer != topUICamera.gameObject.layer)
					{
						NGUITools.SetLayer(instance, topUICamera.gameObject.layer);
					}
					instance.transform.parent = topUICamera.transform;
					instance.transform.localScale = Vector3.one;
					instance.transform.position = topUICamera.cachedCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -topUICamera.transform.position.z));
					this.playingList.Add(instance);
				}
			}
			for (int i = this.playingList.Count - 1; i >= 0; i--)
			{
				GameObject gameObject = this.playingList[i];
				if (gameObject == null)
				{
					this.playingList.RemoveAt(i);
				}
				else if (!gameObject.activeSelf)
				{
					this.playingList.RemoveAt(i);
					this.effectPool.ReturnInstance(gameObject);
				}
			}
		}
	}
}
