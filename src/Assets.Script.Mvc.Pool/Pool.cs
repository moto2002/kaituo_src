using System;

namespace Assets.Script.Mvc.Pool
{
	public class Pool<T> : PoolBase where T : new()
	{
		public new T GetInstance()
		{
			return (T)((object)base.GetInstance());
		}

		protected override object CreateObject()
		{
			T t = (default(T) == null) ? Activator.CreateInstance<T>() : default(T);
			if (t is IPoolable)
			{
				IPoolable poolable = t as IPoolable;
				poolable.Pool = this;
			}
			return t;
		}
	}
}
