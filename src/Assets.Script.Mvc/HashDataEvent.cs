using Assets.Script.Mvc.Pool;
using System;
using System.Collections.Generic;

namespace Assets.Script.Mvc
{
	public class HashDataEvent : IEvent, IPoolable
	{
		public Dictionary<string, object> Datas = new Dictionary<string, object>();

		public IPool Pool
		{
			get;
			set;
		}

		public T Get<T>(string name)
		{
			object obj;
			bool flag = this.Datas.TryGetValue(name, out obj);
			if (flag)
			{
				return (T)((object)obj);
			}
			return default(T);
		}

		public void Restore()
		{
			this.Datas.Clear();
		}
	}
}
