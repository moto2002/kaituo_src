using Assets.Scripts.Tool;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Reflection;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("obsolete/Blackboard"), Name("Publish all field")]
	public class ReflectVariable : ActionTask
	{
		public BBParameter<object> Source;

		public BBParameter<string> TargetPrefix;

		public BBParameter<string> TargetSuffix;

		protected override void OnExecute()
		{
			string value = this.TargetSuffix.value;
			string value2 = this.TargetPrefix.value;
			object value3 = this.Source.value;
			Type type = value3.GetType();
			FieldInfo[] fields = type.GetFields();
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				base.blackboard.SetOrAddValue(string.Format("{0}{1}{2}", value2, fieldInfo.Name, value), fieldInfo.GetValue(value3), fieldInfo.FieldType);
			}
			base.EndAction();
		}
	}
}
