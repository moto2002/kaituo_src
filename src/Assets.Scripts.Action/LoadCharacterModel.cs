using Assets.Scripts.Action.Core;
using Assets.Scripts.Tool;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Character"), Name("Load character model")]
	public class LoadCharacterModel : DevisableAction
	{
		public enum LoadPositionType
		{
			Position,
			Target
		}

		public BBParameter<string> LoadedBlackboardName;

		public BBParameter<int> InstanceId;

		public LoadCharacterModel.LoadPositionType PositionType;

		public BBParameter<GameObject> ToTarget;

		public Vector3 Offset;

		public Vector3 To;

		protected override void OnExecute()
		{
			CharacterModelLoader.LoadUnit(this.InstanceId.value, new Action<RpgCharacter>(this.OnCompleteHandler));
		}

		private void OnCompleteHandler(RpgCharacter obj)
		{
			Vector3 position;
			if (this.PositionType == LoadCharacterModel.LoadPositionType.Position)
			{
				position = this.To;
			}
			else
			{
				position = this.ToTarget.value.transform.position + this.Offset;
			}
			obj.transform.position = position;
			base.blackboard.SetOrAddValue(obj.name, obj);
			base.blackboard.SetOrAddValue(this.LoadedBlackboardName.value, obj);
			base.EndAction();
		}
	}
}
