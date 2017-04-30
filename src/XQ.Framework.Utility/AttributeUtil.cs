using Assets.Tools.Script.Reflec;
using System;
using System.Reflection;

namespace XQ.Framework.Utility
{
	public class AttributeUtil
	{
		public static void GetEnumAttribute<T>(Type enumType, Action<T, object> callback) where T : Attribute
		{
			FieldInfo[] fields = enumType.GetFields();
			FieldInfo[] array = fields;
			for (int i = 0; i < array.Length; i++)
			{
				FieldInfo fieldInfo = array[i];
				if (fieldInfo.IsDefined(typeof(T), false))
				{
					callback((T)((object)fieldInfo.GetAttribute(typeof(T))), fieldInfo.GetValue(null));
				}
			}
		}
	}
}
