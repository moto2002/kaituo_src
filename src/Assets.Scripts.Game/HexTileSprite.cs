using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Utility;

namespace Assets.Scripts.Game
{
	public class HexTileSprite : UIWidget
	{
		public float Radius;

		public float Gap;

		public bool IsMirror;

		private Material hexMaterial;

		private Vector2 uv1 = new Vector2(0f, 0f);

		private Vector2 uv2 = new Vector2(0f, 1f);

		private Vector2 uv3 = new Vector2(1f, 0f);

		private Vector2 uv4 = new Vector2(1f, 1f);

		private float sin30 = Mathf.Sin(0.5235988f);

		private float cos30 = Mathf.Cos(0.5235988f);

		private List<Vector3> HexVertex;

		private Dictionary<Vector3, Color> Hexs = new Dictionary<Vector3, Color>();

		public override Material material
		{
			get
			{
				if (this.hexMaterial == null)
				{
					this.hexMaterial = new Material(ShaderHelper.Find("Unlit/Unlit(Color)"));
				}
				return this.hexMaterial;
			}
			set
			{
				this.hexMaterial = value;
			}
		}

		public override Texture mainTexture
		{
			get
			{
				return null;
			}
		}

		public void Begin(float radius, float gap, bool isMirror)
		{
			this.Radius = radius;
			this.IsMirror = isMirror;
			this.Gap = gap;
			this.Reset();
			this.mChanged = true;
			this.Hexs.Clear();
		}

		public void DrawHex(Vector3 hex, Color color)
		{
			this.Hexs.Add(hex, color);
		}

		public void End()
		{
		}

		public void Reset()
		{
			if (this.HexVertex == null)
			{
				this.HexVertex = new List<Vector3>();
			}
			else
			{
				this.HexVertex.Clear();
			}
			this.HexVertex.Add(new Vector3(0f, this.Radius, 0f));
			this.HexVertex.Add(new Vector3(0f, -this.Radius, 0f));
			this.HexVertex.Add(new Vector3(this.cos30 * this.Radius, -this.sin30 * this.Radius, 0f));
			this.HexVertex.Add(new Vector3(this.cos30 * this.Radius, this.sin30 * this.Radius, 0f));
			this.HexVertex.Add(new Vector3(-this.cos30 * this.Radius, this.sin30 * this.Radius, 0f));
			this.HexVertex.Add(new Vector3(-this.cos30 * this.Radius, -this.sin30 * this.Radius, 0f));
			this.HexVertex.Add(new Vector3(0f, -this.Radius, 0f));
			this.HexVertex.Add(new Vector3(0f, this.Radius, 0f));
		}

		public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
		{
			if (this.HexVertex == null)
			{
				this.Reset();
			}
			foreach (KeyValuePair<Vector3, Color> current in this.Hexs)
			{
				this.DrawHex(current.Key, current.Value, verts, uvs, cols);
			}
		}

		private void DrawFrame(Vector3 center, Color c, BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
		{
		}

		private void DrawHex(Vector3 center, Color c, BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
		{
			Vector3 b = this.Hex2Pixel(center);
			verts.Add(this.HexVertex[0] + b);
			verts.Add(this.HexVertex[1] + b);
			verts.Add(this.HexVertex[2] + b);
			verts.Add(this.HexVertex[3] + b);
			verts.Add(this.HexVertex[4] + b);
			verts.Add(this.HexVertex[5] + b);
			verts.Add(this.HexVertex[6] + b);
			verts.Add(this.HexVertex[7] + b);
			uvs.Add(this.uv1);
			uvs.Add(this.uv2);
			uvs.Add(this.uv3);
			uvs.Add(this.uv4);
			uvs.Add(this.uv1);
			uvs.Add(this.uv2);
			uvs.Add(this.uv3);
			uvs.Add(this.uv4);
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
		}

		private Vector3 Hex2Pixel(Vector3 center)
		{
			float num = this.Gap + this.Radius;
			return new Vector3(num * ((!this.IsMirror) ? 1.73205078f : -1.73205078f) * (center.x + center.y / 2f), num * 1.5f * center.y, 0f);
		}
	}
}
