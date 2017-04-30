using Assets.Migration.Scripts.Action.Effect;
using Assets.Scripts.Action;
using Assets.Scripts.Tools.Component;
using Assets.Scripts.Tools.NGUI.Component;
using System;
using UnityEngine;

namespace Assets.Scripts.Performance
{
	public class NodeCanvasLuaTool
	{
		private static Color clearColor = new Color(0f, 0f, 0f, 0f);

		private static Vector3 beforePosition;

		private static Quaternion beforeQuaternion;

		public static void CacheBeforePlay()
		{
			NodeCanvasLuaTool.beforePosition = Main3DCamera.Instance.transform.position;
			NodeCanvasLuaTool.beforeQuaternion = Main3DCamera.Instance.transform.rotation;
		}

		public static void RestoreAfterPlay()
		{
			GameObject gameObject = GlobalGameObject.GlobalObjects["UpSceneFade"];
			Color color = gameObject.GetComponent<UISprite>().color;
			if ((double)color.a > 0.001)
			{
				TweenColor component = gameObject.GetComponent<TweenColor>();
				component.from = color;
				component.to = NodeCanvasLuaTool.clearColor;
				component.duration = 0.2f;
				component.ResetToBeginning();
				component.PlayForward();
			}
			Main3DCamera.Instance.PlayDefaultAnim();
			Main3DCamera.Instance.transform.position = NodeCanvasLuaTool.beforePosition;
			Main3DCamera.Instance.transform.rotation = NodeCanvasLuaTool.beforeQuaternion;
			Main3DCamera.Instance.Restore();
			ForegroundBehavior.Instance.SetBackgroundColor(NodeCanvasLuaTool.clearColor);
			Change3DScene.CloseAllDimensions();
		}

		public static void ClearNodeCanvas()
		{
			PlayPathMagic.ClearPath();
			Change3DScene.ClearAllDimensions();
		}
	}
}
