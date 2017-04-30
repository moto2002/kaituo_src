using NodeCanvas.Framework;
using System;
using UnityEngine;

namespace Assets.Scripts.Performance
{
	public class BBProxy : MonoBehaviour
	{
		public Blackboard Blackboard;

		public void SetValue(string key, object value)
		{
			this.Blackboard.SetValue(key, value);
		}

		public object GetValue(string key)
		{
			return this.Blackboard.GetVariable(key, null).value;
		}

		public bool HasKey(string key)
		{
			return this.Blackboard.variables.ContainsKey(key);
		}
	}
}
