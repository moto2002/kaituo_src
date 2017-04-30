using System;

namespace Assets.Tools.Script.Event
{
	public class SimpleSignal
	{
		protected Action handler;

		protected Action<object> argHandler;

		protected object cacheArg;

		public void AddEventListener(Action handler)
		{
			this.handler = (Action)Delegate.Remove(this.handler, handler);
			this.handler = (Action)Delegate.Combine(this.handler, handler);
		}

		public void AddEventListener(Action<object> handler, object cacheArg)
		{
			this.argHandler = (Action<object>)Delegate.Remove(this.argHandler, handler);
			this.argHandler = (Action<object>)Delegate.Combine(this.argHandler, handler);
			this.cacheArg = cacheArg;
		}

		public void RemoveEventListener(Action handler)
		{
			this.handler = (Action)Delegate.Remove(this.handler, handler);
		}

		public void Clear()
		{
			this.handler = null;
			this.argHandler = null;
		}

		public void Dispatch()
		{
			if (this.cacheArg != null && this.argHandler != null)
			{
				this.argHandler(this.cacheArg);
			}
			else if (this.handler != null)
			{
				this.handler();
			}
		}
	}
}
