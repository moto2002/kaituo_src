using Assets.Tools.Script.Caller;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using XQ.Framework.Lua;

namespace XQ.Game.Util.Unity
{
	public class UnitySceneManager
	{
		public static float LoadingProgress;

		private static AsyncOperation loadingAsyncOperation;

		private static string loadingSceneName;

		public static string GetCurrSceneName()
		{
			return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
		}

		public static void LoadScene(string sceneName)
		{
			GameManager.ClearOldSceneLuaData();
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
			UnitySceneManager.SetActiveSceneDelayFrame(sceneName);
			FrameCall.DelayFrame(new Action(UnitySceneManager.GC), 2);
		}

		public static void LoadSceneAdd(string sceneName)
		{
			GameManager.ClearOldSceneLuaData();
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
			UnitySceneManager.SetActiveSceneDelayFrame(sceneName);
			FrameCall.DelayFrame(new Action(UnitySceneManager.GC), 2);
		}

		public static void LoadSceneAsync(string sceneName)
		{
			GameManager.ClearOldSceneLuaData();
			UnitySceneManager.loadingSceneName = sceneName;
			UnitySceneManager.loadingAsyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
			UnitySceneManager.LoadingProgress = 0f;
			FrameCall.Call(new Func<bool>(UnitySceneManager.CheckLoadingComplete));
		}

		public static void LoadSceneAsyncAdd(string sceneName)
		{
			GameManager.ClearOldSceneLuaData();
			UnitySceneManager.loadingSceneName = sceneName;
			UnitySceneManager.loadingAsyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			UnitySceneManager.LoadingProgress = 0f;
			FrameCall.Call(new Func<bool>(UnitySceneManager.CheckLoadingComplete));
		}

		public static void SetActiveScene(string sceneName)
		{
			UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName));
		}

		public static void SetActiveSceneDelayFrame(string sceneName)
		{
			FrameCall.DelayFrame(delegate
			{
				UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName));
			});
		}

		public static void UnloadScene(string sceneName)
		{
			UnityEngine.SceneManagement.SceneManager.UnloadScene(sceneName);
		}

		public static void GC()
		{
			GameManager.GC(true);
		}

		private static bool CheckLoadingComplete()
		{
			UnitySceneManager.LoadingProgress = UnitySceneManager.loadingAsyncOperation.progress;
			if (UnitySceneManager.loadingAsyncOperation.isDone)
			{
				UnitySceneManager.LoadingProgress = 1f;
				UnitySceneManager.SetActiveScene(UnitySceneManager.loadingSceneName);
				UnitySceneManager.loadingSceneName = null;
				UnitySceneManager.loadingAsyncOperation = null;
				FrameCall.DelayFrame(new Action(UnitySceneManager.GC), 2);
				return false;
			}
			return true;
		}
	}
}
