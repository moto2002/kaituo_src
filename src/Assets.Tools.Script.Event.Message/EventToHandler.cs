using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tools.Script.Event.Message
{
	[Serializable]
	public class EventToHandler
	{
		public string messageName = string.Empty;

		[HideInInspector]
		public List<MessageDelegate> handler = new List<MessageDelegate>();

		public EventToHandler Init(string msgName, MessageDelegate.MessageCallBack.Callback obj)
		{
			this.messageName = msgName;
			this.handler.Add(new MessageDelegate(new MessageDelegate.MessageCallBack(obj)));
			return this;
		}

		public EventToHandler Init(string msgName, MessageDelegate.MessageCallBack.CallbackNoArg obj)
		{
			this.messageName = msgName;
			this.handler.Add(new MessageDelegate(new MessageDelegate.MessageCallBack(obj)));
			return this;
		}
	}
}
