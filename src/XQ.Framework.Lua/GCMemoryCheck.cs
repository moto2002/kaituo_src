using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace XQ.Framework.Lua
{
	internal class GCMemoryCheck : MonoBehaviour
	{
		internal enum GCStepType
		{
			Ready,
			Start,
			Stop
		}

		private struct SaveData
		{
			public MonoBehaviour mb;

			public PrefabReleaseInfo PrefabInfo;

			public void Clear()
			{
				this.mb = null;
				this.PrefabInfo = null;
			}
		}

		public GCMemoryCheck.GCStepType GCType = GCMemoryCheck.GCStepType.Stop;

		private readonly Queue<GCMemoryCheck.SaveData> needAdd = new Queue<GCMemoryCheck.SaveData>();

		private int frame;

		private static GCMemoryCheck gccheck;

		protected void Awake()
		{
			GCMemoryCheck.gccheck = this;
			base.enabled = false;
			base.StartCoroutine("Check");
		}

		protected void Update()
		{
			if (this.GCType == GCMemoryCheck.GCStepType.Stop)
			{
				base.enabled = false;
				return;
			}
			if (this.frame < Time.frameCount)
			{
				this.CheckClearMemory();
				this.frame = Time.frameCount + 1;
			}
		}

		public static void StartGCCheck()
		{
			if (!GCMemoryCheck.gccheck)
			{
				return;
			}
			GCMemoryCheck.gccheck.GCType = GCMemoryCheck.GCStepType.Ready;
			if (GCMemoryCheck.gccheck.enabled)
			{
				return;
			}
			GCMemoryCheck.gccheck.frame = Time.frameCount + 1;
			GCMemoryCheck.gccheck.enabled = true;
		}

		public void AddData(MonoBehaviour mb, PrefabReleaseInfo info)
		{
			this.needAdd.Enqueue(new GCMemoryCheck.SaveData
			{
				mb = mb,
				PrefabInfo = info
			});
		}

		private void CheckClearMemory()
		{
			GCMemoryCheck.GCStepType gCType = this.GCType;
			if (gCType != GCMemoryCheck.GCStepType.Ready)
			{
				if (gCType == GCMemoryCheck.GCStepType.Start)
				{
					this.GCType = GCMemoryCheck.GCStepType.Stop;
					GameManager.GC(false);
					Resources.UnloadUnusedAssets();
				}
			}
			else
			{
				this.GCType = GCMemoryCheck.GCStepType.Start;
			}
		}

		[DebuggerHidden]
		private IEnumerator Check()
		{
			GCMemoryCheck.<Check>c__Iterator6 <Check>c__Iterator = new GCMemoryCheck.<Check>c__Iterator6();
			<Check>c__Iterator.<>f__this = this;
			return <Check>c__Iterator;
		}
	}
}
