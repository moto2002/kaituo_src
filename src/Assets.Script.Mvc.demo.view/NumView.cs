using System;
using UnityEngine;

namespace Assets.Script.Mvc.demo.view
{
	public class NumView : MonoView
	{
		private string label;

		public override void OnRegister()
		{
			this.EventDispatcher.AddEventListener("NumChange", new Action<IEvent>(this.OnNumChange));
		}

		private void OnNumChange(IEvent obj)
		{
			this.label = (obj as Event<int>).Data.ToString();
		}

		private void OnGUI()
		{
			GUILayout.Label(this.label, new GUILayoutOption[0]);
			if (GUILayout.Button("Add 1", new GUILayoutOption[0]))
			{
				this.EventDispatcher.DispatchEvent<int>("AddNum", 1);
			}
			if (GUILayout.Button("Add 5", new GUILayoutOption[0]))
			{
				this.EventDispatcher.DispatchEvent<int>("AddNum", 5);
			}
		}
	}
}
