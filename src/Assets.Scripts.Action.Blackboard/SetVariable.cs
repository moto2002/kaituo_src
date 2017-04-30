using Assets.Scripts.Action.Core;
using Assets.Scripts.Tool;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("obsolete/Blackboard"), Name("Set variable")]
	public class SetVariable : DevisableAction
	{
		public string FromVariable;

		public string ToVariable;

		protected override void OnExecute()
		{
			string varName = this.ReadVariableName(this.FromVariable);
			string name = this.ReadVariableName(this.ToVariable);
			Variable variable = base.blackboard.GetVariable(varName, null);
			if (variable != null)
			{
				base.blackboard.SetOrAddValue(name, variable.value);
			}
			else
			{
				base.blackboard.SetOrAddValue(name, null, typeof(object));
			}
			base.EndAction();
		}

		private string ReadVariableName(string source)
		{
			source = source.Replace('<', '>');
			string[] array = source.Split(new char[]
			{
				'<'
			});
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				if (i % 2 == 0)
				{
					text += text2;
				}
				else
				{
					text += base.blackboard.GetVariable(text2, null).value.ToString();
				}
			}
			UDebug.Debug(text, new object[0]);
			return text;
		}
	}
}
