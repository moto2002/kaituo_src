using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace XQ.Framework.Utility
{
	public static class ShaderHelper
	{
		private static readonly Dictionary<string, Shader> shaders = new Dictionary<string, Shader>();

		public static void SetShader(Shader shader)
		{
			if (!ShaderHelper.shaders.ContainsKey(shader.name))
			{
				ShaderHelper.shaders.Add(shader.name, shader);
			}
		}

		public static Shader Find(string shadername)
		{
			Shader shader = null;
			if (!ShaderHelper.shaders.TryGetValue(shadername, out shader))
			{
				shader = Shader.Find(shadername);
				if (!shader)
				{
					UDebug.Error("找不到shader：{0}", new object[]
					{
						shadername
					});
					shader = Shader.Find("Hidden/InternalErrorShader");
				}
			}
			return shader;
		}
	}
}
