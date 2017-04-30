using System;

namespace Assets.Script.Mvc
{
	public abstract class Command : ICommand
	{
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

		public abstract void Execute(IEvent e);

		public virtual void OnRegister()
		{
		}

		public virtual void OnUnRegister()
		{
		}
	}
}
