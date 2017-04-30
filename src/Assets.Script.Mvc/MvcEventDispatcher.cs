using Assets.Script.Mvc.Pool;
using System;
using System.Collections.Generic;

namespace Assets.Script.Mvc
{
	public class MvcEventDispatcher : ICommandEventDispatcher, IEventDispatcher, IModelEventDispatcher, IViewEventDispatcher
	{
		private static Dictionary<Type, PoolBase> eventPools = new Dictionary<Type, PoolBase>();

		private Dictionary<string, Action<IEvent>> eventHandlers = new Dictionary<string, Action<IEvent>>();

		public static void ClearEventPools()
		{
			MvcEventDispatcher.eventPools.Clear();
		}

		public static Pool<T> GetEventPool<T>() where T : IEvent, new()
		{
			Type typeFromHandle = typeof(Pool<T>);
			PoolBase poolBase;
			if (!MvcEventDispatcher.eventPools.TryGetValue(typeFromHandle, out poolBase))
			{
				poolBase = new Pool<T>();
				poolBase.MaxCount = 2;
				MvcEventDispatcher.eventPools.Add(typeFromHandle, poolBase);
			}
			return (Pool<T>)poolBase;
		}

		public static T GetPoolEventInstance<T>() where T : IEvent, new()
		{
			PoolBase eventPool = MvcEventDispatcher.GetEventPool<T>();
			return (T)((object)eventPool.GetInstance());
		}

		public static void ReturnPoolEventInstance(IEvent returnEvent)
		{
			PoolBase poolBase;
			bool flag = MvcEventDispatcher.eventPools.TryGetValue(returnEvent.GetType(), out poolBase);
			if (flag)
			{
				poolBase.ReturnInstance(returnEvent);
			}
		}

		public void DispatchEvent(string eventName)
		{
			Action<IEvent> action;
			this.eventHandlers.TryGetValue(eventName, out action);
			if (action != null)
			{
				Pool<Event> eventPool = MvcEventDispatcher.GetEventPool<Event>();
				Event instance = eventPool.GetInstance();
				instance.Name = eventName;
				action(instance);
				eventPool.ReturnInstance(instance);
			}
		}

		public void DispatchEvent(string eventName, IEvent e)
		{
			Action<IEvent> action;
			this.eventHandlers.TryGetValue(eventName, out action);
			if (action != null)
			{
				e.Name = eventName;
				action(e);
			}
		}

		public void DispatchEvent<T>(string eventName, T arg)
		{
			Action<IEvent> action;
			this.eventHandlers.TryGetValue(eventName, out action);
			if (action != null)
			{
				Pool<Event<T>> eventPool = MvcEventDispatcher.GetEventPool<Event<T>>();
				Event<T> instance = eventPool.GetInstance();
				instance.Data = arg;
				instance.Name = eventName;
				action(instance);
				eventPool.ReturnInstance(instance);
			}
		}

		public void DispatchEvent(string eventName, params object[] args)
		{
			Action<IEvent> action;
			this.eventHandlers.TryGetValue(eventName, out action);
			if (action != null)
			{
				Pool<HashDataEvent> eventPool = MvcEventDispatcher.GetEventPool<HashDataEvent>();
				HashDataEvent instance = eventPool.GetInstance();
				instance.Name = eventName;
				Dictionary<string, object> datas = instance.Datas;
				for (int i = 0; i < args.Length; i += 2)
				{
					string key = (string)args[i];
					datas.Add(key, args[i + 1]);
				}
				action(instance);
				eventPool.ReturnInstance(instance);
			}
		}

		public void AddEventListener(string eventName, Action<IEvent> eventHandler)
		{
			if (!this.eventHandlers.ContainsKey(eventName))
			{
				Action<IEvent> action = null;
				action = (Action<IEvent>)Delegate.Combine(action, eventHandler);
				this.eventHandlers.Add(eventName, action);
			}
			else
			{
				Dictionary<string, Action<IEvent>> dictionary;
				Dictionary<string, Action<IEvent>> expr_38 = dictionary = this.eventHandlers;
				Action<IEvent> a = dictionary[eventName];
				expr_38[eventName] = (Action<IEvent>)Delegate.Combine(a, eventHandler);
			}
		}

		public void RemoveEventListener(string eventName, Action<IEvent> eventHandler)
		{
			if (this.eventHandlers.ContainsKey(eventName))
			{
				Dictionary<string, Action<IEvent>> dictionary;
				Dictionary<string, Action<IEvent>> expr_17 = dictionary = this.eventHandlers;
				Action<IEvent> source = dictionary[eventName];
				expr_17[eventName] = (Action<IEvent>)Delegate.Remove(source, eventHandler);
			}
		}
	}
}
