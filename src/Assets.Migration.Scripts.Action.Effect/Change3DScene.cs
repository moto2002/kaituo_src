using Assets.Scripts.Action.Core;
using Assets.Scripts.Tools.Component;
using Assets.Tools.Script.Go;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("✫ GOG/Effect"), Name("Change Scene Background")]
	public class Change3DScene : DevisableAction
	{
		public enum Change3DSceneType
		{
			ToPrefab,
			ToDefault
		}

		private static Dictionary<string, GameObject> anotherDimensions = new Dictionary<string, GameObject>();

		public Change3DScene.Change3DSceneType Type;

		public GameObject Prefab;

		public static void CloseAllDimensions()
		{
			foreach (GameObject current in Change3DScene.anotherDimensions.Values)
			{
				current.gameObject.SetActive(false);
			}
		}

		public static void ClearAllDimensions()
		{
			foreach (GameObject current in Change3DScene.anotherDimensions.Values)
			{
				UnityEngine.Object.Destroy(current.gameObject);
			}
			Change3DScene.anotherDimensions.Clear();
		}

		protected override void OnExecute()
		{
			try
			{
				Camera camera = Main3DCamera.Instance.Camera;
				if (this.Type == Change3DScene.Change3DSceneType.ToPrefab)
				{
					if (Change3DScene.anotherDimensions.ContainsKey(this.Prefab.name) && Change3DScene.anotherDimensions[this.Prefab.name] != null)
					{
						Change3DScene.anotherDimensions[this.Prefab.name].SetActive(true);
					}
					else
					{
						GameObject secondaryHost = ParasiticComponent.GetSecondaryHost("AnotherDimension");
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Prefab);
						gameObject.transform.parent = secondaryHost.transform;
						gameObject.transform.position = Vector3.zero;
						Change3DScene.anotherDimensions[this.Prefab.name] = gameObject;
					}
					camera.cullingMask = camera.cullingMask.RemoveFromMask(new string[]
					{
						UnityLayerDefine.Scene3D.ToString()
					});
					camera.cullingMask = camera.cullingMask.AddToMask(new string[]
					{
						UnityLayerDefine.SceneDimension3D.ToString()
					});
				}
				else
				{
					foreach (KeyValuePair<string, GameObject> current in Change3DScene.anotherDimensions)
					{
						current.Value.SetActive(false);
					}
					camera.cullingMask = camera.cullingMask.RemoveFromMask(new string[]
					{
						UnityLayerDefine.SceneDimension3D.ToString()
					});
					camera.cullingMask = camera.cullingMask.AddToMask(new string[]
					{
						UnityLayerDefine.Scene3D.ToString()
					});
				}
				base.EndAction();
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
				DebugConsole.Log(new object[]
				{
					"Main3DCamera",
					Main3DCamera.Instance
				});
				DebugConsole.Log(new object[]
				{
					"Prefab",
					this.Prefab
				});
				throw ex;
			}
		}
	}
}
