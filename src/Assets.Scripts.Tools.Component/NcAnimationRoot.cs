using System;
using UnityEngine;
using XQ.Game.Util.Unity;

namespace Assets.Scripts.Tools.Component
{
	public class NcAnimationRoot : MonoBehaviour
	{
		public enum RotateType
		{
			Path,
			Floor
		}

		public bool ReplayOnEnable = true;

		public Vector3 Offset;

		[Obsolete("only floor now"), HideInInspector]
		public NcAnimationRoot.RotateType Rotate;

		public float AutoDisable;

		private NcEffectAniBehaviour[] childrenAnimations;

		private DelayDisable[] childrenDelayDisables;

		private NcPath[] ncPaths;

		private bool isStarted;

		public bool HasPath()
		{
			if (this.ncPaths == null)
			{
				this.ncPaths = base.GetComponentsInChildren<NcPath>();
			}
			return this.ncPaths != null && this.ncPaths.Length > 0;
		}

		public void SetRangeScale(float scale)
		{
			if (this.ncPaths != null)
			{
				for (int i = 0; i < this.ncPaths.Length; i++)
				{
					NcPath ncPath = this.ncPaths[i];
					ncPath.SetScale(scale);
				}
			}
		}

		public int GetRotateType()
		{
			return (int)this.Rotate;
		}

		private void Start()
		{
			this.TryPlay();
			this.isStarted = true;
		}

		private void OnEnable()
		{
			if (!this.isStarted)
			{
				return;
			}
			this.TryPlay();
		}

		private void TryPlay()
		{
			try
			{
				if (this.ReplayOnEnable)
				{
					if (this.childrenAnimations == null)
					{
						this.childrenAnimations = base.GetComponentsInChildren<NcEffectAniBehaviour>();
					}
					if (this.childrenDelayDisables == null)
					{
						this.childrenDelayDisables = base.GetComponentsInChildren<DelayDisable>();
					}
					if (this.childrenAnimations != null)
					{
						for (int i = 0; i < this.childrenAnimations.Length; i++)
						{
							NcEffectAniBehaviour ncEffectAniBehaviour = this.childrenAnimations[i];
							ncEffectAniBehaviour.gameObject.SetActive(true);
							ncEffectAniBehaviour.ResetAnimation();
						}
					}
					if (this.childrenDelayDisables != null)
					{
						for (int j = 0; j < this.childrenDelayDisables.Length; j++)
						{
							DelayDisable delayDisable = this.childrenDelayDisables[j];
							delayDisable.gameObject.SetActive(true);
						}
					}
				}
				if ((double)this.AutoDisable > 0.0001)
				{
					base.Invoke("CloseAnimationRoot", this.AutoDisable);
				}
			}
			catch (Exception ex)
			{
				DebugConsole.Log(base.gameObject.name);
				throw ex;
			}
		}

		private void OnDisable()
		{
			base.CancelInvoke("CloseAnimationRoot");
		}

		private void CloseAnimationRoot()
		{
			base.gameObject.SetActive(false);
		}
	}
}
