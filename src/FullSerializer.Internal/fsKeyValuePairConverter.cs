using System;
using System.Collections.Generic;
using System.Reflection;

namespace FullSerializer.Internal
{
	public class fsKeyValuePairConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			return type.Resolve().IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<, >);
		}

		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsData data2;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckKey(data, "Key", out data2));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			fsData data3;
			fsResult fsResult3;
			fsResult = (fsResult3 = fsResult + base.CheckKey(data, "Value", out data3));
			if (fsResult3.Failed)
			{
				return fsResult;
			}
			Type[] genericArguments = storageType.GetGenericArguments();
			Type storageType2 = genericArguments[0];
			Type storageType3 = genericArguments[1];
			object obj = null;
			object obj2 = null;
			fsResult.AddMessages(this.Serializer.TryDeserialize(data2, storageType2, ref obj));
			fsResult.AddMessages(this.Serializer.TryDeserialize(data3, storageType3, ref obj2));
			instance = Activator.CreateInstance(storageType, new object[]
			{
				obj,
				obj2
			});
			return fsResult;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			PropertyInfo declaredProperty = storageType.GetDeclaredProperty("Key");
			PropertyInfo declaredProperty2 = storageType.GetDeclaredProperty("Value");
			object value = declaredProperty.GetValue(instance, null);
			object value2 = declaredProperty2.GetValue(instance, null);
			Type[] genericArguments = storageType.GetGenericArguments();
			Type storageType2 = genericArguments[0];
			Type storageType3 = genericArguments[1];
			fsResult success = fsResult.Success;
			fsData fsData;
			success.AddMessages(this.Serializer.TrySerialize(storageType2, value, out fsData));
			fsData fsData2;
			success.AddMessages(this.Serializer.TrySerialize(storageType3, value2, out fsData2));
			serialized = fsData.CreateDictionary();
			if (fsData != null)
			{
				serialized.AsDictionary["Key"] = fsData;
			}
			if (fsData2 != null)
			{
				serialized.AsDictionary["Value"] = fsData2;
			}
			return success;
		}
	}
}
