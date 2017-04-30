using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[ExecuteInEditMode]
	public class VignetteCameraEffect : MonoBehaviour
	{
		public Material Material;

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			Graphics.Blit(source, destination, this.Material);
		}
	}
}
