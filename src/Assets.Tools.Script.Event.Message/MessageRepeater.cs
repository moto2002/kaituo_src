using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tools.Script.Event.Message
{
	public class MessageRepeater : MonoBehaviour, IMessageReceiver
	{
		public EventToHandler[] handlers;

		private readonly List<IMessageDelegate> _messageDelegates = new List<IMessageDelegate>();

		private void Start()
		{
			if (this.handlers != null)
			{
				EventToHandler[] array = this.handlers;
				for (int i = 0; i < array.Length; i++)
				{
					EventToHandler eventToHandler = array[i];
					foreach (MessageDelegate current in eventToHandler.handler)
					{
						current.messageName = eventToHandler.messageName;
						this._messageDelegates.Add(current);
					}
				}
			}
			MessageDispather.RegisterReceiver(this);
		}

		public IEnumerable<IMessageDelegate> GetDelegates()
		{
			return this._messageDelegates;
		}
	}
}
