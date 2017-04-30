using System;

namespace Assets.Script.Mvc
{
	public interface IView
	{
		IViewEventDispatcher EventDispatcher
		{
			get;
			set;
		}

		MvcContext Context
		{
			get;
			set;
		}

		void OnRegister();

		void OnUnRegister();
	}
}