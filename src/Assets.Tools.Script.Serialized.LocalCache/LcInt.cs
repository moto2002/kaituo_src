using Assets.Tools.Script.Serialized.LocalCache.Core;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class LcInt : UnityLocalPlayerPrefsCache<int>
	{
		public LcInt(string name) : base(name)
		{
		}

		protected override int GetLocalCache()
		{
			return PlayerPrefs.GetInt(this.CacheName);
		}

		protected override void SaveLocalCache(int value)
		{
			PlayerPrefs.SetInt(this.CacheName, value);
			PlayerPrefs.Save();
		}
	}
}
