using Assets.Tools.Script.Event;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class RpgCharacter : MonoBehaviour
	{
		public string CharacterName = string.Empty;

		public int InstanceId = -1;

		public CharacterAnimator Animator;

		public GameObject[] AnchorPoints;

		public readonly Signal<CharacterAnimator> OnAnimEndSignal = new Signal<CharacterAnimator>();

		public readonly Signal<RpgCharacter> OnAttackSignal = new Signal<RpgCharacter>();

		public readonly Signal<RpgCharacter> OnMoveEndSignal = new Signal<RpgCharacter>();

		public Transform View;

		private Dictionary<string, GameObject> anchorPoints;

		public List<string> GetAminationNameList()
		{
			return this.Animator.GetAnimationNames();
		}

		public void MoveTo(Vector3 position, float time, string animationName = "Run")
		{
			if (animationName.IsNOTNullOrEmpty())
			{
				this.Animator.Play(animationName);
			}
			iTween.MoveTo(base.gameObject, iTween.Hash(new object[]
			{
				"time",
				time,
				"x",
				position.x,
				"y",
				position.y,
				"z",
				position.z,
				"easetype",
				iTween.EaseType.linear,
				"oncompletetarget",
				base.gameObject,
				"oncomplete",
				"MoveEndHandler"
			}));
		}

		public void TurnToLook(Vector3 target, float time)
		{
			iTween.LookTo(base.gameObject, iTween.Hash(new object[]
			{
				"looktarget",
				target,
				"axis",
				"y",
				"time",
				time
			}));
		}

		public GameObject GetAnchorPoint(string pointName)
		{
			if (this.anchorPoints == null)
			{
				this.anchorPoints = new Dictionary<string, GameObject>();
				for (int i = 0; i < this.AnchorPoints.Length; i++)
				{
					GameObject gameObject = this.AnchorPoints[i];
					this.anchorPoints.Add(gameObject.name, gameObject);
				}
			}
			GameObject result;
			this.anchorPoints.TryGetValue(pointName, out result);
			return result;
		}

		private void MoveEndHandler()
		{
			this.OnMoveEndSignal.Dispatch(this);
		}
	}
}
