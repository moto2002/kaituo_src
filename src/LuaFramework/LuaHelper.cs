using LuaInterface;
using System;
using System.Reflection;
using UnityEngine;

namespace LuaFramework
{
	public static class LuaHelper
	{
		public static Type GetType(string classname)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType(classname);
			if (type == null)
			{
				type = executingAssembly.GetType(classname);
			}
			return type;
		}

		public static Action Action(LuaFunction func)
		{
			return new Action(func.Call);
		}

		public static UIEventListener.VoidDelegate VoidDelegate(LuaFunction func)
		{
			return delegate(GameObject go)
			{
				func.CallNoRet(new object[]
				{
					go
				});
			};
		}

		public static void OnCallLuaFunc(LuaByteBuffer data, LuaFunction func)
		{
			if (func != null)
			{
				func.CallNoRet(new object[]
				{
					data
				});
			}
			Debug.LogWarning("OnCallLuaFunc length:>>" + data.buffer.Length);
		}

		public static void OnJsonCallFunc(string data, LuaFunction func)
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"OnJsonCallback data:>>",
				data,
				" lenght:>>",
				data.Length
			}));
			if (func != null)
			{
				func.CallNoRet(new object[]
				{
					data
				});
			}
		}
	}
}
