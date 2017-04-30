using System;

namespace Assets.Tools.Script.Event
{
	public class Signal<T>
	{
		protected Action<T> handler;

		public void AddEventListener(Action<T> handler)
		{
			this.handler = (Action<T>)Delegate.Remove(this.handler, handler);
			this.handler = (Action<T>)Delegate.Combine(this.handler, handler);
		}

		public void RemoveEventListener(Action<T> handler)
		{
			this.handler = (Action<T>)Delegate.Remove(this.handler, handler);
		}

		public void Clear()
		{
			this.handler = null;
		}

		public void Dispatch(T arg)
		{
			if (this.handler != null)
			{
				this.handler(arg);
			}
		}
	}
	public class Signal<T1, T2>
	{
		protected Action<T1, T2> handler;

		public void AddEventListener(Action<T1, T2> handler)
		{
			this.handler = (Action<T1, T2>)Delegate.Remove(this.handler, handler);
			this.handler = (Action<T1, T2>)Delegate.Combine(this.handler, handler);
		}

		public void RemoveEventListener(Action<T1, T2> handler)
		{
			this.handler = (Action<T1, T2>)Delegate.Remove(this.handler, handler);
		}

		public void Clear()
		{
			this.handler = null;
		}

		public void Dispatch(T1 arg, T2 arg2)
		{
			if (this.handler != null)
			{
				this.handler(arg, arg2);
			}
		}
	}
}
