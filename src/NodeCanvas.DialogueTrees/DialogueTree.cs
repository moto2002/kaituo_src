using NodeCanvas.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public class DialogueTree : Graph
	{
		[Serializable]
		public class ActorParameter
		{
			[SerializeField]
			private string _keyName;

			[SerializeField]
			private UnityEngine.Object _actorObject;

			private IDialogueActor _actor;

			public string name
			{
				get
				{
					return this._keyName;
				}
				set
				{
					this._keyName = value;
				}
			}

			public IDialogueActor actor
			{
				get
				{
					if (this._actor == null)
					{
						this._actor = (this._actorObject as IDialogueActor);
					}
					return this._actor;
				}
				set
				{
					this._actor = value;
					this._actorObject = (value as UnityEngine.Object);
				}
			}

			public ActorParameter()
			{
			}

			public ActorParameter(string name)
			{
				this.name = name;
			}

			public ActorParameter(string name, IDialogueActor actor)
			{
				this.name = name;
				this.actor = actor;
			}
		}

		public enum EndState
		{
			Failure,
			Success
		}

		[SerializeField]
		private List<DialogueTree.ActorParameter> _actorParameters = new List<DialogueTree.ActorParameter>();

		private DialogueTree.EndState _endState;

		private DTNode currentNode;

		public static DialogueTree currentDialogue;

		public static event Action<DialogueTree> OnDialogueStarted
		{
			[MethodImpl(32)]
			add
			{
				DialogueTree.OnDialogueStarted = (Action<DialogueTree>)Delegate.Combine(DialogueTree.OnDialogueStarted, value);
			}
			[MethodImpl(32)]
			remove
			{
				DialogueTree.OnDialogueStarted = (Action<DialogueTree>)Delegate.Remove(DialogueTree.OnDialogueStarted, value);
			}
		}

		public static event Action<DialogueTree> OnDialoguePaused
		{
			[MethodImpl(32)]
			add
			{
				DialogueTree.OnDialoguePaused = (Action<DialogueTree>)Delegate.Combine(DialogueTree.OnDialoguePaused, value);
			}
			[MethodImpl(32)]
			remove
			{
				DialogueTree.OnDialoguePaused = (Action<DialogueTree>)Delegate.Remove(DialogueTree.OnDialoguePaused, value);
			}
		}

		public static event Action<DialogueTree> OnDialogueFinished
		{
			[MethodImpl(32)]
			add
			{
				DialogueTree.OnDialogueFinished = (Action<DialogueTree>)Delegate.Combine(DialogueTree.OnDialogueFinished, value);
			}
			[MethodImpl(32)]
			remove
			{
				DialogueTree.OnDialogueFinished = (Action<DialogueTree>)Delegate.Remove(DialogueTree.OnDialogueFinished, value);
			}
		}

		public static event Action<SubtitlesRequestInfo> OnSubtitlesRequest
		{
			[MethodImpl(32)]
			add
			{
				DialogueTree.OnSubtitlesRequest = (Action<SubtitlesRequestInfo>)Delegate.Combine(DialogueTree.OnSubtitlesRequest, value);
			}
			[MethodImpl(32)]
			remove
			{
				DialogueTree.OnSubtitlesRequest = (Action<SubtitlesRequestInfo>)Delegate.Remove(DialogueTree.OnSubtitlesRequest, value);
			}
		}

		public static event Action<MultipleChoiceRequestInfo> OnMultipleChoiceRequest
		{
			[MethodImpl(32)]
			add
			{
				DialogueTree.OnMultipleChoiceRequest = (Action<MultipleChoiceRequestInfo>)Delegate.Combine(DialogueTree.OnMultipleChoiceRequest, value);
			}
			[MethodImpl(32)]
			remove
			{
				DialogueTree.OnMultipleChoiceRequest = (Action<MultipleChoiceRequestInfo>)Delegate.Remove(DialogueTree.OnMultipleChoiceRequest, value);
			}
		}

		public override Type baseNodeType
		{
			get
			{
				return typeof(DTNode);
			}
		}

		public override bool requiresAgent
		{
			get
			{
				return false;
			}
		}

		public override bool requiresPrimeNode
		{
			get
			{
				return true;
			}
		}

		public override bool autoSort
		{
			get
			{
				return true;
			}
		}

		public DialogueTree.EndState endState
		{
			get
			{
				return this._endState;
			}
			private set
			{
				this._endState = value;
			}
		}

		public List<DialogueTree.ActorParameter> actorParameters
		{
			get
			{
				return this._actorParameters;
			}
		}

		public List<string> definedActorKeys
		{
			get
			{
				List<string> list = (from r in this.actorParameters
				select r.name).ToList<string>();
				list.Insert(0, "INSTIGATOR");
				return list;
			}
		}

		protected override void OnGraphValidate()
		{
			base.blackboard = base.localBlackboard;
		}

		public IDialogueActor GetActorReference(string keyName)
		{
			if (keyName == "INSTIGATOR")
			{
				if (this.agent is IDialogueActor)
				{
					return (IDialogueActor)this.agent;
				}
				if (this.agent != null)
				{
					return new ProxyDialogueActor(this.agent.gameObject.name, this.agent.transform);
				}
				return new ProxyDialogueActor("null Instigator", null);
			}
			else
			{
				DialogueTree.ActorParameter actorParameter = this.actorParameters.Find((DialogueTree.ActorParameter r) => r.name == keyName);
				if (actorParameter != null && actorParameter.actor != null)
				{
					return actorParameter.actor;
				}
				Debug.Log(string.Format("<b>DialogueTree:</b> An actor entry '{0}' on DialogueTree has no reference. A dummy Actor will be used with the entry Key for name", keyName), this);
				return new ProxyDialogueActor(keyName, null);
			}
		}

		public void SetActorReference(string keyName, IDialogueActor actor)
		{
			DialogueTree.ActorParameter actorParameter = this.actorParameters.Find((DialogueTree.ActorParameter r) => r.name == keyName);
			if (actorParameter == null)
			{
				Debug.LogError(string.Format("There is no defined Actor key name '{0}'", keyName));
				return;
			}
			actorParameter.actor = actor;
		}

		public void SetActorReferences(Dictionary<string, IDialogueActor> actors)
		{
			foreach (KeyValuePair<string, IDialogueActor> pair in actors)
			{
				DialogueTree.ActorParameter actorParameter = this.actorParameters.Find((DialogueTree.ActorParameter r) => r.name == pair.Key);
				if (actorParameter == null)
				{
					Debug.LogWarning(string.Format("There is no defined Actor key name '{0}'. Seting actor skiped", pair.Key));
				}
				else
				{
					actorParameter.actor = pair.Value;
				}
			}
		}

		public void Continue(int index = 0)
		{
			if (!base.isRunning)
			{
				return;
			}
			if (index < 0 || index > this.currentNode.outConnections.Count - 1)
			{
				base.Stop();
				return;
			}
			this.EnterNode((DTNode)this.currentNode.outConnections[index].targetNode);
		}

		public void EnterNode(DTNode node)
		{
			this.currentNode = node;
			this.currentNode.Reset(false);
			if (this.currentNode.Execute(this.agent, this.blackboard) == Status.Error)
			{
				base.Stop();
			}
		}

		public static void RequestSubtitles(SubtitlesRequestInfo info)
		{
			if (DialogueTree.OnSubtitlesRequest != null)
			{
				DialogueTree.OnSubtitlesRequest(info);
			}
			else
			{
				Debug.LogWarning("<b>DialogueTree:</b> Subtitle Request event has no subscribers. Make sure to add the default '@DialogueGUI' prefab or create your own GUI.");
			}
		}

		public static void RequestMultipleChoices(MultipleChoiceRequestInfo info)
		{
			if (DialogueTree.OnMultipleChoiceRequest != null)
			{
				DialogueTree.OnMultipleChoiceRequest(info);
			}
			else
			{
				Debug.LogWarning("<b>DialogueTree:</b> Multiple Choice Request event has no subscribers. Make sure to add the default '@DialogueGUI' prefab or create your own GUI.");
			}
		}

		public void StartDialogue()
		{
			base.StartGraph(null, base.localBlackboard, null);
		}

		public void StartDialogue(IDialogueActor instigator)
		{
			base.StartGraph((!(instigator is Component)) ? instigator.transform : ((Component)instigator), base.localBlackboard, null);
		}

		public void StartDialogue(IDialogueActor instigator, Action callback)
		{
			base.StartGraph((!(instigator is Component)) ? instigator.transform : ((Component)instigator), base.localBlackboard, callback);
		}

		public void StartDialogue(Action callback)
		{
			base.StartGraph(null, base.localBlackboard, callback);
		}

		protected override void OnGraphStarted()
		{
			if (DialogueTree.currentDialogue != null)
			{
				Debug.LogWarning(string.Format("<b>DialogueTree:</b> Another Dialogue Tree named '{0}' is already running and will be stoped before starting new one '{1}'", DialogueTree.currentDialogue.name, base.name));
				DialogueTree.currentDialogue.Stop();
			}
			DialogueTree.currentDialogue = this;
			Debug.Log(string.Format("<b>DialogueTree:</b> Dialogue Started '{0}'", base.name));
			if (DialogueTree.OnDialogueStarted != null)
			{
				DialogueTree.OnDialogueStarted(this);
			}
			if (!(this.agent is IDialogueActor))
			{
				Debug.Log("<b>DialogueTree:</b> INSTIGATOR agent used in DialogueTree does not implement IDialogueActor. A dummy actor will be used.");
			}
			this.currentNode = ((this.currentNode == null) ? ((DTNode)base.primeNode) : this.currentNode);
			this.EnterNode(this.currentNode);
		}

		protected override void OnGraphStoped()
		{
			this.endState = (DialogueTree.EndState)((this.currentNode == null) ? Status.Success : this.currentNode.status);
			this.currentNode = null;
			DialogueTree.currentDialogue = null;
			Debug.Log(string.Format("<b>DialogueTree:</b> Dialogue Finished '{0}'", base.name));
			if (DialogueTree.OnDialogueFinished != null)
			{
				DialogueTree.OnDialogueFinished(this);
			}
		}

		protected override void OnGraphPaused()
		{
			Debug.Log(string.Format("<b>DialogueTree:</b> Dialogue Paused '{0}'", base.name));
			if (DialogueTree.OnDialoguePaused != null)
			{
				DialogueTree.OnDialoguePaused(this);
			}
		}
	}
}
