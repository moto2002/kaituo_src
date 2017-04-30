using System;
using UnityEngine;
using XQ.Framework.Utility;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIBWTexture : UITexture
	{
		private static Material blackAndWhiteMaterial;

		public bool IsBlackAndWhite
		{
			get;
			private set;
		}

		public void SetBlackAndWhite(bool value)
		{
			if (this.IsBlackAndWhite == value)
			{
				return;
			}
			this.IsBlackAndWhite = value;
			if (this.IsBlackAndWhite)
			{
				if (UIBWTexture.blackAndWhiteMaterial == null)
				{
					UIBWTexture.blackAndWhiteMaterial = new Material(ShaderHelper.Find("Unlit/Transparent Colored Gray"));
				}
				this.material = UIBWTexture.blackAndWhiteMaterial;
			}
			else
			{
				this.material = null;
			}
		}

		[ContextMenu("change")]
		public void ChangeBlackAndWhite()
		{
			this.SetBlackAndWhite(!this.IsBlackAndWhite);
		}
	}
}
