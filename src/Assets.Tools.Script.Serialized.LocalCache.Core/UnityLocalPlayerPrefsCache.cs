using System;
using UnityEngine;

namespace Assets.Tools.Script.Serialized.LocalCache.Core
{
	public abstract class UnityLocalPlayerPrefsCache<T> : UnityLocalCache<T>
	{
		protected UnityLocalPlayerPrefsCache(string name) : base(name)
		{
		}

		public override bool HasCache()
		{
			return PlayerPrefs.HasKey(this.CacheName);
		}

		public override void DeleteCache()
		{
			PlayerPrefs.DeleteKey(this.CacheName);
		}
	}
}
