using System;
using UnityEngine;

namespace XQ.Game.Util.Unity
{
	[RequireComponent(typeof(Camera))]
	public class RenderTextureMixCamera : MonoBehaviour
	{
		public RenderTextureMix Mix;

		private RenderTexture texture;

		private void Start()
		{
			base.GetComponent<Camera>().targetTexture = this.GetRenderTexture();
		}

		public RenderTexture GetRenderTexture()
		{
			RenderTexture arg_32_0;
			if ((arg_32_0 = this.texture) == null)
			{
				arg_32_0 = (this.texture = new RenderTexture(this.Mix.Width, this.Mix.Height, 0));
			}
			return arg_32_0;
		}

		public void OnPostRender()
		{
			this.Mix.RefreshTexture();
		}
	}
}
