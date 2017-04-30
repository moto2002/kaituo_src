using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Common"), Description("Set a variable on a script")]
	public class SetField : ActionTask
	{
		[SerializeField]
		private BBParameter setValue;

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
				return string.Format("{0}.{1} = {2}", base.agentInfo, this.fieldName, this.setValue);
			}
		}

		protected override string OnInit()
		{
			this.field = this.agentType.RTGetField(this.fieldName, false);
			if (this.field == null)
			{
				return "Missing Field Info";
			}
			return null;
		}

		protected override void OnExecute()
		{
			this.field.SetValue(base.agent, this.setValue.value);
			base.EndAction();
		}
	}
}
