using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Task.AgentTypeAttribute(typeof(IDialogueActor)), Category("Dialogue"), Icon("Dialogue", false)]
	public class Say : ActionTask
	{
		public Statement statement = new Statement("This is a dialogue text...");

		protected override string info
		{
			get
			{
				return string.Format("<i>' {0} '</i>", (this.statement.text.Length <= 30) ? this.statement.text : (this.statement.text.Substring(0, 30) + "..."));
			}
		}

		protected override void OnExecute()
		{
			SubtitlesRequestInfo info = new SubtitlesRequestInfo((IDialogueActor)base.agent, this.statement, new Action(base.EndAction));
			DialogueTree.RequestSubtitles(info);
		}
	}
}
