using Assets.Script.Mvc.Pool;
using System;

namespace Assets.Script.Mvc
{
	public class SingleUseCommandAgent<T> : ICommand where T : ICommand, new()
	{
		private Pool<T> commandPool;

		public ICommandEventDispatcher EventDispatcher
		{
			get;
			set;
		}

		public MvcContext Context
		{
			get;
			set;
		}

		public void Execute(IEvent e)
		{
			T t;
			if (this.commandPool == null)
			{
				t = ((default(T) == null) ? Activator.CreateInstance<T>() : default(T));
				if (t is IPoolable)
				{
					this.commandPool = new Pool<T>();
					this.commandPool.MaxCount = 5;
					IPoolable poolable = t as IPoolable;
					poolable.Pool = this.commandPool;
				}
			}
			else
			{
				t = this.commandPool.GetInstance();
			}
			t.Context = this.Context;
			t.EventDispatcher = this.EventDispatcher;
			t.Execute(e);
		}

		public void OnRegister()
		{
		}

		public void OnUnRegister()
		{
		}
	}
}
