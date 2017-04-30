using System;
using UnityEngine;

namespace XQ.Framework.Lua
{
	public class PrefabReleaseInfo
	{
		public MonoBehaviour Script;

		public Action Act;

		public bool HandDestroy = true;

		public PrefabReleaseInfo(MonoBehaviour behaviour, Action act)
		{
			this.Script = behaviour;
			this.Act = act;
		}
	}
}
