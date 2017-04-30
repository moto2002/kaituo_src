using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class GUIStyleState_DirectConverter : fsDirectConverter<GUIStyleState>
	{
		protected override fsResult DoSerialize(GUIStyleState model, Dictionary<string, fsData> serialized)
		{
			fsResult a = fsResult.Success;
			a += base.SerializeMember<Texture2D>(serialized, null, "background", model.background);
			return a + base.SerializeMember<Color>(serialized, null, "textColor", model.textColor);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref GUIStyleState model)
		{
			fsResult fsResult = fsResult.Success;
			Texture2D background = model.background;
			fsResult += base.DeserializeMember<Texture2D>(data, null, "background", out background);
			model.background = background;
			Color textColor = model.textColor;
			fsResult += base.DeserializeMember<Color>(data, null, "textColor", out textColor);
			model.textColor = textColor;
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return new GUIStyleState();
		}
	}
}
