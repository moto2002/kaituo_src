using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace NodeCanvas.DialogueTrees.UI.Examples
{
	public class DefaultDialogueGUI : MonoBehaviour
	{
		public GUISkin skin;

		public bool showSubtitlesOverActor = true;

		private IDialogueActor currentActor;

		private string displayText;

		private MultipleChoiceRequestInfo currentOptions;

		private float timer;

		private void Awake()
		{
			DialogueTree.OnDialogueStarted += new Action<DialogueTree>(this.OnDialogueStarted);
			DialogueTree.OnDialoguePaused += new Action<DialogueTree>(this.OnDialoguePaused);
			DialogueTree.OnDialogueFinished += new Action<DialogueTree>(this.OnDialogueFinished);
			DialogueTree.OnSubtitlesRequest += new Action<SubtitlesRequestInfo>(this.OnSubtitlesRequest);
			DialogueTree.OnMultipleChoiceRequest += new Action<MultipleChoiceRequestInfo>(this.OnMultipleChoiceRequest);
			base.enabled = false;
		}

		private void OnDialogueStarted(DialogueTree dialogue)
		{
		}

		private void OnDialoguePaused(DialogueTree dialogue)
		{
			this.OnDialogueFinished(dialogue);
		}

		private void OnDialogueFinished(DialogueTree dialogue)
		{
			base.StopAllCoroutines();
			this.displayText = null;
			if (this.currentActor != null)
			{
				this.currentActor.speech = null;
			}
			this.currentOptions = null;
			base.StopCoroutine("GUICountDown");
			base.enabled = false;
		}

		private void OnSubtitlesRequest(SubtitlesRequestInfo info)
		{
			base.enabled = true;
			this.currentActor = info.actor;
			StatementProcessor.ProcessStatement(info.statement, info.actor, info.Continue);
		}

		private void OnMultipleChoiceRequest(MultipleChoiceRequestInfo optionsInfo)
		{
			base.enabled = true;
			this.currentOptions = optionsInfo;
			this.timer = optionsInfo.availableTime;
			base.StopCoroutine("GUICountDown");
			if (this.timer > 0f)
			{
				base.StartCoroutine("GUICountDown");
			}
		}

		[DebuggerHidden]
		private IEnumerator GUICountDown()
		{
			DefaultDialogueGUI.<GUICountDown>c__Iterator1A <GUICountDown>c__Iterator1A = new DefaultDialogueGUI.<GUICountDown>c__Iterator1A();
			<GUICountDown>c__Iterator1A.<>f__this = this;
			return <GUICountDown>c__Iterator1A;
		}

		private void OnGUI()
		{
			GUI.skin = this.skin;
			if (this.currentActor != null)
			{
				this.DoSubtitlesGUI();
			}
			if (this.currentOptions != null)
			{
				this.DoMultipleChoiceGUI();
			}
		}

		private void DoSubtitlesGUI()
		{
			this.displayText = this.currentActor.speech;
			if (string.IsNullOrEmpty(this.displayText))
			{
				return;
			}
			Vector2 vector = new GUIStyle("box").CalcSize(new GUIContent(this.displayText));
			Rect position = new Rect(0f, 0f, 0f, 0f);
			position.width = vector.x;
			position.height = vector.y;
			Vector3 vector2 = Camera.main.WorldToScreenPoint(this.currentActor.dialoguePosition);
			vector2.y = (float)Screen.height - vector2.y;
			if (this.showSubtitlesOverActor && Camera.main.rect.Contains(new Vector2(vector2.x / (float)Screen.width, vector2.y / (float)Screen.height)))
			{
				Vector2 center = position.center;
				center.x = vector2.x;
				center.y = vector2.y - position.height / 2f;
				position.center = center;
			}
			else
			{
				position = new Rect(10f, (float)(Screen.height - 60), (float)(Screen.width - 20), 50f);
				Rect position2 = new Rect(0f, 0f, 200f, 28f);
				Vector2 center2 = position2.center;
				center2.x = position.center.x;
				center2.y = position.y - 24f;
				position2.center = center2;
				GUI.Box(position2, this.currentActor.name);
				if (this.currentActor.portrait)
				{
					Rect position3 = new Rect(10f, (float)(Screen.height - this.currentActor.portrait.height - 70), (float)this.currentActor.portrait.width, (float)this.currentActor.portrait.height);
					GUI.DrawTexture(position3, this.currentActor.portrait);
				}
			}
			GUI.Box(position, this.displayText);
		}

		private void DoMultipleChoiceGUI()
		{
			float num = (this.timer <= 0f) ? 0f : 20f;
			foreach (IStatement current in this.currentOptions.options.Keys)
			{
				num += new GUIStyle("box").CalcSize(new GUIContent(current.text)).y;
			}
			Rect screenRect = new Rect(10f, (float)Screen.height - num - 10f, (float)(Screen.width - 20), num);
			GUILayout.BeginArea(screenRect);
			foreach (KeyValuePair<IStatement, int> current2 in this.currentOptions.options)
			{
				if (GUILayout.Button(current2.Key.text, new GUIStyle("box"), new GUILayoutOption[]
				{
					GUILayout.ExpandWidth(true)
				}))
				{
					base.StopCoroutine("GUICountDown");
					Action<int> selectOption = this.currentOptions.SelectOption;
					this.currentOptions = null;
					selectOption(current2.Value);
					return;
				}
			}
			if (this.timer > 0f)
			{
				float b = GUI.color.b;
				float g = GUI.color.g;
				b = this.timer / this.currentOptions.availableTime * 0.5f;
				g = this.timer / this.currentOptions.availableTime * 0.5f;
				GUI.color = new Color(1f, g, b);
				GUILayout.Box("...", new GUILayoutOption[]
				{
					GUILayout.Height(5f),
					GUILayout.Width(this.timer / this.currentOptions.availableTime * screenRect.width)
				});
			}
			GUILayout.EndArea();
		}
	}
}
