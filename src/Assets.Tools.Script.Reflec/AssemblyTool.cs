using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assets.Tools.Script.Reflec
{
	public static class AssemblyTool
	{
		public static void ForeachCurrentDomainType(Action<Type> execute)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Assembly assembly = assemblies[i];
				Type[] types = assembly.GetTypes();
				for (int j = 0; j < types.Length; j++)
				{
					Type obj = types[j];
					execute(obj);
				}
			}
		}

		public static List<Type> FindTypesInCurrentDomainWhere(Func<Type, bool> condition)
		{
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Assembly assembly = assemblies[i];
				Type[] types = assembly.GetTypes();
				for (int j = 0; j < types.Length; j++)
				{
					Type type = types[j];
					if (condition(type))
					{
						list.Add(type);
					}
				}
			}
			return list;
		}

		public static Type FindTypesInCurrentDomainByName(string ClassName)
		{
			List<Type> list = AssemblyTool.FindTypesInCurrentDomainWhere((Type e) => e.Name == ClassName);
			if (list.Count > 0)
			{
				return list[0];
			}
			return null;
		}

		public static List<Type> FindTypesInCurrentDomainWhereAttributeIs<T>()
		{
			Type withType = typeof(T);
			return AssemblyTool.FindTypesInCurrentDomainWhere((Type type) => type.GetCustomAttributes(withType, true).Length > 0);
		}

		public static List<Type> FindTypesInCurrentDomainWhereExtend<T>()
		{
			Type typeFromHandle = typeof(T);
			return AssemblyTool.FindTypesInCurrentDomainWhere((Type type) => typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
		}

		public static List<Type> FindTypesInCurrentDomainWhereExtend(Type withType)
		{
			return AssemblyTool.FindTypesInCurrentDomainWhere((Type type) => withType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
		}
	}
}
