using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class AutoMobileShaderSwitch : MonoBehaviour
	{
		[Serializable]
		public class ReplacementDefinition
		{
			public Shader original;

			public Shader replacement;
		}

		[Serializable]
		public class ReplacementList
		{
			public AutoMobileShaderSwitch.ReplacementDefinition[] items = new AutoMobileShaderSwitch.ReplacementDefinition[0];
		}

		[SerializeField]
		private AutoMobileShaderSwitch.ReplacementList m_ReplacementList;

		private void OnEnable()
		{
			Renderer[] array = UnityEngine.Object.FindObjectsOfType<Renderer>();
			Debug.Log(array.Length + " renderers");
			List<Material> list = new List<Material>();
			List<Material> list2 = new List<Material>();
			int num = 0;
			int num2 = 0;
			AutoMobileShaderSwitch.ReplacementDefinition[] items = this.m_ReplacementList.items;
			for (int i = 0; i < items.Length; i++)
			{
				AutoMobileShaderSwitch.ReplacementDefinition replacementDefinition = items[i];
				Renderer[] array2 = array;
				for (int j = 0; j < array2.Length; j++)
				{
					Renderer renderer = array2[j];
					Material[] array3 = null;
					for (int k = 0; k < renderer.sharedMaterials.Length; k++)
					{
						Material material = renderer.sharedMaterials[k];
						if (material.shader == replacementDefinition.original)
						{
							if (array3 == null)
							{
								array3 = renderer.materials;
							}
							if (!list.Contains(material))
							{
								list.Add(material);
								Material material2 = UnityEngine.Object.Instantiate<Material>(material);
								material2.shader = replacementDefinition.replacement;
								list2.Add(material2);
								num++;
							}
							Debug.Log(string.Concat(new object[]
							{
								"replacing ",
								renderer.gameObject.name,
								" renderer ",
								k,
								" with ",
								list2[list.IndexOf(material)].name
							}));
							array3[k] = list2[list.IndexOf(material)];
							num2++;
						}
					}
					if (array3 != null)
					{
						renderer.materials = array3;
					}
				}
			}
			Debug.Log(num2 + " material instances replaced");
			Debug.Log(num + " materials replaced");
			for (int l = 0; l < list.Count; l++)
			{
				Debug.Log(string.Concat(new string[]
				{
					list[l].name,
					" (",
					list[l].shader.name,
					") replaced with ",
					list2[l].name,
					" (",
					list2[l].shader.name,
					")"
				}));
			}
		}
	}
}
