using Assets.Tools.Script.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Tools.Component
{
	public class SceneBakeData : MonoBehaviour
	{
		[Serializable]
		public class SceneLightmapInfo
		{
			public List<SceneBakeData.LightmapInfoData> Datas = new List<SceneBakeData.LightmapInfoData>();

			public LightmapsMode lightmapsMode;

			public Material skyBox;

			public Color ambientSkyColor;

			public Color ambientEquatorColor;

			public Color ambientGroundColor;

			public float ambientIntensity;

			public AmbientMode ambientMode;

			public bool fog;

			public Color fogColor;

			public FogMode fogMode;

			public float fogDensity;

			public float fogEndDistance;

			public float fogStartDistance;

			public static SceneBakeData.SceneLightmapInfo Create()
			{
				SceneBakeData.SceneLightmapInfo sceneLightmapInfo = new SceneBakeData.SceneLightmapInfo();
				LightmapData[] lightmaps = LightmapSettings.lightmaps;
				sceneLightmapInfo.skyBox = RenderSettings.skybox;
				sceneLightmapInfo.ambientSkyColor = RenderSettings.ambientSkyColor;
				sceneLightmapInfo.ambientEquatorColor = RenderSettings.ambientEquatorColor;
				sceneLightmapInfo.ambientGroundColor = RenderSettings.ambientGroundColor;
				sceneLightmapInfo.ambientIntensity = RenderSettings.ambientIntensity;
				sceneLightmapInfo.ambientMode = RenderSettings.ambientMode;
				sceneLightmapInfo.fog = RenderSettings.fog;
				sceneLightmapInfo.fogColor = RenderSettings.fogColor;
				sceneLightmapInfo.fogMode = RenderSettings.fogMode;
				sceneLightmapInfo.fogDensity = RenderSettings.fogDensity;
				sceneLightmapInfo.fogEndDistance = RenderSettings.fogEndDistance;
				sceneLightmapInfo.fogStartDistance = RenderSettings.fogStartDistance;
				for (int i = 0; i < lightmaps.Length; i++)
				{
					LightmapData lightmapData = lightmaps[i];
					sceneLightmapInfo.Datas.Add(new SceneBakeData.LightmapInfoData
					{
						Far = lightmapData.lightmapFar,
						Near = lightmapData.lightmapNear
					});
				}
				sceneLightmapInfo.lightmapsMode = LightmapSettings.lightmapsMode;
				return sceneLightmapInfo;
			}

			public void Restore()
			{
				LightmapData[] array = new LightmapData[this.Datas.Count];
				for (int i = 0; i < this.Datas.Count; i++)
				{
					SceneBakeData.LightmapInfoData lightmapInfoData = this.Datas[i];
					LightmapData lightmapData = new LightmapData
					{
						lightmapNear = lightmapInfoData.Near,
						lightmapFar = lightmapInfoData.Far
					};
					array[i] = lightmapData;
				}
				LightmapSettings.lightmapsMode = this.lightmapsMode;
				LightmapSettings.lightmaps = array;
				RenderSettings.skybox = this.skyBox;
				RenderSettings.ambientSkyColor = this.ambientSkyColor;
				RenderSettings.ambientEquatorColor = this.ambientEquatorColor;
				RenderSettings.ambientGroundColor = this.ambientGroundColor;
				RenderSettings.ambientIntensity = this.ambientIntensity;
				RenderSettings.ambientMode = this.ambientMode;
				RenderSettings.fog = this.fog;
				RenderSettings.fogColor = this.fogColor;
				RenderSettings.fogMode = this.fogMode;
				RenderSettings.fogDensity = this.fogDensity;
				RenderSettings.fogEndDistance = this.fogEndDistance;
				RenderSettings.fogStartDistance = this.fogStartDistance;
			}
		}

		[Serializable]
		public class LightmapInfoData
		{
			public Texture2D Near;

			public Texture2D Far;
		}

		[Serializable]
		public class RendererLightmapInfo
		{
			public Renderer Renderer;

			public int lightmapIndex;

			public Vector4 lightmapScaleOffset;

			public static SceneBakeData.RendererLightmapInfo Create(Renderer renderer)
			{
				return new SceneBakeData.RendererLightmapInfo
				{
					Renderer = renderer,
					lightmapIndex = renderer.lightmapIndex,
					lightmapScaleOffset = renderer.lightmapScaleOffset
				};
			}

			public void Restore()
			{
				this.Renderer.lightmapIndex = this.lightmapIndex;
				this.Renderer.lightmapScaleOffset = this.lightmapScaleOffset;
			}
		}

		public List<SceneBakeData.RendererLightmapInfo> RendererInfos;

		public SceneBakeData.SceneLightmapInfo SceneInfo;

		[ContextMenu("保存烘培信息")]
		public void Save()
		{
			this.RendererInfos = new List<SceneBakeData.RendererLightmapInfo>();
			base.transform.ForEachAllChildren(delegate(Transform t)
			{
				Renderer component = t.gameObject.GetComponent<Renderer>();
				if (component)
				{
					SceneBakeData.RendererLightmapInfo rendererLightmapInfo = SceneBakeData.RendererLightmapInfo.Create(component);
					if (rendererLightmapInfo.lightmapIndex >= 0)
					{
						this.RendererInfos.Add(rendererLightmapInfo);
					}
				}
				return true;
			});
			this.SceneInfo = SceneBakeData.SceneLightmapInfo.Create();
		}

		[ContextMenu("Restore lightmap")]
		public void Restore()
		{
			if (this.RendererInfos == null)
			{
				return;
			}
			for (int i = 0; i < this.RendererInfos.Count; i++)
			{
				SceneBakeData.RendererLightmapInfo rendererLightmapInfo = this.RendererInfos[i];
				rendererLightmapInfo.Restore();
			}
			this.SceneInfo.Restore();
		}
	}
}
