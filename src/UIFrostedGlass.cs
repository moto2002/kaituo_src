using System;
using UnityEngine;

[ExecuteInEditMode]
public class UIFrostedGlass : UIBasicSprite
{
	public Material mat;

	private Rect uv = new Rect(0f, 0f, 1f, 1f);

	public override Material material
	{
		get
		{
			return this.mat;
		}
		set
		{
			if (this.mat != value)
			{
				base.RemoveFromPanel();
				this.mat = value;
				this.MarkAsChanged();
			}
		}
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
	{
		base.Fill(verts, uvs, cols, this.uv, this.uv);
	}
}
