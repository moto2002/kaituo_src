using System;
using System.Collections.Generic;
using System.Linq;

namespace FullSerializer
{
	public static class fsTypeExtensions
	{
		public static string CSharpName(this Type type)
		{
			return type.CSharpName(false);
		}

		public static string CSharpName(this Type type, bool includeNamespace, bool ensureSafeDeclarationName)
		{
			string text = type.CSharpName(includeNamespace);
			if (ensureSafeDeclarationName)
			{
				text = text.Replace('>', '_').Replace('<', '_').Replace('.', '_');
			}
			return text;
		}

		public static string CSharpName(this Type type, bool includeNamespace)
		{
			if (type == typeof(void))
			{
				return "void";
			}
			if (type == typeof(int))
			{
				return "int";
			}
			if (type == typeof(float))
			{
				return "float";
			}
			if (type == typeof(bool))
			{
				return "bool";
			}
			if (type == typeof(double))
			{
				return "double";
			}
			if (type == typeof(string))
			{
				return "string";
			}
			if (type.IsGenericParameter)
			{
				return type.ToString();
			}
			string text = string.Empty;
			IEnumerable<Type> source = type.GetGenericArguments();
			if (type.IsNested)
			{
				text = text + type.DeclaringType.CSharpName() + ".";
				if (type.DeclaringType.GetGenericArguments().Length > 0)
				{
					source = source.Skip(type.DeclaringType.GetGenericArguments().Length);
				}
			}
			if (!source.Any<Type>())
			{
				text += type.Name;
			}
			else
			{
				text += type.Name.Substring(0, type.Name.IndexOf('`'));
				text = text + "<" + string.Join(",", (from t in source
				select t.CSharpName(includeNamespace)).ToArray<string>()) + ">";
			}
			if (includeNamespace && type.Namespace != null)
			{
				text = type.Namespace + "." + text;
			}
			return text;
		}
	}
}
