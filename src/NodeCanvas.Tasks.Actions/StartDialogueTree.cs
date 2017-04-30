using NodeCanvas.DialogueTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Task.AgentTypeAttribute(typeof(IDialogueActor)), Category("Dialogue"), Description("Starts a Dialogue Tree with specified agent for 'Instigator'"), Icon("Dialogue", false)]
	public class StartDialogueTree : ActionTask
	{
		[RequiredField]
		public BBParameter<DialogueTree> dialogueTree;

		public bool waitActionFinish = true;

		protected override string info
		{
			get
			{
				return string.Format("Start Dialogue {0}", this.dialogueTree.ToString());
			}
		}

		protected override void OnExecute()
		{
			IDialogueActor instigator = (IDialogueActor)base.agent;
			if (this.waitActionFinish)
			{
				this.dialogueTree.value.StartDialogue(instigator, delegate
				{
					base.EndAction();
				});
			}
			else
			{
				this.dialogueTree.value.StartDialogue(instigator);
				base.EndAction();
			}
		}
	}
}
