using Assets.Migration.Scripts.Action;
using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Camera"), Name("Move follow target camera")]
	public class MoveFollowCamera : DevisableAction
	{
		public Vector3 MoveDistance;

		public float MoveTime;

		public bool IgnoreTimeScale;

		private DateTime startDataTime;

		private Vector3 moveSpeed;

		private float RunTime
		{
			get
			{
				if (this.IgnoreTimeScale)
				{
					return (float)(DateTime.Now - this.startDataTime).TotalSeconds;
				}
				return base.elapsedTime;
			}
		}

		protected override void OnExecute()
		{
			if (this.IgnoreTimeScale)
			{
				this.startDataTime = DateTime.Now;
			}
			this.moveSpeed = this.MoveDistance / this.MoveTime;
		}

		protected override void OnUpdate()
		{
			float runTime = this.RunTime;
			TargetFollowTool component = Main3DCamera.Instance.Level1.GetComponent<TargetFollowTool>();
			if (component == null)
			{
				base.EndAction();
			}
			else if (runTime <= this.MoveTime)
			{
				component.Offset = runTime * this.moveSpeed;
			}
			else
			{
				component.Offset = this.MoveTime * this.moveSpeed;
				base.EndAction();
			}
		}
	}
}
