using System;
using System.Reflection;

namespace Assets.Scripts.Test
{
	public class TestService
	{
		public static string PxsLoginResponse;

		static TestService()
		{
		}

		private static void InstantiateAllField(object obj)
		{
			if (obj == null)
			{
				return;
			}
			Type type = obj.GetType();
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			FieldInfo[] array = fields;
			for (int i = 0; i < array.Length; i++)
			{
				FieldInfo fieldInfo = array[i];
				if (fieldInfo.FieldType.IsValueType)
				{
					object obj2 = Activator.CreateInstance(fieldInfo.FieldType);
					TestService.InstantiateAllField(obj2);
					fieldInfo.SetValue(obj, obj2);
				}
				else if (fieldInfo.FieldType == typeof(string))
				{
					fieldInfo.SetValue(obj, string.Empty);
				}
				else
				{
					object obj3 = Activator.CreateInstance(fieldInfo.FieldType);
					TestService.InstantiateAllField(obj3);
					fieldInfo.SetValue(obj, obj3);
				}
			}
		}
	}
}
