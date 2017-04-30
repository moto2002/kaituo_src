using System;
using UnityEngine;

namespace XQ.Framework.Lua
{
	public abstract class ILuaScriptBase : MonoBehaviour
	{
		private PrefabReleaseInfo prefab;

		private bool show_go;

		internal ILuaScriptBase()
		{
			if (!this.show_go)
			{
				this.prefab = ResourceManager.SetGCPrefabRes(this, new Action(this.OnDestroyNow));
			}
		}

		public abstract void OnAwake();

		public abstract void OnDestroyNow();

		protected void Awake()
		{
			this.show_go = true;
			if (this.prefab != null)
			{
				this.prefab.HandDestroy = false;
				this.prefab = null;
			}
			this.OnAwake();
		}

		protected void OnDestroy()
		{
			this.OnDestroyNow();
			GameManager.ResManager.ClearMemory(false);
		}
	}
}
