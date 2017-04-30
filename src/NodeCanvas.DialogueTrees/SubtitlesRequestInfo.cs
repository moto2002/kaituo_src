using System;

namespace NodeCanvas.DialogueTrees
{
	public class SubtitlesRequestInfo
	{
		public readonly IDialogueActor actor;

		public readonly IStatement statement;

		public readonly Action Continue;

		public SubtitlesRequestInfo(IDialogueActor actor, IStatement statement, Action callback)
		{
			this.actor = actor;
			this.statement = statement;
			this.Continue = callback;
		}
	}
}
