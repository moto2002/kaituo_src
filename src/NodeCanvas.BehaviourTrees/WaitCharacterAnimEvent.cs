using Assets.Scripts;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("✫ GOG/Decorator/Animation"), Name("Wait animation event")]
	public class WaitCharacterAnimEvent : BTDecorator
	{
		public BBParameter<RpgCharacter> Character;

		public string EventName;

		private bool triggered;

		private bool inited;

		private DateTime startTime;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (!this.inited)
			{
				this.inited = true;
				RpgCharacter value = this.Character.value;
				CharacterAnimator expr_24 = value.Animator;
				expr_24.OnAnimationEvent = (Action<CharacterAnimator, string>)Delegate.Combine(expr_24.OnAnimationEvent, new Action<CharacterAnimator, string>(this.OnEvent));
				this.startTime = DateTime.Now;
			}
			if (this.triggered)
			{
				return base.decoratedConnection.Execute(agent, blackboard);
			}
			if ((DateTime.Now - this.startTime).TotalSeconds > 10.0)
			{
				string msg = string.Format("wait character({0}) {1} anim event over 10s.", this.Character.value.name, this.EventName);
				this.startTime = DateTime.Now;
				DebugConsole.Log(msg);
			}
			return Status.Running;
		}

		protected override void OnReset()
		{
			this.triggered = false;
			this.inited = false;
			RpgCharacter value = this.Character.value;
			CharacterAnimator expr_20 = value.Animator;
			expr_20.OnAnimationEvent = (Action<CharacterAnimator, string>)Delegate.Remove(expr_20.OnAnimationEvent, new Action<CharacterAnimator, string>(this.OnEvent));
			this.startTime = DateTime.MinValue;
		}

		private void OnEvent(CharacterAnimator arg1, string arg2)
		{
			if (arg2 == this.EventName)
			{
				this.EndWait();
			}
		}

		private void EndWait()
		{
			this.triggered = true;
			RpgCharacter value = this.Character.value;
			CharacterAnimator expr_19 = value.Animator;
			expr_19.OnAnimationEvent = (Action<CharacterAnimator, string>)Delegate.Remove(expr_19.OnAnimationEvent, new Action<CharacterAnimator, string>(this.OnEvent));
		}
	}
}
