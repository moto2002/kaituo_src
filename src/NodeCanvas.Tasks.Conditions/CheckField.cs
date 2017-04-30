using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Script Control/Common"), Description("Check a field on a script and return if it's equal or not to a value")]
	public class CheckField : ConditionTask
	{
		[SerializeField]
		private BBParameter checkValue;

		[SerializeField]
		private Type targetType;

		[SerializeField]
		private string fieldName;

		[SerializeField]
		private CompareMethod comparison;

		private FieldInfo field;

		public override Type agentType
		{
			get
			{
				return (this.targetType == null) ? typeof(Transform) : this.targetType;
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
				return string.Format("{0}.{1}{2}", base.agentInfo, this.fieldName, (this.checkValue.varType != typeof(bool)) ? (OperationTools.GetCompareString(this.comparison) + this.checkValue.ToString()) : string.Empty);
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

		protected override bool OnCheck()
		{
			if (this.checkValue.varType == typeof(float))
			{
				return OperationTools.Compare((float)this.field.GetValue(base.agent), (float)this.checkValue.value, this.comparison, 0.05f);
			}
			if (this.checkValue.varType == typeof(int))
			{
				return OperationTools.Compare((int)this.field.GetValue(base.agent), (int)this.checkValue.value, this.comparison);
			}
			return object.Equals(this.field.GetValue(base.agent), this.checkValue.value);
		}
	}
}
