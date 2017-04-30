using ParadoxNotion.Serialization;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	public abstract class ReflectedWrapper
	{
		[SerializeField]
		protected SerializedMethodInfo _targetMethod;

		public ReflectedWrapper()
		{
		}

		public static ReflectedWrapper Create(MethodInfo method, IBlackboard bb)
		{
			if (method.ReturnType == typeof(void))
			{
				return ReflectedActionWrapper.Create(method, bb);
			}
			return ReflectedFunctionWrapper.Create(method, bb);
		}

		public void SetVariablesBB(IBlackboard bb)
		{
			BBParameter[] variables = this.GetVariables();
			for (int i = 0; i < variables.Length; i++)
			{
				BBParameter bBParameter = variables[i];
				bBParameter.bb = bb;
			}
		}

		public MethodInfo GetMethod()
		{
			return (this._targetMethod == null) ? null : this._targetMethod.Get();
		}

		public string GetMethodString()
		{
			return (this._targetMethod == null) ? null : this._targetMethod.GetMethodString();
		}

		public abstract BBParameter[] GetVariables();

		public abstract void Init(object instance);
	}
}
