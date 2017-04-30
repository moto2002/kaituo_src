using System;
using UnityEngine;

namespace Assets.Tools.Script.Cameratool
{
	public abstract class OcclusionsRaycastHandle : MonoBehaviour
	{
		public abstract void IntoLinecast();

		public abstract void OutLinecast();
	}
}
