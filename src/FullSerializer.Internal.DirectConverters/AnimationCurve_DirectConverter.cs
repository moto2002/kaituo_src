using System;
using System.Collections.Generic;
using UnityEngine;

namespace FullSerializer.Internal.DirectConverters
{
	public class AnimationCurve_DirectConverter : fsDirectConverter<AnimationCurve>
	{
		protected override fsResult DoSerialize(AnimationCurve model, Dictionary<string, fsData> serialized)
		{
			fsResult a = fsResult.Success;
			a += base.SerializeMember<Keyframe[]>(serialized, null, "keys", model.keys);
			a += base.SerializeMember<WrapMode>(serialized, null, "preWrapMode", model.preWrapMode);
			return a + base.SerializeMember<WrapMode>(serialized, null, "postWrapMode", model.postWrapMode);
		}

		protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref AnimationCurve model)
		{
			fsResult fsResult = fsResult.Success;
			Keyframe[] keys = model.keys;
			fsResult += base.DeserializeMember<Keyframe[]>(data, null, "keys", out keys);
			model.keys = keys;
			WrapMode preWrapMode = model.preWrapMode;
			fsResult += base.DeserializeMember<WrapMode>(data, null, "preWrapMode", out preWrapMode);
			model.preWrapMode = preWrapMode;
			WrapMode postWrapMode = model.postWrapMode;
			fsResult += base.DeserializeMember<WrapMode>(data, null, "postWrapMode", out postWrapMode);
			model.postWrapMode = postWrapMode;
			return fsResult;
		}

		public override object CreateInstance(fsData data, Type storageType)
		{
			return new AnimationCurve();
		}
	}
}
