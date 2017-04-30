using ParadoxNotion;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public sealed class BlackboardSource : IBlackboard
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();

		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public Dictionary<string, Variable> variables
		{
			get
			{
				return this._variables;
			}
			set
			{
				this._variables = value;
			}
		}

		public GameObject propertiesBindTarget
		{
			get
			{
				return null;
			}
		}

		public object this[string varName]
		{
			get
			{
				object result;
				try
				{
					result = this.variables[varName].value;
				}
				catch
				{
					result = null;
				}
				return result;
			}
			set
			{
				this.SetValue(varName, value);
			}
		}

		public void InitializePropertiesBinding(GameObject targetGO, bool callSetter)
		{
			foreach (Variable current in this.variables.Values)
			{
				current.InitializePropertyBinding(targetGO, callSetter);
			}
		}

		public Variable AddVariable(string varName, object value)
		{
			if (value == null)
			{
				Debug.LogError("<b>Blackboard:</b> You can't use AddVariable with a null value. Use AddVariable(string, Type) to add the new data first");
				return null;
			}
			Variable variable = this.AddVariable(varName, value.GetType());
			if (variable != null)
			{
				variable.value = value;
			}
			return variable;
		}

		public Variable AddVariable(string varName, Type type)
		{
			if (this.variables.ContainsKey(varName))
			{
				Variable variable = this.GetVariable(varName, type);
				if (variable == null)
				{
					Debug.LogError(string.Format("<b>Blackboard:</b> Variable with name '{0}' already exists in blackboard '{1}', but is of different type!. Returning null instead of new", varName, this.name));
				}
				else
				{
					Debug.LogWarning(string.Format("<b>Blackboard:</b> Variable with name '{0}' already exists in blackboard '{1}'. Returning existing instead of new", varName, this.name));
				}
				return variable;
			}
			Type type2 = typeof(Variable<>).MakeGenericType(new Type[]
			{
				type
			});
			Variable variable2 = (Variable)Activator.CreateInstance(type2);
			variable2.name = varName;
			this.variables[varName] = variable2;
			return variable2;
		}

		public void DeleteVariable(string varName)
		{
			this.variables.Remove(varName);
		}

		public T GetValue<T>(string varName)
		{
			try
			{
				T result = (this.variables[varName] as Variable<T>).value;
				return result;
			}
			catch
			{
				try
				{
					T result = (T)((object)this.variables[varName].value);
					return result;
				}
				catch
				{
					if (!this.variables.ContainsKey(varName))
					{
						Debug.LogError(string.Format("<b>Blackboard:</b> No Variable of name '{0}' and type '{1}' exists on Blackboard '{2}'. Returning default T...", varName, typeof(T).FriendlyName(), this.name));
						T result = default(T);
						return result;
					}
				}
			}
			Debug.LogError(string.Format("<b>Blackboard:</b> Can't cast value of variable with name '{0}' to type '{1}'", varName, typeof(T).FriendlyName()));
			return default(T);
		}

		public Variable SetValue(string varName, object value)
		{
			try
			{
				Variable variable = this.variables[varName];
				variable.value = value;
				Variable result = variable;
				return result;
			}
			catch
			{
				if (!this.variables.ContainsKey(varName))
				{
					UDebug.Debug(string.Format("<b>Blackboard:</b> No Variable of name '{0}' and type '{1}' exists on Blackboard '{2}'. Adding new instead...", varName, (value == null) ? "null" : value.GetType().FriendlyName(), this.name), new object[0]);
					Variable result = this.AddVariable(varName, value);
					return result;
				}
			}
			Debug.LogError(string.Format("<b>Blackboard:</b> Can't cast value '{0}' to blackboard variable of name '{1}' and type '{2}'", (value == null) ? "null" : value.ToString(), varName, this.variables[varName].varType.Name));
			return null;
		}

		public Variable GetVariable(string varName, Type ofType = null)
		{
			if (this.variables != null && varName != null)
			{
				Variable variable;
				this.variables.TryGetValue(varName, out variable);
				if (variable != null && (ofType == null || ofType.RTIsAssignableFrom(variable.varType)))
				{
					return variable;
				}
			}
			return null;
		}

		public Variable GetVariable<T>(string varName)
		{
			return this.GetVariable(varName, typeof(T));
		}

		public string[] GetVariableNames()
		{
			return this.variables.Keys.ToArray<string>();
		}

		public string[] GetVariableNames(Type ofType)
		{
			return (from v in this.variables.Values
			where ofType.RTIsAssignableFrom(v.varType)
			select v.name).ToArray<string>();
		}

		public Variable<T> AddVariable<T>(string varName, T value)
		{
			Variable<T> variable = this.AddVariable<T>(varName);
			variable.value = value;
			return variable;
		}

		public Variable<T> AddVariable<T>(string varName)
		{
			return (Variable<T>)this.AddVariable(varName, typeof(T));
		}
	}
}
