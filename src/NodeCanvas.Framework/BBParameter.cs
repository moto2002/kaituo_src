using ParadoxNotion;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	public abstract class BBParameter
	{
		[SerializeField]
		private string _name;

		[NonSerialized]
		private IBlackboard _bb;

		[NonSerialized]
		private Variable _varRef;

		private Variable globalVarRef
		{
			get
			{
				if (this.name == null || !this.name.Contains("/"))
				{
					return null;
				}
				string bbName = this.name.Split(new char[]
				{
					'/'
				})[0];
				string name = this.name.Split(new char[]
				{
					'/'
				})[1];
				GlobalBlackboard globalBlackboard = GlobalBlackboard.allGlobals.Find((GlobalBlackboard b) => b.name == bbName);
				if (globalBlackboard == null)
				{
					return null;
				}
				Variable variable = globalBlackboard.GetVariable(name, null);
				if (variable == null)
				{
					return null;
				}
				return variable;
			}
		}

		protected Variable varRef
		{
			get
			{
				return this._varRef;
			}
			set
			{
				value = ((this.globalVarRef == null) ? value : this.globalVarRef);
				if (this._varRef != value || value == null)
				{
					this._varRef = value;
					this.Bind(value);
				}
			}
		}

		public IBlackboard bb
		{
			get
			{
				return this._bb;
			}
			set
			{
				if (this._bb != value)
				{
					this._bb = value;
					this.varRef = ((value == null || string.IsNullOrEmpty(this.name)) ? null : value.GetVariable(this.name, this.varType));
				}
			}
		}

		public string name
		{
			get
			{
				if (this._name == null || this._name.Contains("/"))
				{
					return this._name;
				}
				return (this.varRef == null) ? this._name : this.varRef.name;
			}
			set
			{
				if (this._name != value)
				{
					this._name = value;
					if (value != null)
					{
						this.useBlackboard = true;
						if (this.bb != null)
						{
							this.varRef = this.bb.GetVariable(this._name, this.varType);
						}
					}
					else
					{
						this.varRef = null;
					}
				}
			}
		}

		public bool useBlackboard
		{
			get
			{
				return this.name != null;
			}
			set
			{
				if (!value)
				{
					this.name = null;
				}
				if (value && this.name == null)
				{
					this.name = string.Empty;
				}
			}
		}

		public bool isNone
		{
			get
			{
				return this.name == string.Empty;
			}
		}

		public bool isNull
		{
			get
			{
				return this.objectValue == null || this.objectValue.Equals(null);
			}
		}

		public Type refType
		{
			get
			{
				return (this.varRef == null) ? null : this.varRef.varType;
			}
		}

		public object value
		{
			get
			{
				return this.objectValue;
			}
			set
			{
				this.objectValue = value;
			}
		}

		protected abstract object objectValue
		{
			get;
			set;
		}

		public abstract Type varType
		{
			get;
		}

		public BBParameter()
		{
		}

		public static BBParameter CreateInstance(Type t, IBlackboard bb)
		{
			if (t == null)
			{
				return null;
			}
			BBParameter bBParameter = (BBParameter)Activator.CreateInstance(typeof(BBParameter<>).RTMakeGenericType(new Type[]
			{
				t
			}));
			bBParameter.bb = bb;
			return bBParameter;
		}

		public static void SetBBFields(object o, IBlackboard bb)
		{
			BBParameter.ParseObject(o, delegate(BBParameter bbParam)
			{
				bbParam.bb = bb;
				if (bb != null)
				{
					bbParam.varRef = bb.GetVariable(bbParam.name, null);
				}
			});
		}

		public static void ParseObject(object o, Action<BBParameter> Call)
		{
			FieldInfo[] array = o.GetType().RTGetFields();
			for (int i = 0; i < array.Length; i++)
			{
				FieldInfo fieldInfo = array[i];
				if (fieldInfo.RTGetAttribute(false) != null && fieldInfo.GetValue(o) != null)
				{
					BBParameter.ParseObject(fieldInfo.GetValue(o), Call);
				}
				if (fieldInfo.FieldType.RTIsSubclassOf(typeof(BBParameter)))
				{
					if (fieldInfo.GetValue(o) == null)
					{
						fieldInfo.SetValue(o, Activator.CreateInstance(fieldInfo.FieldType));
					}
					Call((BBParameter)fieldInfo.GetValue(o));
				}
				if (fieldInfo.GetValue(o) != null && typeof(IList).RTIsAssignableFrom(fieldInfo.FieldType) && !fieldInfo.FieldType.RTIsArray() && typeof(BBParameter).RTIsAssignableFrom(fieldInfo.FieldType.RTGetGenericArguments()[0]))
				{
					foreach (BBParameter obj in ((IList)fieldInfo.GetValue(o)))
					{
						Call(obj);
					}
				}
			}
		}

		protected abstract void Bind(Variable data);

		public override string ToString()
		{
			if (this.isNone)
			{
				return "<b>NONE</b>";
			}
			if (this.useBlackboard)
			{
				return string.Format("<b>${0}</b>", this.name);
			}
			if (this.isNull)
			{
				return "<b>NULL</b>";
			}
			if (this.objectValue is string)
			{
				return string.Format("<b>\"{0}\"</b>", this.objectValue.ToString());
			}
			if (this.objectValue is IList)
			{
				return string.Format("<b>{0}</b>", this.varType.FriendlyName());
			}
			if (this.objectValue is IDictionary)
			{
				return string.Format("<b>{0}</b>", this.varType.FriendlyName());
			}
			if (this.objectValue is UnityEngine.Object)
			{
				return string.Format("<b>{0}</b>", (this.objectValue as UnityEngine.Object).name);
			}
			return string.Format("<b>{0}</b>", this.objectValue.ToString());
		}
	}
	[Serializable]
	public class BBParameter<T> : BBParameter
	{
		private Func<T> getter;

		private Action<T> setter;

		[SerializeField]
		protected T _value;

		public new T value
		{
			get
			{
				if (!Application.isPlaying && this.getter != null)
				{
					return this.getter();
				}
				if (base.name != null && base.bb != null)
				{
					if (Application.isPlaying)
					{
						Variable variable = base.bb.GetVariable<T>(base.name);
						if (variable == null)
						{
							return default(T);
						}
						return (T)((object)variable.value);
					}
					else
					{
						this.Bind(base.bb.GetVariable<T>(base.name));
						if (this.getter != null)
						{
							return this.getter();
						}
					}
				}
				return this._value;
			}
			set
			{
				if (!Application.isPlaying && this.setter != null)
				{
					this.setter(value);
					return;
				}
				if (base.isNone)
				{
					return;
				}
				if (base.name != null && base.bb != null)
				{
					base.varRef = base.bb.SetValue(base.name, value);
					return;
				}
				this._value = value;
			}
		}

		protected override object objectValue
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = (T)((object)value);
			}
		}

		public override Type varType
		{
			get
			{
				return typeof(T);
			}
		}

		public BBParameter()
		{
		}

		public BBParameter(T value)
		{
			this._value = value;
		}

		protected override void Bind(Variable data)
		{
			if (data == null)
			{
				this.getter = null;
				this.setter = null;
				if (base.useBlackboard)
				{
					this._value = default(T);
				}
				return;
			}
			if (!typeof(T).RTIsAssignableFrom(data.varType) && !data.varType.RTIsAssignableFrom(typeof(T)))
			{
				Debug.LogWarning(string.Format("<b>BBParameter</b>: Found Variable of name '{0}' and type '{1}' on Blackboard '{2}' is not of requested type '{3}'", new object[]
				{
					base.name,
					data.varType.FriendlyName(),
					base.bb.name,
					typeof(T).FriendlyName()
				}));
				return;
			}
			this.BindSetter(data);
			this.BindGetter(data);
		}

		private void BindGetter(Variable data)
		{
			if (data is Variable<T>)
			{
				this.getter = new Func<T>((data as Variable<T>).GetValue);
			}
			else if (typeof(T).RTIsAssignableFrom(data.varType))
			{
				this.getter = (() => (T)((object)data.value));
			}
		}

		private void BindSetter(Variable data)
		{
			if (data is Variable<T>)
			{
				this.setter = new Action<T>((data as Variable<T>).SetValue);
			}
			else if (data.varType.RTIsAssignableFrom(typeof(T)))
			{
				this.setter = delegate(T newValue)
				{
					data.value = newValue;
				};
			}
		}

		public static implicit operator BBParameter<T>(T value)
		{
			return new BBParameter<T>
			{
				value = value
			};
		}
	}
}
