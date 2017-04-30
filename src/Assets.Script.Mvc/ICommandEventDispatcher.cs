using System;

namespace Assets.Script.Mvc
{
	public interface ICommandEventDispatcher
	{
		void DispatchEvent(string eventName);

		void DispatchEvent(string eventName, IEvent e);

		void DispatchEvent<T>(string eventName, T arg);

		void DispatchEvent(string eventName, params object[] args);
	}
}
