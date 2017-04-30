using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.Game.Util.Unity
{
	public class RenderTextureMix : MonoBehaviour
	{
		private static Dictionary<string, RenderTextureMix> renderTextures = new Dictionary<string, RenderTextureMix>();

		private static Dictionary<string, int> renderRef = new Dictionary<string, int>();

		private static int dx;

		public int Width = 256;

		public int Height = 256;

		public string Name;

		public RenderTextureMixCamera Texture1;

		public RenderTextureMixCamera Texture2;

		public RenderTexture TextureOutput;

		public Material Material;

		private int renderedTextureCount;

		public static Texture UseTexture(string name)
		{
			if (RenderTextureMix.renderTextures.ContainsKey(name))
			{
				Dictionary<string, int> dictionary;
				Dictionary<string, int> expr_15 = dictionary = RenderTextureMix.renderRef;
				int num = dictionary[name];
				expr_15[name] = num + 1;
				RenderTextureMix renderTextureMix = RenderTextureMix.renderTextures[name];
				renderTextureMix.gameObject.SetActive(true);
				return renderTextureMix.TextureOutput;
			}
			return null;
		}

		public static void UnuseTexture(string name)
		{
			if (!RenderTextureMix.renderRef.ContainsKey(name))
			{
				return;
			}
			Dictionary<string, int> dictionary;
			Dictionary<string, int> expr_16 = dictionary = RenderTextureMix.renderRef;
			int num = dictionary[name];
			int num2 = expr_16[name] = num - 1;
			if (num2 == 0)
			{
				RenderTextureMix.renderTextures[name].gameObject.SetActive(false);
			}
			if (num2 < 0)
			{
				RenderTextureMix.renderRef[name] = 0;
			}
		}

		public void ResetName(string newName)
		{
			if (RenderTextureMix.renderRef[this.Name] > 0)
			{
				throw new Exception("any ref here!");
			}
			RenderTextureMix.renderTextures.Remove(this.Name);
			RenderTextureMix.renderRef.Remove(this.Name);
			this.Name = newName;
			RenderTextureMix.renderTextures[this.Name] = this;
			RenderTextureMix.renderRef[this.Name] = 0;
		}

		public void RefreshTexture()
		{
			if (++this.renderedTextureCount == 2)
			{
				this.renderedTextureCount = 0;
				Graphics.Blit(this.Texture1.GetRenderTexture(), this.TextureOutput, this.Material);
			}
		}

		private void Start()
		{
			this.Material.SetTexture("_Tex2", this.Texture2.GetRenderTexture());
			if (this.TextureOutput == null)
			{
				this.TextureOutput = new RenderTexture(this.Width, this.Height, 0);
			}
			base.transform.position = new Vector3((float)(RenderTextureMix.dx += 6241), 2064f, 178541f);
			if (!RenderTextureMix.renderTextures.ContainsKey(this.Name))
			{
				RenderTextureMix.renderTextures[this.Name] = this;
				RenderTextureMix.renderRef[this.Name] = 0;
			}
			base.gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			RenderTextureMix.renderTextures.Remove(this.Name);
			RenderTextureMix.renderRef.Remove(this.Name);
		}
	}
}
