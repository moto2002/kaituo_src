using Assets.Scripts.Action.Core;
using Assets.Scripts.Tool;
using ParadoxNotion.Design;
using System;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Action.Blackboard
{
	[Category("obsolete/Blackboard"), Name("Set string variable")]
	public class SetStringVariable : DevisableAction
	{
		public string Value;

		public string ToVariable;

		protected override void OnExecute()
		{
			string value = this.ReadVariableName(this.Value);
			string name = this.ReadVariableName(this.ToVariable);
			base.blackboard.SetOrAddValue(name, value);
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
