using ParadoxNotion;
using ParadoxNotion.Serialization;
using System;
using System.Linq;
using System.Reflection;

namespace NodeCanvas.Framework.Internal
{
	public abstract class ReflectedActionWrapper : ReflectedWrapper
	{
		public new static ReflectedActionWrapper Create(MethodInfo method, IBlackboard bb)
		{
			Type type = null;
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length == 0)
			{
				type = typeof(ReflectedAction);
			}
			if (parameters.Length == 1)
			{
				type = typeof(ReflectedAction<>);
			}
			if (parameters.Length == 2)
			{
				type = typeof(ReflectedAction<, >);
			}
			if (parameters.Length == 3)
			{
				type = typeof(ReflectedAction<, , >);
			}
			Type[] array = (from p in parameters
			select p.ParameterType).ToArray<Type>();
			ReflectedActionWrapper reflectedActionWrapper = (ReflectedActionWrapper)Activator.CreateInstance((array.Length <= 0) ? type : type.RTMakeGenericType(array));
			reflectedActionWrapper._targetMethod = new SerializedMethodInfo(method);
			BBParameter.SetBBFields(reflectedActionWrapper, bb);
			BBParameter[] variables = reflectedActionWrapper.GetVariables();
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				if (parameterInfo.IsOptional)
				{
					variables[i].value = parameterInfo.DefaultValue;
				}
			}
			return reflectedActionWrapper;
		}

		public abstract void Call();
	}
}
