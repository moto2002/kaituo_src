using Assets.Tools.Script.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Tools.Script.Reflec
{
	public static class ReflecTool
	{
		public static List<FieldInfo> GetPublicFields(this Type type, Type withAttribute = null)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			if (withAttribute != null)
			{
				List<FieldInfo> list = new List<FieldInfo>();
				FieldInfo[] array = fields;
				for (int i = 0; i < array.Length; i++)
				{
					FieldInfo fieldInfo = array[i];
					if (fieldInfo.HasAttribute(withAttribute))
					{
						list.Add(fieldInfo);
					}
				}
				return list;
			}
			return fields.ToList<FieldInfo>();
		}

		public static List<FieldInfo> GetPrivateFields(this Type type, Type withAttribute = null)
		{
			List<Type> baseClassTypes = type.GetBaseClassTypes(true);
			List<FieldInfo> list = new List<FieldInfo>();
			foreach (Type current in baseClassTypes)
			{
				FieldInfo[] fields = current.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
				if (withAttribute != null)
				{
					FieldInfo[] array = fields;
					for (int i = 0; i < array.Length; i++)
					{
						FieldInfo fieldInfo = array[i];
						if (fieldInfo.HasAttribute(withAttribute))
						{
							list.Add(fieldInfo);
						}
					}
				}
				else
				{
					list.AddRange(fields.ToList<FieldInfo>());
				}
			}
			return list;
		}

		public static List<Type> GetBaseClassTypes(this Type type, bool includeSelf = false)
		{
			List<Type> list = new List<Type>();
			if (includeSelf)
			{
				list.Add(type);
			}
			for (type = type.BaseType; type != typeof(object); type = type.BaseType)
			{
				list.Add(type);
			}
			return list;
		}

		public static bool HasAttribute<T>(this FieldInfo field) where T : class
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(T), true);
			return customAttributes.Length > 0;
		}

		public static T GetAttribute<T>(this FieldInfo field) where T : class
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(T), true);
			return (customAttributes.Length <= 0) ? ((T)((object)null)) : (customAttributes[0] as T);
		}

		public static bool HasAttribute<T>(this Type type) where T : class
		{
			object[] customAttributes = type.GetCustomAttributes(typeof(T), true);
			return customAttributes.Length > 0;
		}

		public static T GetAttribute<T>(this MemberInfo field) where T : class
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(T), true);
			return (customAttributes.Length <= 0) ? ((T)((object)null)) : (customAttributes[0] as T);
		}

		public static T GetAttribute<T>(this Type type) where T : class
		{
			object[] customAttributes = type.GetCustomAttributes(typeof(T), true);
			return (customAttributes.Length <= 0) ? ((T)((object)null)) : (customAttributes[0] as T);
		}

		public static bool HasAttribute(this FieldInfo field, Type attribute)
		{
			object[] customAttributes = field.GetCustomAttributes(attribute, true);
			return customAttributes.Length > 0;
		}

		public static Attribute GetAttribute(this FieldInfo field, Type attribute)
		{
			object[] customAttributes = field.GetCustomAttributes(attribute, true);
			return (customAttributes.Length <= 0) ? null : (customAttributes[0] as Attribute);
		}

		public static bool HasAttribute(this Type type, Type attribute)
		{
			object[] customAttributes = type.GetCustomAttributes(attribute, true);
			return customAttributes.Length > 0;
		}

		public static Attribute GetAttribute(this Type type, Type attribute)
		{
			object[] customAttributes = type.GetCustomAttributes(attribute, true);
			return (customAttributes.Length <= 0) ? null : (customAttributes[0] as Attribute);
		}

		public static T Instantiate<T>() where T : class
		{
			Type typeFromHandle = typeof(T);
			ConstructorInfo constructor = typeFromHandle.GetConstructor(Type.EmptyTypes);
			return constructor.Invoke(null) as T;
		}

		public static T Instantiate<T>(Type[] parameterTypes, object[] parameters) where T : class
		{
			Type typeFromHandle = typeof(T);
			ConstructorInfo constructor = typeFromHandle.GetConstructor(parameterTypes);
			return constructor.Invoke(parameters) as T;
		}

		public static object Instantiate(Type type)
		{
			try
			{
				ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
				return constructor.Invoke(null);
			}
			catch (Exception)
			{
				Debug.Log(type);
			}
			return null;
		}

		public static object Instantiate(Type type, Type[] parameterTypes, object[] parameters)
		{
			ConstructorInfo constructor = type.GetConstructor(parameterTypes);
			return constructor.Invoke(parameters);
		}

		public static List<T> Instantiate<T>(List<Type> types) where T : class
		{
			List<T> list = new List<T>();
			foreach (Type current in types)
			{
				list.Add(ReflecTool.Instantiate(current) as T);
			}
			return list;
		}

		public static string GetBestName(this FieldInfo field)
		{
			InspectorStyle attribute = field.GetAttribute<InspectorStyle>();
			if (attribute != null)
			{
				return attribute.Name;
			}
			return field.Name;
		}

		public static string GetBestName(this Type type)
		{
			InspectorStyle attribute = type.GetAttribute<InspectorStyle>();
			if (attribute != null)
			{
				return attribute.Name;
			}
			return type.Name;
		}

		public static MemberInfo GetFieldInfoOrPropertyInfo(object targetObj, string field)
		{
			Type type = targetObj.GetType();
			FieldInfo field2 = type.GetField(field);
			if (field2 != null)
			{
				return field2;
			}
			PropertyInfo property = type.GetProperty(field);
			if (property != null)
			{
				return property;
			}
			property = type.GetProperty(field, BindingFlags.Instance | BindingFlags.NonPublic);
			if (property != null)
			{
				return property;
			}
			field2 = type.GetField(field, BindingFlags.Instance | BindingFlags.NonPublic);
			if (field2 != null)
			{
				return field2;
			}
			throw new Exception("can't find field");
		}

		public static object GetFieldValue(object targetObj, object fieldInfoOrPropertyInfo)
		{
			if (fieldInfoOrPropertyInfo is FieldInfo)
			{
				FieldInfo fieldInfo = fieldInfoOrPropertyInfo as FieldInfo;
				return fieldInfo.GetValue(targetObj);
			}
			PropertyInfo propertyInfo = fieldInfoOrPropertyInfo as PropertyInfo;
			return propertyInfo.GetValue(targetObj, null);
		}

		public static Type GetFieldType(object fieldInfoOrPropertyInfo)
		{
			if (fieldInfoOrPropertyInfo is FieldInfo)
			{
				FieldInfo fieldInfo = fieldInfoOrPropertyInfo as FieldInfo;
				return fieldInfo.FieldType;
			}
			PropertyInfo propertyInfo = fieldInfoOrPropertyInfo as PropertyInfo;
			return propertyInfo.PropertyType;
		}

		public static string GetFieldName(object fieldInfoOrPropertyInfo)
		{
			if (fieldInfoOrPropertyInfo is FieldInfo)
			{
				FieldInfo fieldInfo = fieldInfoOrPropertyInfo as FieldInfo;
				return fieldInfo.Name;
			}
			PropertyInfo propertyInfo = fieldInfoOrPropertyInfo as PropertyInfo;
			return propertyInfo.Name;
		}

		public static void SetFieldValue(object targetObj, object fieldInfoOrPropertyInfo, object toValue)
		{
			if (fieldInfoOrPropertyInfo is FieldInfo)
			{
				FieldInfo fieldInfo = fieldInfoOrPropertyInfo as FieldInfo;
				fieldInfo.SetValue(targetObj, toValue);
			}
			else
			{
				PropertyInfo propertyInfo = fieldInfoOrPropertyInfo as PropertyInfo;
				propertyInfo.SetValue(targetObj, toValue, null);
			}
		}

		public static object GetPrivateProperty(object instance, string propname)
		{
			Type type = instance.GetType();
			PropertyInfo property = type.GetProperty(propname);
			return property.GetValue(instance, null);
		}

		public static object InvokeMethod(object instance, string methodName, object[] param, BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
		{
			MethodInfo method = instance.GetType().GetMethod(methodName, flags);
			if (method == null)
			{
				return null;
			}
			return method.Invoke(instance, param);
		}

		public static object InvokeMethod(Type type, object instance, string methodName, object[] param, BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
		{
			MethodInfo method = type.GetMethod(methodName, flags);
			if (method == null)
			{
				return null;
			}
			return method.Invoke(instance, param);
		}

		public static T GetPrivateField<T>(object instance, string fieldname, BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic)
		{
			Type type = instance.GetType();
			FieldInfo field = type.GetField(fieldname, flags);
			if (field == null)
			{
				return default(T);
			}
			return (T)((object)field.GetValue(instance));
		}

		public static void SetPrivateFiled(object instance, string fieldname, object value, BindingFlags flag = BindingFlags.Default)
		{
			Type type = instance.GetType();
			FieldInfo field = type.GetField(fieldname, flag);
			field.SetValue(instance, value);
		}

		public static List<MemberInfo> GetAllFieldOrProperty<T>(object instance, BindingFlags flag = BindingFlags.Instance)
		{
			List<MemberInfo> list = new List<MemberInfo>();
			Type type = instance.GetType();
			PropertyInfo[] properties = type.GetProperties(flag);
			FieldInfo[] fields = type.GetFields(flag);
			PropertyInfo[] array = properties;
			for (int i = 0; i < array.Length; i++)
			{
				PropertyInfo propertyInfo = array[i];
				object value = propertyInfo.GetValue(instance, null);
				if (value is T)
				{
					list.Add(propertyInfo);
				}
			}
			FieldInfo[] array2 = fields;
			for (int j = 0; j < array2.Length; j++)
			{
				FieldInfo fieldInfo = array2[j];
				object value2 = fieldInfo.GetValue(instance);
				if (value2 is T)
				{
					list.Add(fieldInfo);
				}
			}
			return list;
		}

		public static List<MemberInfo> GetAllFieldOrPropertyWhere<T>(object instance, Func<MemberInfo, bool> where, BindingFlags flag = BindingFlags.Instance)
		{
			List<MemberInfo> list = new List<MemberInfo>();
			Type type = instance.GetType();
			PropertyInfo[] properties = type.GetProperties(flag);
			FieldInfo[] fields = type.GetFields(flag);
			PropertyInfo[] array = properties;
			for (int i = 0; i < array.Length; i++)
			{
				PropertyInfo propertyInfo = array[i];
				object value = propertyInfo.GetValue(instance, null);
				if (value is T && where(propertyInfo))
				{
					list.Add(propertyInfo);
				}
			}
			FieldInfo[] array2 = fields;
			for (int j = 0; j < array2.Length; j++)
			{
				FieldInfo fieldInfo = array2[j];
				object value2 = fieldInfo.GetValue(instance);
				if (value2 is T && where(fieldInfo))
				{
					list.Add(fieldInfo);
				}
			}
			return list;
		}

		public static bool CheckEmptyConstructor(Type t)
		{
			ConstructorInfo[] constructors = t.GetConstructors();
			ConstructorInfo[] array = constructors;
			for (int i = 0; i < array.Length; i++)
			{
				ConstructorInfo constructorInfo = array[i];
				if (constructorInfo.GetParameters().Length == 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
