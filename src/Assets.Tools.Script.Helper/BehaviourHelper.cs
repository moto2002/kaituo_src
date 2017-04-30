using System;
using UnityEngine;

namespace Assets.Tools.Script.Helper
{
	public static class BehaviourHelper
	{
		public static bool IsActive(this Behaviour mb)
		{
			return mb && mb.enabled && mb.gameObject.activeInHierarchy;
		}
	}
}
