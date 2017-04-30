using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Event.Message
{
	public class MessageDispather
	{
		private static readonly Dictionary<string, List<IMessageDelegate>> _messageDic = new Dictionary<string, List<IMessageDelegate>>();

		public static void SendMessage(string methodName)
		{
			if (MessageDispather._messageDic.ContainsKey(methodName))
			{
				List<IMessageDelegate> list = MessageDispather._messageDic[methodName];
				for (int i = 0; i < list.Count; i++)
				{
					if (!list[i].Execute() && MessageDispather.RemoveMessageDelegate(list[i], methodName))
					{
						i--;
					}
				}
			}
		}

		public static void SendMessage(string methodName, object value)
		{
			if (MessageDispather._messageDic.ContainsKey(methodName))
			{
				List<IMessageDelegate> list = MessageDispather._messageDic[methodName];
				for (int i = 0; i < list.Count; i++)
				{
					if (!list[i].Execute(value) && MessageDispather.RemoveMessageDelegate(list[i], methodName))
					{
						i--;
					}
				}
			}
		}

		public static void RegisterReceiver(IMessageReceiver receiver)
		{
			IEnumerable<IMessageDelegate> delegates = receiver.GetDelegates();
			foreach (IMessageDelegate current in delegates)
			{
				string messageName = current.messageName;
				if (!MessageDispather._messageDic.ContainsKey(messageName))
				{
					MessageDispather._messageDic.Add(messageName, new List<IMessageDelegate>());
				}
				MessageDispather._messageDic[messageName].Add(current);
			}
		}

		private static bool RemoveMessageDelegate(IMessageDelegate messageDelegate, string message)
		{
			bool result = false;
			if (MessageDispather._messageDic.ContainsKey(message))
			{
				List<IMessageDelegate> list = MessageDispather._messageDic[message];
				result = list.Remove(messageDelegate);
				if (list.Count == 0)
				{
					MessageDispather._messageDic.Remove(message);
				}
			}
			return result;
		}
	}
}
