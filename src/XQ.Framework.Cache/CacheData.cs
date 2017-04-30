using System;
using System.Collections.Generic;

namespace XQ.Framework.Cache
{
	public class CacheData<V>
	{
		private Dictionary<string, V> cache = new Dictionary<string, V>(500);

		public bool HasData(string key)
		{
			return this.cache.ContainsKey(key);
		}

		public void PutData(string key, V v)
		{
			this.cache.Add(key, v);
		}

		public void PutData(string key, Action<V> addCallBack, Func<V> newCallBack)
		{
			V v = this.GetData(key);
			if (v == null)
			{
				v = newCallBack();
				this.PutData(key, v);
			}
			addCallBack(v);
		}

		public V GetData(string key)
		{
			V v;
			return (!this.cache.TryGetValue(key, out v)) ? v : v;
		}
	}
}
