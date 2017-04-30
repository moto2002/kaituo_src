using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Services
{
	public static class EventHandler
	{
		public class SubscribedMember
		{
			public object subscribedObject;

			public Action<object> subscribedFunction;

			public int invokePriority;

			public bool unsubscribeWhenReceive;

			public SubscribedMember(object obj, int invokePriority, bool unsubscribeWhenReceive)
			{
				this.subscribedObject = obj;
				this.invokePriority = invokePriority;
				this.unsubscribeWhenReceive = unsubscribeWhenReceive;
			}

			public SubscribedMember(Action<object> func, int invokePriority, bool unsubscribeWhenReceive)
			{
				this.subscribedFunction = func;
				this.invokePriority = invokePriority;
				this.unsubscribeWhenReceive = unsubscribeWhenReceive;
			}
		}

		public static bool logEvents;

		public static Dictionary<string, List<EventHandler.SubscribedMember>> subscribedMembers = new Dictionary<string, List<EventHandler.SubscribedMember>>();

		public static void Subscribe(object obj, Enum eventEnum, int invokePriority = 0, bool unsubscribeWhenReceive = false)
		{
			EventHandler.Subscribe(obj, eventEnum.ToString(), invokePriority, unsubscribeWhenReceive);
		}

		public static void Subscribe(object obj, string eventName, int invokePriority = 0, bool unsubscribeWhenReceive = false)
		{
			if (obj.GetType().RTGetMethod(eventName, true) == null)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"EventHandler: No Method with name '",
					eventName,
					"' exists on '",
					obj.GetType().Name,
					"' Subscribed Type"
				}));
				return;
			}
			if (!EventHandler.subscribedMembers.ContainsKey(eventName))
			{
				EventHandler.subscribedMembers[eventName] = new List<EventHandler.SubscribedMember>();
			}
			foreach (EventHandler.SubscribedMember current in EventHandler.subscribedMembers[eventName])
			{
				if (current.subscribedObject == obj)
				{
					Debug.LogWarning(string.Concat(new object[]
					{
						"obj ",
						obj,
						" is allready subscribed to ",
						eventName
					}));
					return;
				}
			}
			if (EventHandler.logEvents)
			{
				Debug.Log(string.Concat(new object[]
				{
					"@@@ ",
					obj,
					" subscribed to ",
					eventName
				}));
			}
			EventHandler.subscribedMembers[eventName].Add(new EventHandler.SubscribedMember(obj, invokePriority, unsubscribeWhenReceive));
			EventHandler.subscribedMembers[eventName] = (from member in EventHandler.subscribedMembers[eventName]
			orderby -member.invokePriority
			select member).ToList<EventHandler.SubscribedMember>();
		}

		public static void Subscribe(Enum eventEnum, Action<object> func)
		{
			EventHandler.Subscribe(eventEnum.ToString(), func);
		}

		public static void Subscribe(string eventName, Action<object> func)
		{
			if (!EventHandler.subscribedMembers.ContainsKey(eventName))
			{
				EventHandler.subscribedMembers[eventName] = new List<EventHandler.SubscribedMember>();
			}
			foreach (EventHandler.SubscribedMember current in EventHandler.subscribedMembers[eventName])
			{
				if (current.subscribedFunction == func)
				{
					if (EventHandler.logEvents)
					{
						Debug.Log("Function allready subscribed to " + eventName);
					}
					return;
				}
			}
			EventHandler.subscribedMembers[eventName].Add(new EventHandler.SubscribedMember(func, 0, false));
		}

		public static void Unsubscribe(object obj)
		{
			if (obj == null)
			{
				return;
			}
			foreach (string current in EventHandler.subscribedMembers.Keys)
			{
				EventHandler.SubscribedMember[] array = EventHandler.subscribedMembers[current].ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					EventHandler.SubscribedMember subscribedMember = array[i];
					if (subscribedMember.subscribedObject == obj)
					{
						EventHandler.subscribedMembers[current].Remove(subscribedMember);
						if (EventHandler.logEvents)
						{
							Debug.Log("XXX " + obj + "Unsubscribed from everything!");
						}
					}
				}
			}
		}

		public static void Unsubscribe(object obj, Enum eventEnum)
		{
			EventHandler.Unsubscribe(obj, eventEnum.ToString());
		}

		public static void Unsubscribe(object obj, string eventName)
		{
			if (obj == null || !EventHandler.subscribedMembers.ContainsKey(eventName))
			{
				return;
			}
			EventHandler.SubscribedMember[] array = EventHandler.subscribedMembers[eventName].ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				EventHandler.SubscribedMember subscribedMember = array[i];
				if (subscribedMember.subscribedObject == obj)
				{
					EventHandler.subscribedMembers[eventName].Remove(subscribedMember);
					if (EventHandler.logEvents)
					{
						Debug.Log(string.Concat(new object[]
						{
							"XXX Member ",
							obj,
							" Unsubscribed from ",
							eventName
						}));
					}
					return;
				}
			}
			if (EventHandler.logEvents)
			{
				Debug.Log(string.Concat(new object[]
				{
					"You tried to Unsubscribe ",
					obj,
					" from ",
					eventName,
					", but it was never subscribed there!"
				}));
			}
		}

		public static void UnsubscribeFunction(Action<object> func)
		{
			if (func == null)
			{
				return;
			}
			foreach (string current in EventHandler.subscribedMembers.Keys)
			{
				EventHandler.SubscribedMember[] array = EventHandler.subscribedMembers[current].ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					EventHandler.SubscribedMember subscribedMember = array[i];
					if (subscribedMember.subscribedFunction != null && subscribedMember.subscribedFunction.ToString() == func.ToString())
					{
						EventHandler.subscribedMembers[current].Remove(subscribedMember);
					}
				}
			}
			if (EventHandler.logEvents)
			{
				Debug.Log("XXX " + func.ToString() + " Unsubscribed from everything");
			}
		}

		public static bool Dispatch(Enum eventEnum, object arg = null)
		{
			return EventHandler.Dispatch(eventEnum.ToString(), arg);
		}

		public static bool Dispatch(string eventName, object arg = null)
		{
			if (EventHandler.logEvents)
			{
				Debug.Log(string.Concat(new string[]
				{
					">>> Event ",
					eventName,
					" Dispatched. (",
					(arg == null) ? string.Empty : arg.GetType().Name,
					") Argument"
				}));
			}
			if (!EventHandler.subscribedMembers.ContainsKey(eventName))
			{
				Debug.LogWarning("EventHandler: Event '" + eventName + "' was not received by anyone!");
				return false;
			}
			EventHandler.SubscribedMember[] array = EventHandler.subscribedMembers[eventName].ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				EventHandler.SubscribedMember subscribedMember = array[i];
				object subscribedObject = subscribedMember.subscribedObject;
				if (subscribedObject == null && subscribedMember.subscribedFunction == null)
				{
					EventHandler.subscribedMembers[eventName].Remove(subscribedMember);
				}
				else
				{
					if (EventHandler.logEvents)
					{
						Debug.Log(string.Concat(new object[]
						{
							"<<< Event ",
							eventName,
							" Received by ",
							subscribedObject
						}));
					}
					if (subscribedMember.unsubscribeWhenReceive)
					{
						EventHandler.Unsubscribe(subscribedObject, eventName);
					}
					if (subscribedMember.subscribedFunction != null)
					{
						subscribedMember.subscribedFunction(arg);
					}
					else
					{
						MethodInfo methodInfo = subscribedObject.GetType().RTGetMethod(eventName, true);
						if (methodInfo == null)
						{
							Debug.LogWarning(string.Concat(new object[]
							{
								"Method '",
								eventName,
								"' not found on subscribed object '",
								subscribedObject,
								"'"
							}));
						}
						else
						{
							ParameterInfo[] parameters = methodInfo.GetParameters();
							if (parameters.Length > 1)
							{
								Debug.LogError(string.Concat(new object[]
								{
									"Subscribed function to call '",
									methodInfo.Name,
									"' has more than one parameter on ",
									subscribedObject,
									". It should only have one."
								}));
							}
							else
							{
								object[] arg_1D9_0;
								if (parameters.Length == 1)
								{
									(arg_1D9_0 = new object[1])[0] = arg;
								}
								else
								{
									arg_1D9_0 = null;
								}
								object[] parameters2 = arg_1D9_0;
								if (methodInfo.ReturnType == typeof(IEnumerator))
								{
									MonoManager.current.StartCoroutine((IEnumerator)methodInfo.Invoke(subscribedObject, parameters2));
								}
								else
								{
									methodInfo.Invoke(subscribedObject, parameters2);
								}
							}
						}
					}
				}
			}
			return true;
		}
	}
}
