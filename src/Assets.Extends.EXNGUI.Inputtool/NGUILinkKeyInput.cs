using Assets.Scripts.Tools.NGUI.Component;
using Assets.Tools.Script.Go;
using Assets.Tools.Script.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Inputtool
{
	public class NGUILinkKeyInput : MonoBehaviour
	{
		private class LinkKey
		{
			public GameObject obj;

			public KeyCode keyCode;

			public int sprDepth;

			public int panelDepth;

			public GameObject btn;

			public LinkKey(GameObject obj, KeyCode keyCode, int sprDepth, int panelDepth)
			{
				this.obj = obj;
				this.keyCode = keyCode;
				this.sprDepth = sprDepth;
				this.panelDepth = panelDepth;
				MonoBehaviour monoBehaviour = obj.GetComponent<UIButton>() ?? obj.GetComponent<UIClickListener>();
				this.btn = ((!(monoBehaviour == null)) ? monoBehaviour.gameObject : null);
			}
		}

		private static NGUILinkKeyInput _instance;

		private readonly Dictionary<KeyCode, List<NGUILinkKeyInput.LinkKey>> _links = new Dictionary<KeyCode, List<NGUILinkKeyInput.LinkKey>>();

		public static NGUILinkKeyInput instance
		{
			get
			{
				return NGUILinkKeyInput._instance;
			}
		}

		public static NGUILinkKeyInput GetOrCreateInstance()
		{
			NGUILinkKeyInput arg_1C_0;
			if ((arg_1C_0 = NGUILinkKeyInput._instance) == null)
			{
				arg_1C_0 = (NGUILinkKeyInput._instance = ParasiticComponent.GetSecondaryHost<NGUILinkKeyInput>("NGUILinkKeyInput"));
			}
			return arg_1C_0;
		}

		private void Update()
		{
			foreach (KeyCode current in this._links.Keys)
			{
				if (Input.GetKeyDown(current))
				{
					this._links[current].Sort(delegate(NGUILinkKeyInput.LinkKey l, NGUILinkKeyInput.LinkKey r)
					{
						if (l.panelDepth != r.panelDepth)
						{
							return r.panelDepth - l.panelDepth;
						}
						return r.sprDepth - l.sprDepth;
					});
					foreach (NGUILinkKeyInput.LinkKey current2 in this._links[current])
					{
						if (current2.obj != null && current2.obj.active)
						{
							if (current2.btn != null)
							{
								current2.btn.SendMessage("OnClick");
							}
							break;
						}
					}
				}
			}
		}

		public void DeleteLink(MutexKeyBinding linkToKey)
		{
			if (!this._links.ContainsKey(linkToKey.keyCode))
			{
				return;
			}
			List<NGUILinkKeyInput.LinkKey> list = this._links[linkToKey.keyCode];
			NGUILinkKeyInput.LinkKey item = list.Find((NGUILinkKeyInput.LinkKey e) => e.obj == linkToKey.gameObject);
			list.Remove(item);
			if (list.Count == 0)
			{
				this._links.Remove(linkToKey.keyCode);
			}
		}

		public void AddLink(MutexKeyBinding linkToKey)
		{
			if (!this._links.ContainsKey(linkToKey.keyCode))
			{
				this._links.Add(linkToKey.keyCode, new List<NGUILinkKeyInput.LinkKey>());
			}
			this._links[linkToKey.keyCode].Add(new NGUILinkKeyInput.LinkKey(linkToKey.gameObject, linkToKey.keyCode, this.GetSprDepth(linkToKey), this.GetPanelDepth(linkToKey.gameObject)));
		}

		private int GetSprDepth(MutexKeyBinding linkToKey)
		{
			return linkToKey.ButtonSprite.depth;
		}

		private int GetPanelDepth(GameObject obj)
		{
			UIPanel component = obj.GetComponent<UIPanel>();
			if (component != null)
			{
				return component.depth;
			}
			return this.GetPanelDepth(obj.Parent());
		}
	}
}
