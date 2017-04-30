using Assets.Tools.Script.Serialized.LocalCache.Core;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class LcBool : UnityLocalPlayerPrefsCache<bool>
	{
		public LcBool(string name) : base(name)
		{
		}

		protected override bool GetLocalCache()
		{
			return PlayerPrefs.GetInt(this.CacheName) != 0;
		}

		protected override void SaveLocalCache(bool value)
		{
			PlayerPrefs.SetInt(this.CacheName, (!value) ? 0 : 1);
			PlayerPrefs.Save();
		}
	}
}
