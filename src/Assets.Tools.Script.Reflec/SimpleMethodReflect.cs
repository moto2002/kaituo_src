using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Assets.Tools.Script.Reflec
{
	public class SimpleMethodReflect
	{
		public List<string> parameters = new List<string>();

		public MethodInfo method
		{
			get;
			private set;
		}

		public object methodObject
		{
			get;
			private set;
		}

		public SimpleMethodReflect(MethodInfo method, object methodObject)
		{
			this.methodObject = methodObject;
			this.method = method;
			ParameterInfo[] array = this.method.GetParameters();
			Type[] genericArguments = method.GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				Type type = genericArguments[i];
				this.parameters.Add("template " + type.Name);
			}
			ParameterInfo[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				ParameterInfo parameterInfo = array2[j];
				this.parameters.Add(parameterInfo.ParameterType.Name + " " + parameterInfo.Name);
			}
		}

		public static bool IsSimpleMethod(MethodInfo info, object obj)
		{
			ParameterInfo[] array = info.GetParameters();
			ParameterInfo[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				ParameterInfo parameterInfo = array2[i];
				Type parameterType = parameterInfo.ParameterType;
				if (!parameterType.IsValueType && parameterType != typeof(string) && parameterType != typeof(string) && !parameterType.IsEnum)
				{
					return false;
				}
			}
			return true;
		}

		public static object Format(string str, Type type)
		{
			if (string.IsNullOrEmpty(str))
			{
				return null;
			}
			if (type == null)
			{
				return str;
			}
			if (type.IsArray)
			{
				Type elementType = type.GetElementType();
				string[] array = str.Split(new char[]
				{
					';'
				});
				Array array2 = Array.CreateInstance(elementType, array.Length);
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					array2.SetValue(SimpleMethodReflect.ConvertSimpleType(array[i], elementType), i);
					i++;
				}
				return array2;
			}
			if (type == typeof(Type))
			{
				return Type.GetType(str);
			}
			return SimpleMethodReflect.ConvertSimpleType(str, type);
		}

		private static object ConvertSimpleType(object value, Type destinationType)
		{
			if (value == null || destinationType.IsInstanceOfType(value))
			{
				return value;
			}
			string text = value as string;
			if (text != null && text.Length == 0)
			{
				return null;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
			bool flag = converter.CanConvertFrom(value.GetType());
			if (!flag)
			{
				converter = TypeDescriptor.GetConverter(value.GetType());
			}
			if (!flag && !converter.CanConvertTo(destinationType))
			{
				throw new InvalidOperationException(string.Concat(new object[]
				{
					"无法转换成类型：",
					value,
					"==>",
					destinationType
				}));
			}
			object result;
			try
			{
				result = ((!flag) ? converter.ConvertTo(null, null, value, destinationType) : converter.ConvertFrom(null, null, value));
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException(string.Concat(new object[]
				{
					"类型转换出错：",
					value,
					"==>",
					destinationType
				}), innerException);
			}
			return result;
		}

		public void SetParameter(string str, int parameterIndex)
		{
			this.parameters[parameterIndex] = str;
		}

		public object Call()
		{
			object result;
			try
			{
				ParameterInfo[] array = this.method.GetParameters();
				Type[] genericArguments = this.method.GetGenericArguments();
				MethodInfo methodInfo = null;
				if (this.method.IsGenericMethod)
				{
					Type[] array2 = new Type[genericArguments.Length];
					for (int i = 0; i < genericArguments.Length; i++)
					{
						array2[i] = (SimpleMethodReflect.Format(this.parameters[i], typeof(Type)) as Type);
					}
					methodInfo = this.method.MakeGenericMethod(array2);
				}
				else
				{
					methodInfo = this.method;
				}
				object[] array3 = new object[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					ParameterInfo parameterInfo = array[j];
					try
					{
						array3[j] = SimpleMethodReflect.Format(this.parameters[j + genericArguments.Length], parameterInfo.ParameterType);
					}
					catch (Exception)
					{
						array3[j] = parameterInfo.DefaultValue;
					}
				}
				object obj = methodInfo.Invoke(this.methodObject, array3);
				result = obj;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
}
