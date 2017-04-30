using Assets.Tools.Script.Go;
using System;
using UnityEngine;
using XQ.Framework.Lua.Utility;

namespace XQ.Game.Util.Unity
{
	public class SystemMouseEventListener : MonoBehaviour
	{
		public static SystemMouseEventListener Instance;

		public Action<GameObject> OnMouseButtonDown0;

		public Action<GameObject> OnMouseButtonUp0;

		public static SystemMouseEventListener StartListener()
		{
			if (SystemMouseEventListener.Instance == null)
			{
				SystemMouseEventListener.Instance = ParasiticComponent.GetSecondaryHost<SystemMouseEventListener>("SystemMouseEventListener");
			}
			return SystemMouseEventListener.Instance;
		}

		public static void CloseListener()
		{
			if (SystemMouseEventListener.Instance != null)
			{
				UnityEngine.Object.Destroy(SystemMouseEventListener.Instance);
			}
		}

		public void Update()
		{
			if (this.OnMouseButtonDown0 != null)
			{
				bool mouseButtonDown = Input.GetMouseButtonDown(0);
				if (mouseButtonDown)
				{
					this.OnMouseButtonDown0(NGUITool.RaycastCurrTouchObject());
				}
			}
			if (this.OnMouseButtonUp0 != null)
			{
				bool mouseButtonUp = Input.GetMouseButtonUp(0);
				if (mouseButtonUp)
				{
					this.OnMouseButtonUp0(NGUITool.RaycastCurrTouchObject());
				}
			}
		}

		public void OnDestroy()
		{
			this.OnMouseButtonDown0 = null;
			this.OnMouseButtonUp0 = null;
		}
	}
}
