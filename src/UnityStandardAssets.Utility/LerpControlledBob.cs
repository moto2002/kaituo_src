using System;
using System.Collections;
using System.Diagnostics;

namespace UnityStandardAssets.Utility
{
	[Serializable]
	public class LerpControlledBob
	{
		public float BobDuration;

		public float BobAmount;

		private float m_Offset;

		public float Offset()
		{
			return this.m_Offset;
		}

		[DebuggerHidden]
		public IEnumerator DoBobCycle()
		{
			LerpControlledBob.<DoBobCycle>c__Iterator6 <DoBobCycle>c__Iterator = new LerpControlledBob.<DoBobCycle>c__Iterator6();
			<DoBobCycle>c__Iterator.<>f__this = this;
			return <DoBobCycle>c__Iterator;
		}
	}
}
