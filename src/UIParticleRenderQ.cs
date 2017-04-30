using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Utility;

[ExecuteInEditMode]
public class UIParticleRenderQ : UIWidget
{
	private static readonly Vector4 nonBorder = new Vector4(0f, 0f, 0f, 0f);

	public static Material particleShareMt;

	private static Color shareColor;

	public bool mShare = true;

	private Material particleMt;

	private readonly List<Material> mats = new List<Material>();

	public override Material material
	{
		get
		{
			return (!this.mShare) ? this.particleMt : UIParticleRenderQ.particleShareMt;
		}
	}

	public override Vector4 border
	{
		get
		{
			return UIParticleRenderQ.nonBorder;
		}
	}

	protected override void OnInit()
	{
		UIParticleRenderQ.shareColor = base.color.GammaToLinearSpace();
		if (this.mShare)
		{
			if (null == UIParticleRenderQ.particleShareMt)
			{
				UIParticleRenderQ.particleShareMt = new Material(ShaderHelper.Find("Unlit/Transparent Colored"))
				{
					name = "PSM-Share"
				};
			}
		}
		else if (null == this.particleMt)
		{
			this.particleMt = new Material(ShaderHelper.Find("Unlit/Transparent Colored"))
			{
				name = "PSM"
			};
		}
		this.onDrawCallChange = delegate(UIDrawCall dc)
		{
			if (null == dc)
			{
				return;
			}
			dc.onRenderQueueChange = new UIDrawCall.OnRenderQueueChange(this.ChangeRQ);
		};
		Renderer[] componentsInChildren = base.GetComponentsInChildren<Renderer>(true);
		if (componentsInChildren != null)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] sharedMaterials = componentsInChildren[i].sharedMaterials;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					if (sharedMaterials[j])
					{
						int width = sharedMaterials[j].mainTexture.width;
						int height = sharedMaterials[j].mainTexture.height;
						if (width > base.width)
						{
							base.width = width;
						}
						if (height > base.height)
						{
							base.height = height;
						}
						this.mats.Add(sharedMaterials[j]);
					}
				}
			}
		}
		base.OnInit();
	}

	private void OnDestroy()
	{
		this.mats.Clear();
	}

	private void ChangeRQ(int value)
	{
		for (int i = 0; i < this.mats.Count; i++)
		{
			this.mats[i].renderQueue = value;
		}
	}

	protected override void OnStart()
	{
		base.width = 2;
		base.height = 2;
		base.OnStart();
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
	{
		verts.Add(new Vector3(0f, 0f));
		verts.Add(new Vector3(0f, 1f));
		verts.Add(new Vector3(1f, 1f));
		verts.Add(new Vector3(1f, 0f));
		uvs.Add(new Vector2(0f, 0f));
		uvs.Add(new Vector2(0f, 1f));
		uvs.Add(new Vector2(1f, 1f));
		uvs.Add(new Vector2(1f, 0f));
		cols.Add(UIParticleRenderQ.shareColor);
		cols.Add(UIParticleRenderQ.shareColor);
		cols.Add(UIParticleRenderQ.shareColor);
		cols.Add(UIParticleRenderQ.shareColor);
	}
}
