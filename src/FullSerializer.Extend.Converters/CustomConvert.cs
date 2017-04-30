using FullSerializer.Internal;
using System;
using System.Collections;

namespace FullSerializer.Extend.Converters
{
	public class CustomConvert : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			return !type.Resolve().IsArray && !typeof(ICollection).IsAssignableFrom(type);
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			serialized = fsData.CreateDictionary();
			fsResult success = fsResult.Success;
			fsMetaType fsMetaType = fsMetaType.Get(this.Serializer.Config, instance.GetType());
			fsMetaType.EmitAotData();
			for (int i = 0; i < fsMetaType.Properties.Length; i++)
			{
				fsMetaProperty fsMetaProperty = fsMetaType.Properties[i];
				if (fsMetaProperty.CanRead)
				{
					object obj = fsMetaProperty.Read(instance);
					Type storageType2 = fsMetaProperty.StorageType;
					if (!fsPortableReflection.HasAttribute<fsSkipNullAttribute>(fsMetaProperty.MemberInfo) || obj != null)
					{
						if (fsPortableReflection.HasAttribute<fsSkipObjectAttribute>(fsMetaProperty.MemberInfo))
						{
							storageType2 = obj.GetType();
						}
						fsData value;
						fsResult result = this.Serializer.TrySerialize(storageType2, fsMetaProperty.OverrideConverterType, obj, out value);
						success.AddMessages(result);
						if (!result.Failed)
						{
							serialized.AsDictionary[fsMetaProperty.JsonName] = value;
						}
					}
				}
			}
			return success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Object));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			fsMetaType fsMetaType = fsMetaType.Get(this.Serializer.Config, storageType);
			fsMetaType.EmitAotData();
			for (int i = 0; i < fsMetaType.Properties.Length; i++)
			{
				fsMetaProperty fsMetaProperty = fsMetaType.Properties[i];
				if (fsMetaProperty.CanWrite)
				{
					fsData data2;
					if (data.AsDictionary.TryGetValue(fsMetaProperty.JsonName, out data2))
					{
						object value = null;
						if (fsMetaProperty.CanRead)
						{
							value = fsMetaProperty.Read(instance);
						}
						Type storageType2 = fsMetaProperty.StorageType;
						fsSkipObjectAttribute attribute = fsPortableReflection.GetAttribute<fsSkipObjectAttribute>(fsMetaProperty.MemberInfo);
						if (attribute != null)
						{
							storageType2 = attribute.ValueType;
						}
						fsResult result = this.Serializer.TryDeserialize(data2, storageType2, fsMetaProperty.OverrideConverterType, ref value);
						fsResult.AddMessages(result);
						if (!result.Failed)
						{
							fsMetaProperty.Write(instance, value);
						}
					}
				}
			}
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			fsMetaType fsMetaType = fsMetaType.Get(this.Serializer.Config, storageType);
			return fsMetaType.CreateInstance();
		}
	}
}
