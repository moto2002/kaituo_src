using System;

namespace Assets.Script.Mvc
{
	public interface IViewEventDispatcher
	{
		void DispatchEvent(string eventName);

		void DispatchEvent(string eventName, IEvent e);

		void DispatchEvent<T>(string eventName, T arg);

		void DispatchEvent(string eventName, params object[] args);

		void AddEventListener(string eventName, Action<IEvent> eventHandler);

		void RemoveEventListener(string eventName, Action<IEvent> eventHandler);
	}
}
