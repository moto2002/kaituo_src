using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Common"), Description("Send a Unity message to all game objects with a component of the specified type. Notice: This is slow")]
	public class SendMessageToType<T> : ActionTask where T : Component
	{
		public BBParameter<string> message;

		[BlackboardOnly]
		public BBParameter<object> argument;

		protected override string info
		{
			get
			{
				return string.Format("Message {0}({1}) to all {2}", this.message, this.argument.ToString(), typeof(T).Name);
			}
		}

		protected override void OnExecute()
		{
			T[] array = UnityEngine.Object.FindObjectsOfType<T>();
			if (array.Length == 0)
			{
				base.EndAction(new bool?(false));
				return;
			}
			T[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				T t = array2[i];
				t.gameObject.SendMessage(this.message.value, this.argument.value, SendMessageOptions.DontRequireReceiver);
			}
			base.EndAction(new bool?(true));
		}
	}
}
