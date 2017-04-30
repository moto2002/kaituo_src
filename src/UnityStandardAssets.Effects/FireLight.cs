using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class FireLight : MonoBehaviour
	{
		private float m_Rnd;

		private bool m_Burning = true;

		private Light m_Light;

		private void Start()
		{
			this.m_Rnd = UnityEngine.Random.value * 100f;
			this.m_Light = base.GetComponent<Light>();
		}

		private void Update()
		{
			if (this.m_Burning)
			{
				this.m_Light.intensity = 2f * Mathf.PerlinNoise(this.m_Rnd + Time.time, this.m_Rnd + 1f + Time.time * 1f);
				float x = Mathf.PerlinNoise(this.m_Rnd + Time.time * 2f, this.m_Rnd + 1f + Time.time * 2f) - 0.5f;
				float y = Mathf.PerlinNoise(this.m_Rnd + 2f + Time.time * 2f, this.m_Rnd + 3f + Time.time * 2f) - 0.5f;
				float z = Mathf.PerlinNoise(this.m_Rnd + 4f + Time.time * 2f, this.m_Rnd + 5f + Time.time * 2f) - 0.5f;
				base.transform.localPosition = Vector3.up + new Vector3(x, y, z) * 1f;
			}
		}

		public void Extinguish()
		{
			this.m_Burning = false;
			this.m_Light.enabled = false;
		}
	}
}
