using ParadoxNotion;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	public abstract class Variable
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private bool _nonEditable;

		public event Action<string, object> onValueChanged
		{
			[MethodImpl(32)]
			add
			{
				this.onValueChanged = (Action<string, object>)Delegate.Combine(this.onValueChanged, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.onValueChanged = (Action<string, object>)Delegate.Remove(this.onValueChanged, value);
			}
		}

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

		public bool nonEditable
		{
			get
			{
				return this._nonEditable;
			}
			set
			{
				this._nonEditable = value;
			}
		}

		public abstract string propertyPath
		{
			get;
			set;
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

		public abstract bool hasBinding
		{
			get;
		}

		public Variable()
		{
		}

		protected void OnValueChanged(string name, object value)
		{
			if (this.onValueChanged != null)
			{
				this.onValueChanged(name, value);
			}
		}

		public abstract void BindProperty(PropertyInfo prop, GameObject target = null);

		public abstract void UnBindProperty();

		public abstract void InitializePropertyBinding(GameObject go, bool callSetter = false);
	}
	[Serializable]
	public class Variable<T> : Variable
	{
		[SerializeField]
		private T _value;

		[SerializeField]
		private string _propertyPath;

		private Func<T> getter;

		private Action<T> setter;

		public new event Action<string, T> onValueChanged
		{
			[MethodImpl(32)]
			add
			{
				this.onValueChanged = (Action<string, T>)Delegate.Combine(this.onValueChanged, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.onValueChanged = (Action<string, T>)Delegate.Remove(this.onValueChanged, value);
			}
		}

		public override string propertyPath
		{
			get
			{
				return this._propertyPath;
			}
			set
			{
				this._propertyPath = value;
			}
		}

		public override bool hasBinding
		{
			get
			{
				return !string.IsNullOrEmpty(this._propertyPath);
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

		public new T value
		{
			get
			{
				return (this.getter == null) ? this._value : this.getter();
			}
			set
			{
				this._value = value;
				if (this.setter != null)
				{
					this.setter(value);
				}
				if (this.onValueChanged != null)
				{
					this.onValueChanged(base.name, value);
					base.OnValueChanged(base.name, value);
				}
			}
		}

		public T GetValue()
		{
			return this.value;
		}

		public void SetValue(T newValue)
		{
			this.value = newValue;
		}

		public override void BindProperty(PropertyInfo prop, GameObject target = null)
		{
			this._propertyPath = string.Format("{0}.{1}", prop.RTReflectedType().Name, prop.Name);
			if (target != null)
			{
				this.InitializePropertyBinding(target, false);
			}
		}

		public override void UnBindProperty()
		{
			this._propertyPath = null;
			this.getter = null;
			this.setter = null;
		}

		public override void InitializePropertyBinding(GameObject go, bool callSetter = false)
		{
			if (!this.hasBinding || !Application.isPlaying)
			{
				return;
			}
			this.getter = null;
			this.setter = null;
			string[] array = this._propertyPath.Split(new char[]
			{
				'.'
			});
			Component component = go.GetComponent(array[0]);
			if (component == null)
			{
				Debug.LogWarning(string.Format("A Blackboard Variable '{0}' is due to bind to a Component type that is missing '{1}'. Binding ingored", base.name, array[0]));
				return;
			}
			PropertyInfo propertyInfo = component.GetType().RTGetProperty(array[1]);
			if (propertyInfo == null)
			{
				Debug.LogWarning(string.Format("A Blackboard Variable '{0}' is due to bind to a property that does not exist in type '{1}'. Binding ignored", base.name, array[0]));
				return;
			}
			if (propertyInfo.CanRead)
			{
				MethodInfo methodInfo = propertyInfo.RTGetGetMethod();
				if (methodInfo != null)
				{
					this.getter = methodInfo.RTCreateDelegate(component);
				}
				else
				{
					Debug.Log(string.Format("Binded Property '{0}' on type '{1}' get accessor is private. Getter binding ignored", propertyInfo.Name, component.GetType().Name));
				}
			}
			if (propertyInfo.CanWrite)
			{
				MethodInfo methodInfo2 = propertyInfo.RTGetSetMethod();
				if (methodInfo2 != null)
				{
					this.setter = methodInfo2.RTCreateDelegate(component);
					if (callSetter)
					{
						this.setter(this._value);
					}
				}
				else
				{
					Debug.Log(string.Format("Binded Property '{0}' on type '{1}' set accessor is private. Setter binding ignored", propertyInfo.Name, component.GetType().Name));
				}
			}
		}
	}
}
