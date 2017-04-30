using NodeCanvas.Framework;
using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public abstract class DTNode : Node
	{
		[SerializeField]
		private string _actorName = "INSTIGATOR";

		public override string name
		{
			get
			{
				return string.Format("#{0} {1}", base.ID, this.actorName);
			}
		}

		public override int maxInConnections
		{
			get
			{
				return -1;
			}
		}

		public override int maxOutConnections
		{
			get
			{
				return 1;
			}
		}

		public sealed override Type outConnectionType
		{
			get
			{
				return typeof(DTConnection);
			}
		}

		public sealed override bool allowAsPrime
		{
			get
			{
				return true;
			}
		}

		public sealed override bool showCommentsBottom
		{
			get
			{
				return false;
			}
		}

		protected DialogueTree DLGTree
		{
			get
			{
				return (DialogueTree)base.graph;
			}
		}

		protected string actorName
		{
			get
			{
				if (!this.DLGTree.definedActorKeys.Contains(this._actorName))
				{
					return "<color=#d63e3e>*" + this._actorName + "*</color>";
				}
				return this._actorName;
			}
			set
			{
				if (this._actorName != value && !string.IsNullOrEmpty(value))
				{
					this._actorName = value;
				}
			}
		}

		protected IDialogueActor finalActor
		{
			get
			{
				return this.DLGTree.GetActorReference(this.actorName);
			}
		}
	}
}
