using System;
using UnityEngine;

namespace Assets.Tools.Script.Event.Message
{
	internal class UnityMessageDelegate : IMessageDelegate
	{
		private readonly MessageReceiver _messageReceiver;

		public string messageName
		{
			get;
			private set;
		}

		public UnityMessageDelegate(MessageReceiver messageReceiver, string methodName)
		{
			this._messageReceiver = messageReceiver;
			this.messageName = methodName;
		}

		public bool Execute(object arg)
		{
			if (this._messageReceiver != null)
			{
				this._messageReceiver.SendMessage(this.messageName, arg, SendMessageOptions.DontRequireReceiver);
				return true;
			}
			return false;
		}

		public bool Execute()
		{
			if (this._messageReceiver != null)
			{
				this._messageReceiver.SendMessage(this.messageName, SendMessageOptions.DontRequireReceiver);
				return true;
			}
			return false;
		}
	}
}
