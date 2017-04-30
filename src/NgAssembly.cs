using System;
using System.Reflection;
using UnityEngine;

public class NgAssembly
{
	public static BindingFlags m_bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	public static T GetReference<T>(object inObj, string fieldName) where T : class
	{
		return NgAssembly.GetField(inObj, fieldName) as T;
	}

	public static T GetValue<T>(object inObj, string fieldName) where T : struct
	{
		return (T)((object)NgAssembly.GetField(inObj, fieldName));
	}

	public static void SetField(object inObj, string fieldName, object newValue)
	{
		FieldInfo field = inObj.GetType().GetField(fieldName);
		if (field != null)
		{
			field.SetValue(inObj, newValue);
		}
	}

	private static object GetField(object inObj, string fieldName)
	{
		object result = null;
		FieldInfo field = inObj.GetType().GetField(fieldName);
		if (field != null)
		{
			result = field.GetValue(inObj);
		}
		return result;
	}

	public static void SetProperty(object srcObj, string fieldName, object newValue)
	{
		PropertyInfo property = srcObj.GetType().GetProperty(fieldName, NgAssembly.m_bindingAttr);
		if (property != null && property.CanWrite)
		{
			property.SetValue(srcObj, newValue, null);
		}
		else
		{
			Debug.LogWarning(fieldName + " could not be write.");
		}
	}

	public static object GetProperty(object srcObj, string fieldName)
	{
		object result = null;
		PropertyInfo property = srcObj.GetType().GetProperty(fieldName, NgAssembly.m_bindingAttr);
		if (property != null && property.CanRead && property.GetIndexParameters().Length == 0)
		{
			result = property.GetValue(srcObj, null);
		}
		else
		{
			Debug.LogWarning(fieldName + " could not be read.");
		}
		return result;
	}

	public static void LogFieldsPropertis(UnityEngine.Object srcObj)
	{
		if (srcObj == null)
		{
			return;
		}
		string text = "=====================================================================\r\n";
		FieldInfo[] fields = srcObj.GetType().GetFields(NgAssembly.m_bindingAttr);
		FieldInfo[] array = fields;
		for (int i = 0; i < array.Length; i++)
		{
			FieldInfo fieldInfo = array[i];
			text += string.Format("{0}   {1,-30}\r\n", fieldInfo.Name, fieldInfo.GetValue(srcObj).ToString());
		}
		Debug.Log(text);
		text = string.Empty;
		PropertyInfo[] properties = srcObj.GetType().GetProperties(NgAssembly.m_bindingAttr);
		PropertyInfo[] array2 = properties;
		for (int j = 0; j < array2.Length; j++)
		{
			PropertyInfo propertyInfo = array2[j];
			if (propertyInfo.CanRead && propertyInfo.GetIndexParameters().Length == 0)
			{
				text += string.Format("{0,-10}{1,-30}   {2,-30}\r\n", propertyInfo.CanWrite, propertyInfo.Name, propertyInfo.GetValue(srcObj, null).ToString());
			}
		}
		text += "=====================================================================\r\n";
		Debug.Log(text);
	}
}
