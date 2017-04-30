using System;
using UnityEngine;

namespace FullSerializer.Internal
{
	public class fsSerializationCallbackReceiverProcessor : fsObjectProcessor
	{
		public override bool CanProcess(Type type)
		{
			return typeof(ISerializationCallbackReceiver).IsAssignableFrom(type);
		}

		public override void OnBeforeSerialize(Type storageType, object instance)
		{
			if (instance == null)
			{
				return;
			}
			((ISerializationCallbackReceiver)instance).OnBeforeSerialize();
		}

		public override void OnAfterDeserialize(Type storageType, object instance)
		{
			if (instance == null)
			{
				return;
			}
			((ISerializationCallbackReceiver)instance).OnAfterDeserialize();
		}
	}
}
