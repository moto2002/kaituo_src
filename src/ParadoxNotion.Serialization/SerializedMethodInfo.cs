using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public class SerializedMethodInfo
	{
		[SerializeField]
		private string _baseInfo;

		[SerializeField]
		private string _paramsInfo;

		private MethodInfo _method;

		public SerializedMethodInfo()
		{
		}

		public SerializedMethodInfo(MethodInfo method)
		{
			this._baseInfo = string.Format("{0}|{1}", method.RTReflectedType().FullName, method.Name);
			this._paramsInfo = string.Join("|", (from p in method.GetParameters()
			select p.ParameterType.FullName).ToArray<string>());
		}

		public MethodInfo Get()
		{
			if (this._method == null && !string.IsNullOrEmpty(this._baseInfo))
			{
				Type type = ReflectionTools.GetType(this._baseInfo.Split(new char[]
				{
					'|'
				})[0]);
				if (type == null)
				{
					return null;
				}
				string name = this._baseInfo.Split(new char[]
				{
					'|'
				})[1];
				string[] array = (!string.IsNullOrEmpty(this._paramsInfo)) ? this._paramsInfo.Split(new char[]
				{
					'|'
				}) : null;
				Type[] arg_C0_0;
				if (array == null)
				{
					arg_C0_0 = new Type[0];
				}
				else
				{
					arg_C0_0 = (from n in array
					select ReflectionTools.GetType(n)).ToArray<Type>();
				}
				Type[] paramTypes = arg_C0_0;
				this._method = type.RTGetMethod(name, paramTypes);
			}
			return this._method;
		}

		public string GetMethodString()
		{
			return string.Format("{0} ({1})", this._baseInfo.Replace("|", "."), this._paramsInfo.Replace("|", ", "));
		}
	}
}
