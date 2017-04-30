using NodeCanvas.Framework;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action
{
	public static class AnchorPointHelper
	{
		public static Transform GetTransform(this AnchorPointType type, BBParameter<Transform> tr, BBParameter<GameObject> go)
		{
			if (type == AnchorPointType.Transform)
			{
				return (tr != null) ? tr.value : null;
			}
			if (type != AnchorPointType.GameObject)
			{
				return null;
			}
			if (go == null)
			{
				return null;
			}
			GameObject value = go.value;
			return (!(value == null)) ? value.transform : null;
		}
	}
}
