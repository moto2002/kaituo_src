using System;
using UnityEngine;

namespace XQ.Game.Util.Unity
{
	public class ParticleScaler : MonoBehaviour
	{
		private Transform root;

		public void OnEnable()
		{
		}

		public void ResetRoot()
		{
			Transform transform = base.transform;
			do
			{
				ParticleScalerRoot component = transform.GetComponent<ParticleScalerRoot>();
				if (component != null)
				{
					this.root = component.RootAgent;
				}
				else
				{
					transform = transform.parent;
				}
			}
			while (this.root == null && transform.parent != null);
		}

		private void OnWillRenderObject()
		{
			this.ResetRoot();
			if (this.root == null)
			{
				return;
			}
			Material material = base.GetComponent<Renderer>().material;
			material.SetVector("_Position", Camera.current.worldToCameraMatrix.MultiplyPoint(base.transform.position));
			material.SetVector("_Scale", this.root.localScale);
		}
	}
}
