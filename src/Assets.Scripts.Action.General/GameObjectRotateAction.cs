using Assets.Scripts.Action.Core;
using Assets.Tools.Script.Event;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;
using UnityEngine;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Action.General
{
	[Category("obsolete/General"), Name("GameObject rotate")]
	public class GameObjectRotateAction : DevisableAction
	{
		public BBParameter<GameObject> Target;

		public bool RotateX;

		public BBParameter<float> ToX;

		public bool RotateY;

		public BBParameter<float> ToY;

		public bool RotateZ;

		public BBParameter<float> ToZ;

		public bool IsLocal;

		public iTween.EaseType EaseType;

		public bool IgnoreTimeScale;

		public float Time;

		private NativeEventToSignal eventToSignal;

		protected override void OnExecute()
		{
			GameObject value = this.Target.value;
			if (this.Time > 0f)
			{
				this.eventToSignal = value.AddComponent<NativeEventToSignal>();
				this.eventToSignal.OnNativeEvent.AddEventListener(new Action(this.OnRotateEnd));
				Hashtable hashtable = iTween.Hash(new object[]
				{
					"time",
					this.Time,
					"islocal",
					this.IsLocal,
					"easetype",
					this.EaseType,
					"ignoretimescale",
					this.IgnoreTimeScale,
					"oncompletetarget",
					value,
					"oncomplete",
					"UnityNativeEvent"
				});
				if (this.RotateX)
				{
					hashtable.Add("x", this.ToX.value);
				}
				if (this.RotateY)
				{
					hashtable.Add("y", this.ToY.value);
				}
				if (this.RotateZ)
				{
					hashtable.Add("z", this.ToZ.value);
				}
				UDebug.Debug(hashtable);
				iTween.RotateTo(value, hashtable);
			}
			else
			{
				Vector3 eulerAngles = ((!this.IsLocal) ? value.transform.rotation : value.transform.localRotation).eulerAngles;
				if (this.RotateX)
				{
					eulerAngles.x = this.ToX.value;
				}
				if (this.RotateY)
				{
					eulerAngles.y = this.ToY.value;
				}
				if (this.RotateZ)
				{
					eulerAngles.z = this.ToZ.value;
				}
				Quaternion quaternion = Quaternion.Euler(eulerAngles);
				if (this.IsLocal)
				{
					value.transform.localRotation = quaternion;
				}
				else
				{
					value.transform.rotation = quaternion;
				}
				base.EndAction();
			}
		}

		private void OnRotateEnd()
		{
			UnityEngine.Object.Destroy(this.eventToSignal);
			base.EndAction();
		}
	}
}
