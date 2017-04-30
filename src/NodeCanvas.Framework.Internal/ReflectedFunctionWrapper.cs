using ParadoxNotion;
using ParadoxNotion.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NodeCanvas.Framework.Internal
{
	public abstract class ReflectedFunctionWrapper : ReflectedWrapper
	{
		public new static ReflectedFunctionWrapper Create(MethodInfo method, IBlackboard bb)
		{
			Type type = null;
			List<Type> list = new List<Type>
			{
				method.ReturnType
			};
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length == 0)
			{
				type = typeof(ReflectedFunction<>);
			}
			if (parameters.Length == 1)
			{
				type = typeof(ReflectedFunction<, >);
			}
			if (parameters.Length == 2)
			{
				type = typeof(ReflectedFunction<, , >);
			}
			if (parameters.Length == 3)
			{
				type = typeof(ReflectedFunction<, , , >);
			}
			list.AddRange(from p in parameters
			select p.ParameterType);
			ReflectedFunctionWrapper reflectedFunctionWrapper = (ReflectedFunctionWrapper)Activator.CreateInstance(type.RTMakeGenericType(list.ToArray()));
			reflectedFunctionWrapper._targetMethod = new SerializedMethodInfo(method);
			BBParameter.SetBBFields(reflectedFunctionWrapper, bb);
			BBParameter[] variables = reflectedFunctionWrapper.GetVariables();
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				if (parameterInfo.IsOptional)
				{
					variables[i + 1].value = parameterInfo.DefaultValue;
				}
			}
			return reflectedFunctionWrapper;
		}

		public abstract object Call();
	}
}
