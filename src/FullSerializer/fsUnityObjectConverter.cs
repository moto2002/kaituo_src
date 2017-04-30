using ParadoxNotion;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer
{
	public class fsUnityObjectConverter : fsConverter
	{
		public override bool CanProcess(Type type)
		{
			return typeof(UnityEngine.Object).RTIsAssignableFrom(type);
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
			List<UnityEngine.Object> list = this.Serializer.Context.Get<List<UnityEngine.Object>>();
			UnityEngine.Object @object = instance as UnityEngine.Object;
			int num = -1;
			for (int i = 0; i < list.Count; i++)
			{
				if (object.ReferenceEquals(list[i], @object))
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				num = list.Count;
				list.Add(@object);
			}
			serialized = new fsData((long)num);
			return fsResult.Success;
		}

		public override fsResult TryDeserialize(fsData data, ref object instance, Type storageType)
		{
			List<UnityEngine.Object> list = this.Serializer.Context.Get<List<UnityEngine.Object>>();
			int num = (int)data.AsInt64;
			if (num >= list.Count)
			{
				return fsResult.Warn("A Unity Object reference has not been deserialized");
			}
			instance = list[num];
			return fsResult.Success;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return null;
		}
	}
}
