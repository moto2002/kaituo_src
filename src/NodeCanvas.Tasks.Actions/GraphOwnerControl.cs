using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility"), Description("Start, Resume, Pause, Stop a GraphOwner's behaviour")]
	public class GraphOwnerControl : ActionTask<GraphOwner>
	{
		public enum Control
		{
			StartBehaviour,
			StopBehaviour,
			PauseBehaviour
		}

		public GraphOwnerControl.Control control;

		public bool waitActionFinish = true;

		private bool isFinished;

		protected override string info
		{
			get
			{
				return base.agentInfo + "." + this.control.ToString();
			}
		}

		protected override void OnExecute()
		{
			if (this.control == GraphOwnerControl.Control.StartBehaviour)
			{
				this.isFinished = false;
				if (this.waitActionFinish)
				{
					base.agent.StartBehaviour(delegate
					{
						this.isFinished = true;
					});
				}
				else
				{
					base.agent.StartBehaviour();
					base.EndAction();
				}
			}
		}

		protected override void OnUpdate()
		{
			if (this.control == GraphOwnerControl.Control.StartBehaviour)
			{
				if (this.isFinished)
				{
					base.EndAction();
				}
			}
			else if (this.control == GraphOwnerControl.Control.StopBehaviour)
			{
				base.agent.StopBehaviour();
				base.EndAction();
			}
			else if (this.control == GraphOwnerControl.Control.PauseBehaviour)
			{
				base.agent.PauseBehaviour();
				base.EndAction();
			}
		}
	}
}
