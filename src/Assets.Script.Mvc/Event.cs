using Assets.Script.Mvc.Pool;
using System;

namespace Assets.Script.Mvc
{
	public class Event : IEvent, IPoolable
	{
		public IPool Pool
		{
			get;
			set;
		}

		public void Restore()
		{
		}
	}
	public class Event<T> : IEvent
	{
		public T Data;

		public IPool Pool
		{
			get;
			set;
		}

		public void Restore()
		{
			this.Data = default(T);
		}
	}
}
