using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tools.Script.Event.Message
{
	public class MessageReceiver : MonoBehaviour, IMessageReceiver
	{
		private static readonly Dictionary<GameObject, string[]> _dynamicMessageReceiverArg = new Dictionary<GameObject, string[]>();

		[SerializeField]
		protected string[] registerMessage;

		private readonly Dictionary<string, IMessageDelegate> _registeredMessage = new Dictionary<string, IMessageDelegate>();

		public static void AddMessageReceiver(GameObject obj, params string[] registerMessage)
		{
			if (MessageReceiver._dynamicMessageReceiverArg.ContainsKey(obj))
			{
				string[] array = MessageReceiver._dynamicMessageReceiverArg[obj];
				string[] array2 = new string[array.Length + registerMessage.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = array[i];
				}
				for (int j = 0; j < registerMessage.Length; j++)
				{
					array2[j + array.Length] = registerMessage[j];
				}
			}
			else
			{
				MessageReceiver._dynamicMessageReceiverArg.Add(obj, registerMessage);
				obj.AddComponent<MessageReceiver>();
			}
		}

		private void Awake()
		{
			if (MessageReceiver._dynamicMessageReceiverArg.ContainsKey(base.gameObject))
			{
				this.registerMessage = MessageReceiver._dynamicMessageReceiverArg[base.gameObject];
				MessageReceiver._dynamicMessageReceiverArg.Remove(base.gameObject);
			}
			if (this.registerMessage != null)
			{
				string[] array = this.registerMessage;
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					if (!this._registeredMessage.ContainsKey(text))
					{
						this._registeredMessage.Add(text, new UnityMessageDelegate(this, text));
					}
				}
			}
			MessageDispather.RegisterReceiver(this);
		}

		public IEnumerable<IMessageDelegate> GetDelegates()
		{
			return this._registeredMessage.Values;
		}
	}
}
