using System;
using UnityEngine;

namespace XQ.Game.Util.Unity
{
	public class ShadowMapLight : MonoBehaviour
	{
		public static ShadowMapLight Instance;

		[HideInInspector]
		public int ShadowMapSize = 256;

		[HideInInspector]
		public Camera ShadowCamera;

		[HideInInspector]
		public Projector ShadowProjector;

		[HideInInspector]
		public RenderTexture ShadowMap;

		public MeshRenderer ShadowMesh;

		public RenderTexture Texture;

		public Matrix4x4 m44;

		public Action UpdateAction;

		public Material ShadowMaterial
		{
			get
			{
				if (this.ShadowMesh == null)
				{
					return null;
				}
				if (Application.isPlaying)
				{
					return this.ShadowMesh.material;
				}
				return this.ShadowMesh.sharedMaterial;
			}
		}

		private void Start()
		{
			ShadowMapLight.Instance = this;
			this.ResetProMatrix();
		}

		private void Update()
		{
			this.ResetProMatrix();
		}

		private void ResetProMatrix()
		{
			Material shadowMaterial = this.ShadowMaterial;
			if (shadowMaterial != null)
			{
				shadowMaterial.SetMatrix("_ProM44", this.m44);
			}
		}
	}
}
