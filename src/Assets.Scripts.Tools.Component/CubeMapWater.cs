using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	[ExecuteInEditMode]
	public class CubeMapWater : MonoBehaviour
	{
		public Cubemap Cubemap;

		private void Update()
		{
			if (!base.GetComponent<Renderer>())
			{
				return;
			}
			Material sharedMaterial = base.GetComponent<Renderer>().sharedMaterial;
			if (!sharedMaterial)
			{
				return;
			}
			Vector4 vector = sharedMaterial.GetVector("WaveSpeed");
			float @float = sharedMaterial.GetFloat("_WaveScale");
			Vector4 vector2 = new Vector4(@float, @float, @float * 0.4f, @float * 0.45f);
			double num = (double)Time.timeSinceLevelLoad / 20.0;
			Vector4 vector3 = new Vector4((float)Math.IEEERemainder((double)(vector.x * vector2.x) * num, 1.0), (float)Math.IEEERemainder((double)(vector.y * vector2.y) * num, 1.0), (float)Math.IEEERemainder((double)(vector.z * vector2.z) * num, 1.0), (float)Math.IEEERemainder((double)(vector.w * vector2.w) * num, 1.0));
			sharedMaterial.SetVector("_WaveOffset", vector3);
			sharedMaterial.SetVector("_WaveScale4", vector2);
		}
	}
}
