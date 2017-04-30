using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace FullSerializer.Internal
{
	public static class fsPortableReflection
	{
		private struct AttributeQuery
		{
			public MemberInfo MemberInfo;

			public Type AttributeType;
		}

		private class AttributeQueryComparator : IEqualityComparer<fsPortableReflection.AttributeQuery>
		{
			public bool Equals(fsPortableReflection.AttributeQuery x, fsPortableReflection.AttributeQuery y)
			{
				return x.MemberInfo == y.MemberInfo && x.AttributeType == y.AttributeType;
			}

			public int GetHashCode(fsPortableReflection.AttributeQuery obj)
			{
				return obj.MemberInfo.GetHashCode() + 17 * obj.AttributeType.GetHashCode();
			}
		}

		public static Type[] EmptyTypes = new Type[0];

		private static IDictionary<fsPortableReflection.AttributeQuery, Attribute> _cachedAttributeQueries = new Dictionary<fsPortableReflection.AttributeQuery, Attribute>(new fsPortableReflection.AttributeQueryComparator());

		private static BindingFlags DeclaredFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		public static bool HasAttribute<TAttribute>(MemberInfo element)
		{
			return fsPortableReflection.HasAttribute(element, typeof(TAttribute));
		}

		public static bool HasAttribute<TAttribute>(MemberInfo element, bool shouldCache)
		{
			return fsPortableReflection.HasAttribute(element, typeof(TAttribute), shouldCache);
		}

		public static bool HasAttribute(MemberInfo element, Type attributeType)
		{
			return fsPortableReflection.HasAttribute(element, attributeType, true);
		}

		public static bool HasAttribute(MemberInfo element, Type attributeType, bool shouldCache)
		{
			return element.IsDefined(attributeType, true);
		}

		public static Attribute GetAttribute(MemberInfo element, Type attributeType, bool shouldCache)
		{
			fsPortableReflection.AttributeQuery key = new fsPortableReflection.AttributeQuery
			{
				MemberInfo = element,
				AttributeType = attributeType
			};
			Attribute attribute;
			if (!fsPortableReflection._cachedAttributeQueries.TryGetValue(key, out attribute))
			{
				object[] customAttributes = element.GetCustomAttributes(attributeType, true);
				if (customAttributes.Length > 0)
				{
					attribute = (Attribute)customAttributes[0];
				}
				if (shouldCache)
				{
					fsPortableReflection._cachedAttributeQueries[key] = attribute;
				}
			}
			return attribute;
		}

		public static TAttribute GetAttribute<TAttribute>(MemberInfo element, bool shouldCache) where TAttribute : Attribute
		{
			return (TAttribute)((object)fsPortableReflection.GetAttribute(element, typeof(TAttribute), shouldCache));
		}

		public static TAttribute GetAttribute<TAttribute>(MemberInfo element) where TAttribute : Attribute
		{
			return fsPortableReflection.GetAttribute<TAttribute>(element, true);
		}

		public static PropertyInfo GetDeclaredProperty(this Type type, string propertyName)
		{
			PropertyInfo[] declaredProperties = type.GetDeclaredProperties();
			for (int i = 0; i < declaredProperties.Length; i++)
			{
				if (declaredProperties[i].Name == propertyName)
				{
					return declaredProperties[i];
				}
			}
			return null;
		}

		public static MethodInfo GetDeclaredMethod(this Type type, string methodName)
		{
			MethodInfo[] declaredMethods = type.GetDeclaredMethods();
			for (int i = 0; i < declaredMethods.Length; i++)
			{
				if (declaredMethods[i].Name == methodName)
				{
					return declaredMethods[i];
				}
			}
			return null;
		}

		public static ConstructorInfo GetDeclaredConstructor(this Type type, Type[] parameters)
		{
			ConstructorInfo[] declaredConstructors = type.GetDeclaredConstructors();
			for (int i = 0; i < declaredConstructors.Length; i++)
			{
				ConstructorInfo constructorInfo = declaredConstructors[i];
				ParameterInfo[] parameters2 = constructorInfo.GetParameters();
				if (parameters.Length == parameters2.Length)
				{
					for (int j = 0; j < parameters2.Length; j++)
					{
						if (parameters2[j].ParameterType != parameters[j])
						{
						}
					}
					return constructorInfo;
				}
			}
			return null;
		}

		public static ConstructorInfo[] GetDeclaredConstructors(this Type type)
		{
			return type.GetConstructors(fsPortableReflection.DeclaredFlags);
		}

		public static MemberInfo[] GetFlattenedMember(this Type type, string memberName)
		{
			List<MemberInfo> list = new List<MemberInfo>();
			while (type != null)
			{
				MemberInfo[] declaredMembers = type.GetDeclaredMembers();
				for (int i = 0; i < declaredMembers.Length; i++)
				{
					if (declaredMembers[i].Name == memberName)
					{
						list.Add(declaredMembers[i]);
					}
				}
				type = type.Resolve().BaseType;
			}
			return list.ToArray();
		}

		public static MethodInfo GetFlattenedMethod(this Type type, string methodName)
		{
			while (type != null)
			{
				MethodInfo[] declaredMethods = type.GetDeclaredMethods();
				for (int i = 0; i < declaredMethods.Length; i++)
				{
					if (declaredMethods[i].Name == methodName)
					{
						return declaredMethods[i];
					}
				}
				type = type.Resolve().BaseType;
			}
			return null;
		}

		[DebuggerHidden]
		public static IEnumerable<MethodInfo> GetFlattenedMethods(this Type type, string methodName)
		{
			fsPortableReflection.<GetFlattenedMethods>c__Iterator34 <GetFlattenedMethods>c__Iterator = new fsPortableReflection.<GetFlattenedMethods>c__Iterator34();
			<GetFlattenedMethods>c__Iterator.type = type;
			<GetFlattenedMethods>c__Iterator.methodName = methodName;
			<GetFlattenedMethods>c__Iterator.<$>type = type;
			<GetFlattenedMethods>c__Iterator.<$>methodName = methodName;
			fsPortableReflection.<GetFlattenedMethods>c__Iterator34 expr_23 = <GetFlattenedMethods>c__Iterator;
			expr_23.$PC = -2;
			return expr_23;
		}

		public static PropertyInfo GetFlattenedProperty(this Type type, string propertyName)
		{
			while (type != null)
			{
				PropertyInfo[] declaredProperties = type.GetDeclaredProperties();
				for (int i = 0; i < declaredProperties.Length; i++)
				{
					if (declaredProperties[i].Name == propertyName)
					{
						return declaredProperties[i];
					}
				}
				type = type.Resolve().BaseType;
			}
			return null;
		}

		public static MemberInfo GetDeclaredMember(this Type type, string memberName)
		{
			MemberInfo[] declaredMembers = type.GetDeclaredMembers();
			for (int i = 0; i < declaredMembers.Length; i++)
			{
				if (declaredMembers[i].Name == memberName)
				{
					return declaredMembers[i];
				}
			}
			return null;
		}

		public static MethodInfo[] GetDeclaredMethods(this Type type)
		{
			return type.GetMethods(fsPortableReflection.DeclaredFlags);
		}

		public static PropertyInfo[] GetDeclaredProperties(this Type type)
		{
			return type.GetProperties(fsPortableReflection.DeclaredFlags);
		}

		public static FieldInfo[] GetDeclaredFields(this Type type)
		{
			return type.GetFields(fsPortableReflection.DeclaredFlags);
		}

		public static MemberInfo[] GetDeclaredMembers(this Type type)
		{
			return type.GetMembers(fsPortableReflection.DeclaredFlags);
		}

		public static MemberInfo AsMemberInfo(Type type)
		{
			return type;
		}

		public static bool IsType(MemberInfo member)
		{
			return member is Type;
		}

		public static Type AsType(MemberInfo member)
		{
			return (Type)member;
		}

		public static Type Resolve(this Type type)
		{
			return type;
		}
	}
}
