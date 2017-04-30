using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Core.Compoment
{
	public class SimplePopupBox : MonoBehaviour
	{
		private UITweener[] tweeners;

		protected virtual void OnShow()
		{
			this.tweeners = base.gameObject.GetComponentsInChildren<UITweener>();
			if (this.tweeners != null && this.tweeners.Length > 0)
			{
				UITweener[] array = this.tweeners;
				for (int i = 0; i < array.Length; i++)
				{
					UITweener uITweener = array[i];
					uITweener.enabled = true;
					uITweener.ResetToBeginning();
					uITweener.PlayForward();
				}
			}
		}

		protected void Dispose()
		{
			try
			{
				this.PreDispose();
				if (this.tweeners == null || this.tweeners.Length == 0)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				else
				{
					bool flag = true;
					UITweener[] array = this.tweeners;
					for (int i = 0; i < array.Length; i++)
					{
						UITweener uITweener = array[i];
						if (flag)
						{
							uITweener.onFinished.Clear();
							uITweener.onFinished.Add(new EventDelegate(delegate
							{
								UnityEngine.Object.Destroy(base.gameObject);
							}));
							flag = false;
						}
						uITweener.PlayReverse();
					}
				}
			}
			catch (Exception)
			{
			}
		}

		protected virtual void PreDispose()
		{
		}
	}
}
