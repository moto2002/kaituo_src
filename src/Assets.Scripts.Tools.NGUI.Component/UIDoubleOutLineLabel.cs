using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIDoubleOutLineLabel : UILabel
	{
		public bool DoubleOutLine = true;

		public Vector2 DoubleOutLineDistance;

		public Color DoubleOutLineColor;

		public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
		{
			if (!base.labelIsValid)
			{
				return;
			}
			int num = verts.size;
			Color color = base.color;
			color.a = this.finalAlpha;
			UIFont labelMFont = base.labelMFont;
			Vector2 labelMEffectDistance = base.labelMEffectDistance;
			if (labelMFont != null && labelMFont.premultipliedAlphaShader)
			{
				color = NGUITools.ApplyPMA(color);
			}
			if (QualitySettings.activeColorSpace == ColorSpace.Linear)
			{
				color.r = Mathf.GammaToLinearSpace(color.r);
				color.g = Mathf.GammaToLinearSpace(color.g);
				color.b = Mathf.GammaToLinearSpace(color.b);
				color.a = Mathf.GammaToLinearSpace(color.a);
			}
			string processedText = base.processedText;
			int size = verts.size;
			base.UpdateNGUIText();
			NGUIText.tint = color;
			NGUIText.Print(processedText, verts, uvs, cols);
			NGUIText.bitmapFont = null;
			NGUIText.dynamicFont = null;
			Vector2 vector = base.ApplyOffset(verts, size);
			if (labelMFont != null && labelMFont.packedFontShader)
			{
				return;
			}
			if (this.DoubleOutLine)
			{
				int size2 = verts.size;
				vector.x = this.DoubleOutLineDistance.x;
				vector.y = this.DoubleOutLineDistance.y;
				this.ApplyShadow(verts, uvs, cols, num, size2, vector.x, -vector.y, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
				this.ApplyShadow(verts, uvs, cols, num, size2, -vector.x, vector.y, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
				this.ApplyShadow(verts, uvs, cols, num, size2, vector.x, vector.y, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
				this.ApplyShadow(verts, uvs, cols, num, size2, -vector.x, -vector.y, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
				this.ApplyShadow(verts, uvs, cols, num, size2, -vector.x, 0f, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
				this.ApplyShadow(verts, uvs, cols, num, size2, vector.x, 0f, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
				this.ApplyShadow(verts, uvs, cols, num, size2, 0f, vector.y, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
				this.ApplyShadow(verts, uvs, cols, num, size2, 0f, -vector.y, this.DoubleOutLineColor);
				num = size2;
				size2 = verts.size;
			}
			if (base.effectStyle != UILabel.Effect.None)
			{
				int size3 = verts.size;
				vector.x = labelMEffectDistance.x;
				vector.y = labelMEffectDistance.y;
				base.ApplyShadow(verts, uvs, cols, num, size3, vector.x, -vector.y);
				if (base.effectStyle == UILabel.Effect.Outline || base.effectStyle == UILabel.Effect.Outline8)
				{
					num = size3;
					size3 = verts.size;
					base.ApplyShadow(verts, uvs, cols, num, size3, -vector.x, vector.y);
					num = size3;
					size3 = verts.size;
					base.ApplyShadow(verts, uvs, cols, num, size3, vector.x, vector.y);
					num = size3;
					size3 = verts.size;
					base.ApplyShadow(verts, uvs, cols, num, size3, -vector.x, -vector.y);
					if (base.effectStyle == UILabel.Effect.Outline8)
					{
						num = size3;
						size3 = verts.size;
						base.ApplyShadow(verts, uvs, cols, num, size3, -vector.x, 0f);
						num = size3;
						size3 = verts.size;
						base.ApplyShadow(verts, uvs, cols, num, size3, vector.x, 0f);
						num = size3;
						size3 = verts.size;
						base.ApplyShadow(verts, uvs, cols, num, size3, 0f, vector.y);
						num = size3;
						size3 = verts.size;
						base.ApplyShadow(verts, uvs, cols, num, size3, 0f, -vector.y);
					}
				}
			}
			if (this.onPostFill != null)
			{
				this.onPostFill(this, num, verts, uvs, cols);
			}
		}

		public void ApplyShadow(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols, int start, int end, float x, float y, Color c)
		{
			c.a *= this.finalAlpha;
			Color32 c2 = (!(base.bitmapFont != null) || !base.bitmapFont.premultipliedAlphaShader) ? c : NGUITools.ApplyPMA(c);
			for (int i = start; i < end; i++)
			{
				verts.Add(verts.buffer[i]);
				uvs.Add(uvs.buffer[i]);
				cols.Add(cols.buffer[i]);
				Vector3 vector = verts.buffer[i];
				vector.x += x;
				vector.y += y;
				verts.buffer[i] = vector;
				Color32 color = cols.buffer[i];
				if (color.a == 255)
				{
					cols.buffer[i] = c2;
				}
				else
				{
					Color color2 = c;
					color2.a = (float)color.a / 255f * c.a;
					cols.buffer[i] = ((!(base.bitmapFont != null) || !base.bitmapFont.premultipliedAlphaShader) ? color2 : NGUITools.ApplyPMA(color2));
				}
			}
		}
	}
}
