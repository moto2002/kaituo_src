using ParadoxNotion.Services;
using System;
using System.Collections;
using System.Diagnostics;

namespace NodeCanvas.DialogueTrees
{
	public static class StatementProcessor
	{
		public static void ProcessStatement(IStatement statement, IDialogueActor actor, Action finishCallback)
		{
			MonoManager.current.StartCoroutine(StatementProcessor.Internal_ProcessStatement(statement, actor, finishCallback));
		}

		[DebuggerHidden]
		private static IEnumerator Internal_ProcessStatement(IStatement statement, IDialogueActor actor, Action finishCallback)
		{
			StatementProcessor.<Internal_ProcessStatement>c__Iterator1D <Internal_ProcessStatement>c__Iterator1D = new StatementProcessor.<Internal_ProcessStatement>c__Iterator1D();
			<Internal_ProcessStatement>c__Iterator1D.actor = actor;
			<Internal_ProcessStatement>c__Iterator1D.statement = statement;
			<Internal_ProcessStatement>c__Iterator1D.finishCallback = finishCallback;
			<Internal_ProcessStatement>c__Iterator1D.<$>actor = actor;
			<Internal_ProcessStatement>c__Iterator1D.<$>statement = statement;
			<Internal_ProcessStatement>c__Iterator1D.<$>finishCallback = finishCallback;
			return <Internal_ProcessStatement>c__Iterator1D;
		}
	}
}
