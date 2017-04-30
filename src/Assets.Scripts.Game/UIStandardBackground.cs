using System;
using UnityEngine;
using XQ.Framework.Utility;

namespace Assets.Scripts.Game
{
	public class UIStandardBackground : UIWidget
	{
		[HideInInspector, SerializeField]
		private Material mMat;

		[HideInInspector, SerializeField]
		private Texture mTexture;

		[HideInInspector, SerializeField]
		private Shader mShader;

		public override Texture mainTexture
		{
			get
			{
				if (this.mTexture != null)
				{
					return this.mTexture;
				}
				if (this.mMat != null)
				{
					return this.mMat.mainTexture;
				}
				return null;
			}
			set
			{
				if (this.mTexture != value)
				{
					if (base.drawCall != null && base.drawCall.widgetCount == 1 && this.mMat == null)
					{
						this.mTexture = value;
						base.drawCall.mainTexture = value;
					}
					else
					{
						base.RemoveFromPanel();
						this.mTexture = value;
						this.MarkAsChanged();
					}
				}
			}
		}

		public override Material material
		{
			get
			{
				return this.mMat;
			}
			set
			{
				if (this.mMat != value)
				{
					base.RemoveFromPanel();
					this.mShader = null;
					this.mMat = value;
					this.MarkAsChanged();
				}
			}
		}

		public override Shader shader
		{
			get
			{
				if (this.mMat != null)
				{
					return this.mMat.shader;
				}
				if (this.mShader == null)
				{
					this.mShader = ShaderHelper.Find("Unlit/Transparent Colored");
				}
				return this.mShader;
			}
			set
			{
				if (this.mShader != value)
				{
					if (base.drawCall != null && base.drawCall.widgetCount == 1 && this.mMat == null)
					{
						this.mShader = value;
						base.drawCall.shader = value;
					}
					else
					{
						base.RemoveFromPanel();
						this.mShader = value;
						this.mMat = null;
						this.MarkAsChanged();
					}
				}
			}
		}

		public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
		{
			verts.Add(new Vector3(720f, 0f, 0f));
			verts.Add(new Vector3(0f, 0f, 0f));
			verts.Add(new Vector3(0f, 1024f, 0f));
			verts.Add(new Vector3(720f, 1024f, 0f));
			uvs.Add(new Vector2(0.703125f, 0f));
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(0.703125f, 1f));
			cols.Add(Color.white);
			cols.Add(Color.white);
			cols.Add(Color.white);
			cols.Add(Color.white);
			verts.Add(new Vector3(720f, 1024f, 0f));
			verts.Add(new Vector3(0f, 1024f, 0f));
			verts.Add(new Vector3(0f, 1280f, 0f));
			verts.Add(new Vector3(720f, 1280f, 0f));
			uvs.Add(new Vector2(0.703125f, 0f));
			uvs.Add(new Vector2(0.703125f, 0.703125f));
			uvs.Add(new Vector2(0.953125f, 0.703125f));
			uvs.Add(new Vector2(0.953125f, 0f));
			cols.Add(Color.white);
			cols.Add(Color.white);
			cols.Add(Color.white);
			cols.Add(Color.white);
		}
	}
}
