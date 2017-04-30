using System;
using System.Collections;
using System.Collections.Generic;

namespace FullSerializer.Internal
{
	public class fsArrayConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			return type.IsArray;
		}

		public override bool RequestCycleSupport(Type storageType)
		{
			return false;
		}

		public override bool RequestInheritanceSupport(Type storageType)
		{
			return false;
		}

		public override fsResult TrySerialize(object instance, out fsData serialized, Type storageType)
		{
			IList list = (Array)instance;
			Type elementType = storageType.GetElementType();
			fsResult success = fsResult.Success;
			serialized = fsData.CreateList(list.Count);
			List<fsData> asList = serialized.AsList;
			for (int i = 0; i < list.Count; i++)
			{
				object instance2 = list[i];
				fsData item;
				fsResult result = this.Serializer.TrySerialize(elementType, instance2, out item);
				success.AddMessages(result);
				if (!result.Failed)
				{
					asList.Add(item);
				}
			}
			return success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			fsResult fsResult = fsResult.Success;
			fsResult fsResult2;
			fsResult = (fsResult2 = fsResult + base.CheckType(data, fsDataType.Array));
			if (fsResult2.Failed)
			{
				return fsResult;
			}
			Type elementType = storageType.GetElementType();
			List<fsData> asList = data.AsList;
			ArrayList arrayList = new ArrayList(asList.Count);
			int count = arrayList.Count;
			for (int i = 0; i < asList.Count; i++)
			{
				fsData data2 = asList[i];
				object value = null;
				if (i < count)
				{
					value = arrayList[i];
				}
				fsResult result = this.Serializer.TryDeserialize(data2, elementType, ref value);
				fsResult.AddMessages(result);
				if (!result.Failed)
				{
					if (i < count)
					{
						arrayList[i] = value;
					}
					else
					{
						arrayList.Add(value);
					}
				}
			}
			instance = arrayList.ToArray(elementType);
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return fsMetaType.Get(this.Serializer.Config, storageType).CreateInstance();
		}
	}
}
