using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class RectOffset_DirectConverter : fsDirectConverter<RectOffset>
	{
		protected override fsResult DoSerialize(RectOffset model, Dictionary<string, fsData> serialized)
		{
			fsResult a = fsResult.Success;
			a += base.SerializeMember<int>(serialized, null, "bottom", model.bottom);
			a += base.SerializeMember<int>(serialized, null, "left", model.left);
			a += base.SerializeMember<int>(serialized, null, "right", model.right);
			return a + base.SerializeMember<int>(serialized, null, "top", model.top);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref RectOffset model)
		{
			fsResult fsResult = fsResult.Success;
			int bottom = model.bottom;
			fsResult += base.DeserializeMember<int>(data, null, "bottom", out bottom);
			model.bottom = bottom;
			int left = model.left;
			fsResult += base.DeserializeMember<int>(data, null, "left", out left);
			model.left = left;
			int right = model.right;
			fsResult += base.DeserializeMember<int>(data, null, "right", out right);
			model.right = right;
			int top = model.top;
			fsResult += base.DeserializeMember<int>(data, null, "top", out top);
			model.top = top;
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return new RectOffset();
		}
	}
}
