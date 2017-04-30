using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Common"), Description("Get a variable of a script and save it to the blackboard")]
	public class GetField : ActionTask
	{
		[BlackboardOnly, SerializeField]
		private BBObjectParameter saveAs;

		[SerializeField]
		private Type targetType;

		[SerializeField]
		private string fieldName;

		private FieldInfo field;

		public override Type agentType
		{
			get
			{
				return this.targetType ?? typeof(Transform);
			}
		}

		protected override string info
		{
			get
			{
				if (string.IsNullOrEmpty(this.fieldName))
				{
					return "No Field Selected";
				}
				return string.Format("{0} = {1}.{2}", this.saveAs.ToString(), base.agentInfo, this.fieldName);
			}
		}

		protected override string OnInit()
		{
			this.field = this.agentType.RTGetField(this.fieldName, false);
			if (this.field == null)
			{
				return "Missing Field";
			}
			return null;
		}

		protected override void OnExecute()
		{
			this.saveAs.value = this.field.GetValue(base.agent);
			base.EndAction();
		}
	}
}
