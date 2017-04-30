using System;
using UnityEngine;
using XQ.Game.Util.Unity;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class CameraRenderTexture : MonoBehaviour
	{
		public string Name;

		public UITexture Texture;

		public void Start()
		{
			if (this.Texture == null)
			{
				this.Texture = base.GetComponent<UITexture>();
			}
		}

		public void OnEnable()
		{
			if (!this.TryGetTexture())
			{
				base.InvokeRepeating("TryGetTexture", 0f, 0f);
			}
		}

		public void OnDisable()
		{
			RenderTextureMix.UnuseTexture(this.Name);
		}

		private bool TryGetTexture()
		{
			Texture texture = RenderTextureMix.UseTexture(this.Name);
			if (texture != null)
			{
				this.Texture.mainTexture = texture;
				base.CancelInvoke("TryGetTexture");
				return true;
			}
			return false;
		}
	}
}
