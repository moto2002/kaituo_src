using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ParadoxNotion
{
	public static class ReflectionTools
	{
		private static List<Assembly> _loadedAssemblies;

		private static List<Assembly> loadedAssemblies
		{
			get
			{
				if (ReflectionTools._loadedAssemblies == null)
				{
					ReflectionTools._loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList<Assembly>();
				}
				return ReflectionTools._loadedAssemblies;
			}
		}

		[DebuggerHidden]
		private static IEnumerable GetBaseTypes(Type type)
		{
			ReflectionTools.<GetBaseTypes>c__Iterator35 <GetBaseTypes>c__Iterator = new ReflectionTools.<GetBaseTypes>c__Iterator35();
			<GetBaseTypes>c__Iterator.type = type;
			<GetBaseTypes>c__Iterator.<$>type = type;
			ReflectionTools.<GetBaseTypes>c__Iterator35 expr_15 = <GetBaseTypes>c__Iterator;
			expr_15.$PC = -2;
			return expr_15;
		}

		public static Type GetType(string typeName)
		{
			Type type = Type.GetType(typeName);
			if (type != null)
			{
				return type;
			}
			foreach (Assembly current in ReflectionTools.loadedAssemblies)
			{
				type = current.GetType(typeName);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}

		public static string FriendlyName(this Type t)
		{
			if (t == null)
			{
				return null;
			}
			string text = t.Name;
			text = text.Replace("Single", "Float");
			text = text.Replace("Int32", "Integer");
			if (t.RTIsGenericParameter())
			{
				text = "T";
			}
			if (t.RTIsGenericType())
			{
				Type[] array = t.RTGetGenericArguments();
				if (array.Length != 0)
				{
					text = text.Replace("`" + array.Length.ToString(), string.Empty);
					text += "<";
					for (int i = 0; i < array.Length; i++)
					{
						text = text + ((i != 0) ? ", " : string.Empty) + array[i].FriendlyName();
					}
					text += ">";
				}
			}
			return text;
		}

		public static string SignatureName(this MethodInfo method)
		{
			ParameterInfo[] parameters = method.GetParameters();
			string str = ((!method.IsStatic) ? string.Empty : "static ") + method.Name + " (";
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				str = str + parameterInfo.ParameterType.FriendlyName() + ((i >= parameters.Length - 1) ? string.Empty : ", ");
			}
			return str + ") : " + method.ReturnType.FriendlyName();
		}

		public static Type RTReflectedType(this Type type)
		{
			return type.ReflectedType;
		}

		public static Type RTReflectedType(this MemberInfo member)
		{
			return member.ReflectedType;
		}

		public static bool RTIsAssignableFrom(this Type type, Type second)
		{
			return type.IsAssignableFrom(second);
		}

		public static bool RTIsAbstract(this Type type)
		{
			return type.IsAbstract;
		}

		public static bool RTIsValueType(this Type type)
		{
			return type.IsValueType;
		}

		public static bool RTIsArray(this Type type)
		{
			return type.IsArray;
		}

		public static bool RTIsInterface(this Type type)
		{
			return type.IsInterface;
		}

		public static bool RTIsSubclassOf(this Type type, Type other)
		{
			return type.IsSubclassOf(other);
		}

		public static bool RTIsGenericParameter(this Type type)
		{
			return type.IsGenericParameter;
		}

		public static bool RTIsGenericType(this Type type)
		{
			return type.IsGenericType;
		}

		public static MethodInfo RTGetGetMethod(this PropertyInfo prop)
		{
			return prop.GetGetMethod();
		}

		public static MethodInfo RTGetSetMethod(this PropertyInfo prop)
		{
			return prop.GetSetMethod();
		}

		public static FieldInfo RTGetField(this Type type, string name, bool includePrivate = false)
		{
			if (includePrivate)
			{
				return type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			}
			return type.GetField(name, BindingFlags.Instance | BindingFlags.Public);
		}

		public static PropertyInfo RTGetProperty(this Type type, string name)
		{
			return type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
		}

		public static MethodInfo RTGetMethod(this Type type, string name, bool includePrivate = false)
		{
			if (includePrivate)
			{
				return type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			}
			return type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public);
		}

		public static MethodInfo RTGetMethod(this Type type, string name, Type[] paramTypes)
		{
			return type.GetMethod(name, paramTypes);
		}

		public static EventInfo RTGetEvent(this Type type, string name)
		{
			return type.GetEvent(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		public static FieldInfo[] RTGetFields(this Type type)
		{
			return type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static MethodInfo[] RTGetMethods(this Type type)
		{
			return type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static PropertyInfo[] RTGetProperties(this Type type)
		{
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		public static T RTGetAttribute<T>(this Type type, bool inherited) where T : Attribute
		{
			return (T)((object)type.GetCustomAttributes(typeof(T), inherited).FirstOrDefault<object>());
		}

		public static T RTGetAttribute<T>(this MemberInfo member, bool inherited) where T : Attribute
		{
			return (T)((object)member.GetCustomAttributes(typeof(T), inherited).FirstOrDefault<object>());
		}

		public static Type RTMakeGenericType(this Type type, Type[] typeArgs)
		{
			return type.MakeGenericType(typeArgs);
		}

		public static Type[] RTGetGenericArguments(this Type type)
		{
			return type.GetGenericArguments();
		}

		public static Type[] RTGetEmptyTypes()
		{
			return Type.EmptyTypes;
		}

		public static T RTCreateDelegate<T>(this MethodInfo method, object instance)
		{
			return (T)((object)method.RTCreateDelegate(typeof(T), instance));
		}

		public static Delegate RTCreateDelegate(this MethodInfo method, Type type, object instance)
		{
			return Delegate.CreateDelegate(type, instance, method);
		}
	}
}
