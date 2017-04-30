using System;
using UnityEngine;

namespace Assets.Scripts.Tool
{
	public abstract class BehaviourTreeProcess : MonoBehaviour
	{
		public abstract void Init();

		public abstract void Dispose();
	}
}
