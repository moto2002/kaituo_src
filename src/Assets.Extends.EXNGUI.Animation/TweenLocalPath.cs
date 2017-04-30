using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Animation
{
	public class TweenLocalPath : MonoBehaviour
	{
		public List<Vector3> nodes = new List<Vector3>
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f)
		};

		public UITweener.Style loopType;

		public float time;

		public TweenPosition positionTweener;

		private Vector3 _currNode;

		private Vector3 _toNode;

		private int _currIndex;

		private bool _forward;

		private iTween _iRotationTweener;

		private void Start()
		{
			this.Run();
		}

		public void Run()
		{
			if (this.positionTweener == null)
			{
				this.positionTweener = base.gameObject.AddComponent<TweenPosition>();
			}
			this.positionTweener.AddOnFinished(new EventDelegate.Callback(this.OneEnd));
			this._currIndex = 0;
			this._forward = true;
			this.RunToNext();
		}

		private void OnDrawGizmosSelected()
		{
			Vector3[] array = new Vector3[this.nodes.Count];
			int num = 0;
			foreach (Vector3 current in this.nodes)
			{
				array[num++] = base.gameObject.transform.parent.localToWorldMatrix.MultiplyPoint(current);
			}
			Gizmos.color = Color.blue;
			for (int i = 0; i < array.Length - 1; i++)
			{
				Gizmos.DrawLine(array[i], array[i + 1]);
			}
		}

		private void OneEnd()
		{
			if (this._forward)
			{
				this._currIndex++;
				if (this._currIndex == this.nodes.Count - 1)
				{
					if (this.loopType == UITweener.Style.Once)
					{
						this.End();
						return;
					}
					if (this.loopType == UITweener.Style.Loop)
					{
						this._currIndex = 0;
					}
					else if (this.loopType == UITweener.Style.PingPong)
					{
						this._forward = false;
					}
				}
			}
			else
			{
				this._currIndex--;
				if (this._currIndex == 0)
				{
					this._forward = true;
				}
			}
			this.RunToNext();
		}

		private void RunToNext()
		{
			this._currNode = this.nodes[this._currIndex];
			base.transform.localPosition = this._currNode;
			if (this._forward)
			{
				this._toNode = this.nodes[this._currIndex + 1];
			}
			else
			{
				this._toNode = this.nodes[this._currIndex - 1];
			}
			this.Retween();
		}

		private void Retween()
		{
			this.positionTweener.duration = base.transform.localPosition.DistanceTo(this._toNode) * this.time;
			this.positionTweener.from = base.transform.localPosition;
			this.positionTweener.to = this._toNode;
			this.positionTweener.ResetToBeginning();
			this.positionTweener.enabled = true;
			iTween.LookTo(base.gameObject, iTween.Hash(new object[]
			{
				"looktarget",
				base.transform.parent.localToWorldMatrix.MultiplyPoint(this._toNode),
				"id",
				"TweenLocalPath",
				"time",
				0.5f
			}));
			this._iRotationTweener = iTween.GetITween(base.gameObject, "TweenLocalPath");
		}

		public void Stop()
		{
			this.positionTweener.enabled = false;
			this._iRotationTweener.isRunning = false;
		}

		private void End()
		{
		}
	}
}
