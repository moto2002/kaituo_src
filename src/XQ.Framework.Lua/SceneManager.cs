using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XQ.Framework.Lua
{
	public class SceneManager : MonoBehaviour
	{
		private AsyncOperation asyncOperation;

		internal Dictionary<string, Scenes> sceneRef = new Dictionary<string, Scenes>();

		internal static SceneManager manager;

		public void Awake()
		{
			SceneManager.manager = this;
			string name = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
			this.NewSceneManager(name).Init(name, new object[0]);
		}

		private Scenes NewSceneManager(string scene)
		{
			GameObject gameObject = new GameObject(scene + "_scene");
			Scenes scenes = gameObject.AddComponent<Scenes>();
			this.sceneRef.Add(scene, scenes);
			return scenes;
		}

		public void LoadControl(string controlName, params object[] args)
		{
			string name = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
			Scenes scenes = this.sceneRef[name];
			scenes.Init(name, controlName, args);
		}

		[DebuggerHidden]
		public IEnumerator LoadSceneControlModel(bool additive, string scene, LuaFunction callback, params object[] args)
		{
			SceneManager.<LoadSceneControlModel>c__Iterator7 <LoadSceneControlModel>c__Iterator = new SceneManager.<LoadSceneControlModel>c__Iterator7();
			<LoadSceneControlModel>c__Iterator.additive = additive;
			<LoadSceneControlModel>c__Iterator.scene = scene;
			<LoadSceneControlModel>c__Iterator.callback = callback;
			<LoadSceneControlModel>c__Iterator.args = args;
			<LoadSceneControlModel>c__Iterator.<$>additive = additive;
			<LoadSceneControlModel>c__Iterator.<$>scene = scene;
			<LoadSceneControlModel>c__Iterator.<$>callback = callback;
			<LoadSceneControlModel>c__Iterator.<$>args = args;
			<LoadSceneControlModel>c__Iterator.<>f__this = this;
			return <LoadSceneControlModel>c__Iterator;
		}

		[DebuggerHidden]
		public IEnumerator LoadSceneSceneModel(bool additive, string scene, params object[] args)
		{
			SceneManager.<LoadSceneSceneModel>c__Iterator8 <LoadSceneSceneModel>c__Iterator = new SceneManager.<LoadSceneSceneModel>c__Iterator8();
			<LoadSceneSceneModel>c__Iterator.additive = additive;
			<LoadSceneSceneModel>c__Iterator.scene = scene;
			<LoadSceneSceneModel>c__Iterator.args = args;
			<LoadSceneSceneModel>c__Iterator.<$>additive = additive;
			<LoadSceneSceneModel>c__Iterator.<$>scene = scene;
			<LoadSceneSceneModel>c__Iterator.<$>args = args;
			<LoadSceneSceneModel>c__Iterator.<>f__this = this;
			return <LoadSceneSceneModel>c__Iterator;
		}

		public void LoadScene(bool additive, string sceneName, LuaFunction callback, params object[] args)
		{
			IEnumerator arg_29_1;
			if (null == callback)
			{
				IEnumerator enumerator = this.LoadSceneSceneModel(additive, sceneName, args);
				arg_29_1 = enumerator;
			}
			else
			{
				arg_29_1 = this.LoadSceneControlModel(additive, sceneName, callback, args);
			}
			base.StartCoroutine(arg_29_1);
		}
	}
}
