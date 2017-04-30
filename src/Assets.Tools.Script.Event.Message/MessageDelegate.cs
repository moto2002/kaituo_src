using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.Tools.Script.Event.Message
{
	[Serializable]
	public class MessageDelegate : IMessageDelegate
	{
		public class MessageCallBack
		{
			public delegate void Callback(object obj);

			public delegate void CallbackNoArg();

			private MessageDelegate.MessageCallBack.Callback mCachedCallback;

			private MessageDelegate.MessageCallBack.CallbackNoArg mCachedCallbackNoArg;

			public MethodInfo Method
			{
				get
				{
					if (this.mCachedCallback != null)
					{
						return this.mCachedCallback.Method;
					}
					return this.mCachedCallbackNoArg.Method;
				}
			}

			public object Target
			{
				get
				{
					if (this.mCachedCallback != null)
					{
						return this.mCachedCallback.Target;
					}
					return this.mCachedCallbackNoArg.Target;
				}
			}

			public MessageCallBack(MessageDelegate.MessageCallBack.Callback callback)
			{
				this.mCachedCallback = callback;
			}

			public MessageCallBack(MessageDelegate.MessageCallBack.CallbackNoArg callback)
			{
				this.mCachedCallbackNoArg = callback;
			}

			public static MessageDelegate.MessageCallBack Create(MonoBehaviour monoBehaviour, string methodName)
			{
				MessageDelegate.MessageCallBack result = null;
				try
				{
					MessageDelegate.MessageCallBack.Callback callback = (MessageDelegate.MessageCallBack.Callback)Delegate.CreateDelegate(typeof(MessageDelegate.MessageCallBack.Callback), monoBehaviour, methodName);
					result = new MessageDelegate.MessageCallBack(callback);
				}
				catch (Exception)
				{
					MessageDelegate.MessageCallBack.CallbackNoArg callback2 = (MessageDelegate.MessageCallBack.CallbackNoArg)Delegate.CreateDelegate(typeof(MessageDelegate.MessageCallBack.CallbackNoArg), monoBehaviour, methodName);
					result = new MessageDelegate.MessageCallBack(callback2);
				}
				return result;
			}

			public void Call(object arg)
			{
				if (this.mCachedCallback != null)
				{
					this.mCachedCallback(arg);
				}
				else
				{
					this.mCachedCallbackNoArg();
				}
			}
		}

		[SerializeField]
		private MonoBehaviour mTarget;

		[SerializeField]
		private string mMethodName;

		public bool oneShot;

		private MessageDelegate.MessageCallBack mCachedCallback;

		private bool mRawDelegate;

		private static int s_Hash = "MessageDelegate".GetHashCode();

		public MonoBehaviour target
		{
			get
			{
				return this.mTarget;
			}
			set
			{
				this.mTarget = value;
				this.mCachedCallback = null;
				this.mRawDelegate = false;
			}
		}

		public string methodName
		{
			get
			{
				return this.mMethodName;
			}
			set
			{
				this.mMethodName = value;
				this.mCachedCallback = null;
				this.mRawDelegate = false;
			}
		}

		public bool isValid
		{
			get
			{
				return (this.mRawDelegate && this.mCachedCallback != null) || (this.mTarget != null && !string.IsNullOrEmpty(this.mMethodName));
			}
		}

		public bool isEnabled
		{
			get
			{
				if (this.mRawDelegate && this.mCachedCallback != null)
				{
					return true;
				}
				if (this.mTarget == null)
				{
					return false;
				}
				MonoBehaviour monoBehaviour = this.mTarget;
				return monoBehaviour == null || monoBehaviour.enabled;
			}
		}

		public string messageName
		{
			get;
			set;
		}

		public MessageDelegate()
		{
		}

		public MessageDelegate(MessageDelegate.MessageCallBack call)
		{
			this.Set(call);
		}

		public MessageDelegate(MonoBehaviour target, string methodName)
		{
			this.Set(target, methodName);
		}

		private static string GetMethodName(MessageDelegate.MessageCallBack callback)
		{
			return callback.Method.Name;
		}

		private static bool IsValid(MessageDelegate.MessageCallBack callback)
		{
			return callback != null && callback.Method != null;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return !this.isValid;
			}
			if (obj is MessageDelegate.MessageCallBack)
			{
				MessageDelegate.MessageCallBack messageCallBack = obj as MessageDelegate.MessageCallBack;
				if (messageCallBack.Equals(this.mCachedCallback))
				{
					return true;
				}
				MonoBehaviour y = messageCallBack.Target as MonoBehaviour;
				return this.mTarget == y && string.Equals(this.mMethodName, MessageDelegate.GetMethodName(messageCallBack));
			}
			else
			{
				if (obj is MessageDelegate)
				{
					MessageDelegate messageDelegate = obj as MessageDelegate;
					return this.mTarget == messageDelegate.mTarget && string.Equals(this.mMethodName, messageDelegate.mMethodName);
				}
				return false;
			}
		}

		public override int GetHashCode()
		{
			return MessageDelegate.s_Hash;
		}

		private MessageDelegate.MessageCallBack Get()
		{
			if (!this.mRawDelegate && (this.mCachedCallback == null || this.mCachedCallback.Target as MonoBehaviour != this.mTarget || MessageDelegate.GetMethodName(this.mCachedCallback) != this.mMethodName))
			{
				if (!(this.mTarget != null) || string.IsNullOrEmpty(this.mMethodName))
				{
					return null;
				}
				this.mCachedCallback = MessageDelegate.MessageCallBack.Create(this.mTarget, this.mMethodName);
			}
			if (this.mTarget == null)
			{
				return null;
			}
			return this.mCachedCallback;
		}

		private void Set(MessageDelegate.MessageCallBack call)
		{
			if (call == null || !MessageDelegate.IsValid(call))
			{
				this.mTarget = null;
				this.mMethodName = null;
				this.mCachedCallback = null;
				this.mRawDelegate = false;
			}
			else
			{
				this.mTarget = (call.Target as MonoBehaviour);
				if (this.mTarget == null)
				{
					this.mRawDelegate = true;
					this.mCachedCallback = call;
					this.mMethodName = null;
				}
				else
				{
					this.mMethodName = MessageDelegate.GetMethodName(call);
					this.mRawDelegate = false;
				}
			}
		}

		public void Set(MonoBehaviour target, string methodName)
		{
			this.mTarget = target;
			this.mMethodName = methodName;
			this.mCachedCallback = null;
			this.mRawDelegate = false;
		}

		public bool Execute(object arg)
		{
			MessageDelegate.MessageCallBack messageCallBack = null;
			try
			{
				messageCallBack = this.Get();
			}
			catch (Exception)
			{
			}
			if (messageCallBack != null)
			{
				messageCallBack.Call(arg);
				return true;
			}
			return false;
		}

		public bool Execute()
		{
			return this.Execute(null);
		}

		public void Clear()
		{
			this.mTarget = null;
			this.mMethodName = null;
			this.mRawDelegate = false;
			this.mCachedCallback = null;
		}

		public override string ToString()
		{
			if (!(this.mTarget != null))
			{
				return (!this.mRawDelegate) ? null : "[delegate]";
			}
			string text = this.mTarget.GetType().ToString();
			int num = text.LastIndexOf('.');
			if (num > 0)
			{
				text = text.Substring(num + 1);
			}
			if (!string.IsNullOrEmpty(this.methodName))
			{
				return text + "." + this.methodName;
			}
			return text + ".[delegate]";
		}

		public static void Execute(List<MessageDelegate> list, object arg)
		{
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					MessageDelegate messageDelegate = list[i];
					if (messageDelegate != null)
					{
						messageDelegate.Execute(arg);
						if (i >= list.Count)
						{
							break;
						}
						if (list[i] != messageDelegate)
						{
							continue;
						}
						if (messageDelegate.oneShot)
						{
							list.RemoveAt(i);
							continue;
						}
					}
				}
			}
		}

		public static bool IsValid(List<MessageDelegate> list)
		{
			if (list != null)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					MessageDelegate messageDelegate = list[i];
					if (messageDelegate != null && messageDelegate.isValid)
					{
						return true;
					}
					i++;
				}
			}
			return false;
		}

		public static void Set(List<MessageDelegate> list, MessageDelegate.MessageCallBack callback)
		{
			if (list != null)
			{
				list.Clear();
				list.Add(new MessageDelegate(callback));
			}
		}

		public static void Set(List<MessageDelegate> list, MessageDelegate del)
		{
			if (list != null)
			{
				list.Clear();
				list.Add(del);
			}
		}

		public static void Add(List<MessageDelegate> list, MessageDelegate.MessageCallBack callback)
		{
			MessageDelegate.Add(list, callback, false);
		}

		public static void Add(List<MessageDelegate> list, MessageDelegate.MessageCallBack callback, bool oneShot)
		{
			if (list != null)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					MessageDelegate messageDelegate = list[i];
					if (messageDelegate != null && messageDelegate.Equals(callback))
					{
						return;
					}
					i++;
				}
				list.Add(new MessageDelegate(callback)
				{
					oneShot = oneShot
				});
			}
			else
			{
				Debug.LogWarning("Attempting to add a callback to a list that's null");
			}
		}

		public static void Add(List<MessageDelegate> list, MessageDelegate ev)
		{
			MessageDelegate.Add(list, ev, ev.oneShot);
		}

		public static void Add(List<MessageDelegate> list, MessageDelegate ev, bool oneShot)
		{
			if (ev.mRawDelegate || ev.target == null || string.IsNullOrEmpty(ev.methodName))
			{
				MessageDelegate.Add(list, ev.mCachedCallback, oneShot);
			}
			else if (list != null)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					MessageDelegate messageDelegate = list[i];
					if (messageDelegate != null && messageDelegate.Equals(ev))
					{
						return;
					}
					i++;
				}
				list.Add(new MessageDelegate(ev.target, ev.methodName)
				{
					oneShot = oneShot
				});
			}
			else
			{
				Debug.LogWarning("Attempting to add a callback to a list that's null");
			}
		}

		public static bool Remove(List<MessageDelegate> list, MessageDelegate.MessageCallBack callback)
		{
			if (list != null)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					MessageDelegate messageDelegate = list[i];
					if (messageDelegate != null && messageDelegate.Equals(callback))
					{
						list.RemoveAt(i);
						return true;
					}
					i++;
				}
			}
			return false;
		}
	}
}
