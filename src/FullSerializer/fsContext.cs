using System;
using System.Collections.Generic;

namespace FullSerializer
{
	public sealed class fsContext
	{
		private readonly Dictionary<Type, object> _contextObjects = new Dictionary<Type, object>();

		public void Reset()
		{
			this._contextObjects.Clear();
		}

		public void Set<T>(T obj)
		{
			this._contextObjects[typeof(T)] = obj;
		}

		public bool Has<T>()
		{
			return this._contextObjects.ContainsKey(typeof(T));
		}

		public T Get<T>()
		{
			object obj;
			if (this._contextObjects.TryGetValue(typeof(T), out obj))
			{
				return (T)((object)obj);
			}
			throw new InvalidOperationException("There is no context object of type " + typeof(T));
		}
	}
}
