using Assets.Tools.Script.Cameratool;
using System;

namespace Assets.Extends.EXNGUI.Cameratool
{
	public class OcclusionsRaycastHandleSprite : OcclusionsRaycastHandle
	{
		public UISprite sprite;

		private TweenAlpha _alphaTween;

		public override void IntoLinecast()
		{
			this.AddTween();
			this._alphaTween.from = this.sprite.alpha;
			this._alphaTween.to = 0.5f;
			this._alphaTween.ResetToBeginning();
			this._alphaTween.enabled = true;
		}

		public override void OutLinecast()
		{
			this.AddTween();
			this._alphaTween.from = this.sprite.alpha;
			this._alphaTween.to = 1f;
			this._alphaTween.ResetToBeginning();
			this._alphaTween.enabled = true;
		}

		private void AddTween()
		{
			if (this._alphaTween == null)
			{
				this._alphaTween = base.gameObject.AddComponent<TweenAlpha>();
				this._alphaTween.duration = 0.3f;
				this._alphaTween.enabled = false;
			}
		}
	}
}
