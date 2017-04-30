using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class Gradient_DirectConverter : fsDirectConverter<Gradient>
	{
		protected override fsResult DoSerialize(Gradient model, Dictionary<string, fsData> serialized)
		{
			fsResult a = fsResult.Success;
			a += base.SerializeMember<GradientAlphaKey[]>(serialized, null, "alphaKeys", model.alphaKeys);
			return a + base.SerializeMember<GradientColorKey[]>(serialized, null, "colorKeys", model.colorKeys);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref Gradient model)
		{
			fsResult fsResult = fsResult.Success;
			GradientAlphaKey[] alphaKeys = model.alphaKeys;
			fsResult += base.DeserializeMember<GradientAlphaKey[]>(data, null, "alphaKeys", out alphaKeys);
			model.alphaKeys = alphaKeys;
			GradientColorKey[] colorKeys = model.colorKeys;
			fsResult += base.DeserializeMember<GradientColorKey[]>(data, null, "colorKeys", out colorKeys);
			model.colorKeys = colorKeys;
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return new Gradient();
		}
	}
}
