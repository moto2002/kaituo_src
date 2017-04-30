using System;
using System.Collections.Generic;
using System.Reflection;

namespace FullSerializer.Internal
{
	public static class fsTypeCache
	{
		private static Dictionary<string, Type> _cachedTypes;

		private static Dictionary<string, Assembly> _assembliesByName;

		private static List<Assembly> _assembliesByIndex;

		static fsTypeCache()
		{
			fsTypeCache._cachedTypes = new Dictionary<string, Type>();
			fsTypeCache._assembliesByName = new Dictionary<string, Assembly>();
			fsTypeCache._assembliesByIndex = new List<Assembly>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Assembly assembly = assemblies[i];
				fsTypeCache._assembliesByName[assembly.FullName] = assembly;
				fsTypeCache._assembliesByIndex.Add(assembly);
			}
			fsTypeCache._cachedTypes = new Dictionary<string, Type>();
			AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(fsTypeCache.OnAssemblyLoaded);
		}

		private static void OnAssemblyLoaded(object sender, AssemblyLoadEventArgs args)
		{
			fsTypeCache._assembliesByName[args.LoadedAssembly.FullName] = args.LoadedAssembly;
			fsTypeCache._assembliesByIndex.Add(args.LoadedAssembly);
			fsTypeCache._cachedTypes = new Dictionary<string, Type>();
		}

		private static bool TryDirectTypeLookup(string assemblyName, string typeName, out Type type)
		{
			Assembly assembly;
			if (assemblyName != null && fsTypeCache._assembliesByName.TryGetValue(assemblyName, out assembly))
			{
				type = assembly.GetType(typeName, false);
				return type != null;
			}
			type = null;
			return false;
		}

		private static bool TryIndirectTypeLookup(string typeName, out Type type)
		{
			for (int i = 0; i < fsTypeCache._assembliesByIndex.Count; i++)
			{
				Assembly assembly = fsTypeCache._assembliesByIndex[i];
				type = assembly.GetType(typeName);
				if (type != null)
				{
					return true;
				}
				Type[] types = assembly.GetTypes();
				for (int j = 0; j < types.Length; j++)
				{
					Type type2 = types[j];
					if (type2.FullName == typeName)
					{
						type = type2;
						return true;
					}
				}
			}
			type = null;
			return false;
		}

		public static void Reset()
		{
			fsTypeCache._cachedTypes = new Dictionary<string, Type>();
		}

		public static Type GetType(string name)
		{
			return fsTypeCache.GetType(name, null);
		}

		public static Type GetType(string name, string assemblyHint)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			Type type;
			if (!fsTypeCache._cachedTypes.TryGetValue(name, out type))
			{
				if (fsTypeCache.TryDirectTypeLookup(assemblyHint, name, out type) || !fsTypeCache.TryIndirectTypeLookup(name, out type))
				{
				}
				fsTypeCache._cachedTypes[name] = type;
			}
			return type;
		}
	}
}
