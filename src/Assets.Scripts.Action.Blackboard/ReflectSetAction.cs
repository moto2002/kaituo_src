using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Reflection;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("obsolete/Blackboard"), Name("Publish value")]
	public class ReflectSetAction : ActionTask
	{
		public BBParameter<object> Source;

		public BBParameter<object> Target;

		public string[] FieldNames;

		protected override void OnExecute()
		{
			if (this.Source == null || this.Source.value == null || this.Target == null || this.FieldNames == null || this.FieldNames.Length == 0)
			{
				base.EndAction();
				return;
			}
			object value = this.Source.value;
			object obj = value;
			for (int i = 0; i < this.FieldNames.Length; i++)
			{
				string name = this.FieldNames[i];
				Type type = obj.GetType();
				FieldInfo field = type.GetField(name);
				obj = field.GetValue(obj);
			}
			this.Target.value = obj;
			base.EndAction();
		}
	}
}
