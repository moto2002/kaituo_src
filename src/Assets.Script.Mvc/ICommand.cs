using System;

namespace Assets.Script.Mvc
{
	public interface ICommand
	{
		ICommandEventDispatcher EventDispatcher
		{
			get;
			set;
		}

		MvcContext Context
		{
			get;
			set;
		}

		void Execute(IEvent e);

		void OnRegister();

		void OnUnRegister();
	}
}
