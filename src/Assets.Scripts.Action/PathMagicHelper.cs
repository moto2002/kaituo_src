using Jacovone;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	public static class PathMagicHelper
	{
		public static void StopWithoutUpdate(this PathMagic path)
		{
			Transform target = path.Target;
			path.Target = null;
			path.Stop();
			path.Target = target;
		}
	}
}
