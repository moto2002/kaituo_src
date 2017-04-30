using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class Scene2DConfig : MonoBehaviour
	{
		public static Scene2DConfig Instance;

		public float FloorAlpha = 1f;

		private void Awake()
		{
			Scene2DConfig.Instance = this;
		}
	}
}
