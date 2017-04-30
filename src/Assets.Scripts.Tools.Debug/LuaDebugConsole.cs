using Assets.Extends.EXTools.Debug.Console;
using Assets.Scripts.Tools.Lua;
using Assets.Tools.Script.Helper;
using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XQ.Framework.Lua;
using XQ.Framework.Utility.Debug;

namespace Assets.Scripts.Tools.Debug
{
	public class LuaDebugConsole : FullDebugConsole
	{
		public const int PublicChannel = -1;

		public bool DontDestroy;

		public bool StopEventWhenOpen;

		public List<int> NonUnityConsoleChannels = new List<int>();

		public List<LuaDebugConsoleMixConsoleChannel> MixConsoleChannels = new List<LuaDebugConsoleMixConsoleChannel>();

		private GameObject mask;

		private readonly Dictionary<UICamera, List<bool>> uiCameraEvents = new Dictionary<UICamera, List<bool>>();

		private readonly Dictionary<int, bool> nonUnityConsoleChannels = new Dictionary<int, bool>();

		private readonly Dictionary<int, List<int>> mixConsoleChannels = new Dictionary<int, List<int>>();

		private int mixChannel = -2;

		private int mixing;

		private readonly StringBuilder logStringBuilder = new StringBuilder();

		public static LuaManager LuaManager
		{
			get
			{
				return GameManager.LuaManager;
			}
		}

		public LuaDebugConsole()
		{
			ObjectAnalyseDisplayer objectAnalyseDisplayer = this.AnalyseDisplayer as ObjectAnalyseDisplayer;
			objectAnalyseDisplayer.RegisterObjectAnalyse(new LuaTableDebugAnalyse());
		}

		public override void LogToChannel(int channel, string msg)
		{
			if (!this.ActiveChannels.ContainsKey(channel))
			{
				base.AddActiveChannel(channel);
			}
			StringBuilder stringBuilder = this.logStringBuilder;
			stringBuilder.Clear();
			if (msg.Contains("stack traceback:"))
			{
				string[] array = msg.Split(new string[]
				{
					"stack traceback:"
				}, StringSplitOptions.None);
				stringBuilder.Append(this.ActiveChannels[channel]).AppendFormat("[{0}] ", Time.time.ToString("####.000")).Append(array[0]);
				this.ActiveChannels[channel] = stringBuilder.ToString();
				if (this.mixing == 0 && !this.nonUnityConsoleChannels.ContainsKey(channel) && channel >= 0 && channel <= 100)
				{
					UDebug.Debug(msg, new object[0]);
				}
			}
			else
			{
				stringBuilder.Append(this.ActiveChannels[channel]).AppendFormat("[{0}] ", Time.time.ToString("####.000")).Append(msg).Append("\r\n");
				this.ActiveChannels[channel] = stringBuilder.ToString();
				if (this.mixing == 0 && !this.nonUnityConsoleChannels.ContainsKey(channel) && channel >= 0 && channel <= 100)
				{
					UDebug.Debug(msg, new object[0]);
				}
			}
			if (channel >= 0)
			{
				if (this.mixing == 0)
				{
					this.LogToChannel(-1, msg);
				}
				List<int> list;
				bool flag = this.mixConsoleChannels.TryGetValue(channel, out list);
				if (flag)
				{
					foreach (int current in list)
					{
						if (current != channel)
						{
							this.mixing++;
							this.LogToChannel(current, msg);
							this.mixing--;
						}
					}
				}
			}
		}

		protected override void Update()
		{
			base.Update();
			DebugConsole.consoleImpl = this;
			if (!this.StopEventWhenOpen)
			{
				return;
			}
			if (base.ViewEnabled)
			{
				if (this.mask == null && UIRoot.list.Count > 0)
				{
					UICamera uICamera = null;
					foreach (UICamera current in UICamera.list)
					{
						if (uICamera == null || current.cachedCamera.depth > uICamera.cachedCamera.depth)
						{
							uICamera = current;
						}
					}
					UIRoot componentInParent = uICamera.GetComponentInParent<UIRoot>();
					this.mask = componentInParent.gameObject.AddEmptyGameObject();
					this.mask.name = "_LuaDebugConsoleMask";
					GameObject gameObject = this.mask.AddEmptyGameObject();
					UIPanel uIPanel = this.mask.AddComponent<UIPanel>();
					uIPanel.depth = 50000;
					UITexture uITexture = gameObject.AddComponent<UITexture>();
					uITexture.mainTexture = Texture2D.whiteTexture;
					uITexture.width = 2000;
					uITexture.height = 2000;
					uITexture.color = new Color(0f, 0f, 0f, 0.5f);
					uITexture.autoResizeBoxCollider = true;
					BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
					boxCollider.size = new Vector3(2000f, 2000f, 0f);
				}
				if (this.mask != null && !this.mask.activeSelf)
				{
					this.mask.SetActive(true);
				}
			}
			else if (this.mask != null && this.mask.activeSelf)
			{
				this.mask.SetActive(false);
			}
		}

		protected override void Awake()
		{
			if (Application.isPlaying && GameManager.LuaManager != null)
			{
				LuaTable table = GameManager.LuaManager.GetTable("DebugConsole", true);
				if (table != null)
				{
					LuaFunction luaFunction = table.GetLuaFunction("GetConsoleEnable");
					if (luaFunction != null && !(bool)luaFunction.Call(null)[0])
					{
						UnityEngine.Object.Destroy(this);
						return;
					}
				}
			}
			LuaDebugConsole luaDebugConsole = DebugConsole.consoleImpl as LuaDebugConsole;
			if (luaDebugConsole != null)
			{
				this.DontDestroy = (this.DontDestroy || luaDebugConsole.DontDestroy);
				if (luaDebugConsole.gameObject.name == "TestEntry")
				{
					UnityEngine.Object.Destroy(luaDebugConsole.gameObject);
				}
				else
				{
					UnityEngine.Object.Destroy(luaDebugConsole);
				}
			}
			base.Awake();
			if (this.DontDestroy)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			this.nonUnityConsoleChannels.Clear();
			foreach (int current in this.NonUnityConsoleChannels)
			{
				this.nonUnityConsoleChannels.Add(current, true);
			}
			foreach (LuaDebugConsoleMixConsoleChannel current2 in this.MixConsoleChannels)
			{
				this.mixChannel--;
				foreach (int current3 in current2.MixChannels)
				{
					List<int> list;
					this.mixConsoleChannels.TryGetValue(current3, out list);
					if (list == null)
					{
						list = new List<int>();
						this.mixConsoleChannels.Add(current3, list);
					}
					list.Add((current2.ToChannel <= 0) ? this.mixChannel : current2.ToChannel);
				}
			}
		}

		protected override void OnEnabledChange(bool enable)
		{
			if (!this.StopEventWhenOpen)
			{
				return;
			}
			if (enable)
			{
				foreach (UICamera current in UICamera.list)
				{
					this.uiCameraEvents[current] = new List<bool>
					{
						current.useController,
						current.useKeyboard,
						current.useMouse,
						current.useTouch
					};
					current.useController = false;
					current.useKeyboard = false;
					current.useMouse = false;
					current.useTouch = false;
				}
			}
			else
			{
				foreach (KeyValuePair<UICamera, List<bool>> current2 in this.uiCameraEvents)
				{
					UICamera key = current2.Key;
					List<bool> value = current2.Value;
					key.useController = value[0];
					key.useKeyboard = value[1];
					key.useMouse = value[2];
					key.useTouch = value[3];
				}
				this.uiCameraEvents.Clear();
			}
		}
	}
}
