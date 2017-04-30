using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public class Blackboard : MonoBehaviour, ISerializationCallbackReceiver, IBlackboard
	{
		[SerializeField]
		private string _serializedBlackboard;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[NonSerialized]
		private BlackboardSource _blackboard = new BlackboardSource();

		public new string name
		{
			get
			{
				return (!string.IsNullOrEmpty(this._blackboard.name)) ? this._blackboard.name : (base.gameObject.name + "_BB");
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					value = base.gameObject.name + "_BB";
				}
				this._blackboard.name = value;
			}
		}

		public object this[string varName]
		{
			get
			{
				return this._blackboard[varName];
			}
			set
			{
				this.SetValue(varName, value);
			}
		}

		public Dictionary<string, Variable> variables
		{
			get
			{
				return this._blackboard.variables;
			}
			set
			{
				this._blackboard.variables = value;
			}
		}

		public GameObject propertiesBindTarget
		{
			get
			{
				return base.gameObject;
			}
		}

		public void OnBeforeSerialize()
		{
			if (Application.isPlaying)
			{
				return;
			}
			this._objectReferences = new List<UnityEngine.Object>();
			this._serializedBlackboard = JSON.Serialize(typeof(BlackboardSource), this._blackboard, false, this._objectReferences);
		}

		public void OnAfterDeserialize()
		{
			this._blackboard = JSON.Deserialize<BlackboardSource>(this._serializedBlackboard, this._objectReferences);
			if (this._blackboard == null)
			{
				this._blackboard = new BlackboardSource();
			}
		}

		private void Awake()
		{
			this._blackboard.InitializePropertiesBinding(this.propertiesBindTarget, false);
		}

		public Variable AddVariable(string name, Type type)
		{
			return this._blackboard.AddVariable(name, type);
		}

		public Variable GetVariable(string name, Type ofType = null)
		{
			return this._blackboard.GetVariable(name, ofType);
		}

		public Variable GetVariable<T>(string name)
		{
			return this.GetVariable(name, typeof(T));
		}

		public T GetValue<T>(string name)
		{
			return this._blackboard.GetValue<T>(name);
		}

		public Variable SetValue(string name, object value)
		{
			return this._blackboard.SetValue(name, value);
		}

		public string[] GetVariableNames()
		{
			return this._blackboard.GetVariableNames();
		}

		public string[] GetVariableNames(Type ofType)
		{
			return this._blackboard.GetVariableNames(ofType);
		}

		public string Save()
		{
			return this.Save(this.name);
		}

		public string Save(string saveKey)
		{
			string text = JSON.Serialize(typeof(BlackboardSource), this._blackboard, false, this._objectReferences);
			PlayerPrefs.SetString(saveKey, text);
			return text;
		}

		public bool Load()
		{
			return this.Load(this.name);
		}

		public bool Load(string saveKey)
		{
			string @string = PlayerPrefs.GetString(saveKey);
			if (string.IsNullOrEmpty(@string))
			{
				Debug.Log("No data to load");
				return false;
			}
			this._blackboard = JSON.Deserialize<BlackboardSource>(@string, this._objectReferences);
			this._blackboard.InitializePropertiesBinding(this.propertiesBindTarget, true);
			return true;
		}
	}
}
