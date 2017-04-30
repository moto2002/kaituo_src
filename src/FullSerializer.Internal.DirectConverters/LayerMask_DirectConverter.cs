using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class LayerMask_DirectConverter : fsDirectConverter<LayerMask>
	{
		protected override fsResult DoSerialize(LayerMask model, Dictionary<string, fsData> serialized)
		{
			fsResult success = fsResult.Success;
			return success + base.SerializeMember<int>(serialized, null, "value", model.value);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref LayerMask model)
		{
			fsResult fsResult = fsResult.Success;
			int value = model.value;
			fsResult += base.DeserializeMember<int>(data, null, "value", out value);
			model.value = value;
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return default(LayerMask);
		}
	}
}
