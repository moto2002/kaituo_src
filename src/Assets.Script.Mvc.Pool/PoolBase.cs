using System;
using System.Collections.Generic;

namespace Assets.Script.Mvc.Pool
{
	public abstract class PoolBase : IPool
	{
		protected Stack<object> AvailableObjects = new Stack<object>();

		public int MaxCount
		{
			get;
			set;
		}

		public object GetInstance()
		{
			if (this.AvailableObjects.Count > 0)
			{
				return this.AvailableObjects.Pop();
			}
			return this.CreateObject();
		}

		public virtual bool ReturnInstance(object obj)
		{
			if (this.AvailableObjects.Count < this.MaxCount)
			{
				if (obj is IPoolable)
				{
					(obj as IPoolable).Restore();
				}
				this.AvailableObjects.Push(obj);
				return true;
			}
			return false;
		}

		public virtual void Clear()
		{
			this.AvailableObjects.Clear();
		}

		protected abstract object CreateObject();
	}
}
