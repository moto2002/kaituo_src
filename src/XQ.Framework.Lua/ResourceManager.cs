using LuaFramework;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using XQ.Framework.Data;
using XQ.Framework.Lua.Utility;
using XQ.Framework.Utility.Debug;

namespace XQ.Framework.Lua
{
	public class ResourceManager : MonoBehaviour
	{
		internal static readonly List<PrefabReleaseInfo> prefabRelease = new List<PrefabReleaseInfo>();

		internal Dictionary<string, AssetBundleRef> pkgRefList = new Dictionary<string, AssetBundleRef>();

		internal List<LoadAssetBundleData> resourceData = new List<LoadAssetBundleData>();

		internal List<TextureCache> cacheTextureTTL = new List<TextureCache>();

		internal Dictionary<string, TextureCache> cacheTextureName = new Dictionary<string, TextureCache>();

		internal int textureSize;

		private static ResourceManager manager;

		private static GCMemoryCheck gcCheck;

		private Transform parent;

		private int frame;

		private Transform transCache;

		private Transform Parent
		{
			get
			{
				if (this.parent || this.parent == null)
				{
					GameObject gameObject = GameObject.FindWithTag("NGUICamera");
					if (gameObject)
					{
						this.parent = gameObject.transform.parent;
					}
				}
				return this.parent;
			}
		}

		protected void Awake()
		{
			ResourceManager.manager = this;
			this.transCache = base.transform;
			ResourceManager.gcCheck = base.gameObject.AddComponent<GCMemoryCheck>();
			base.InvokeRepeating("CheckLoadResource", 1f, 10f);
			base.enabled = false;
		}

		protected void Update()
		{
			if (this.frame == 0)
			{
				this.frame = Time.frameCount + 1;
			}
			if (this.frame < Time.frameCount)
			{
				this.frame = 0;
				for (int i = ResourceManager.prefabRelease.Count - 1; i >= 0; i--)
				{
					PrefabReleaseInfo prefabReleaseInfo = ResourceManager.prefabRelease[i];
					if (!prefabReleaseInfo.Script)
					{
						if (prefabReleaseInfo.HandDestroy)
						{
							prefabReleaseInfo.Act();
						}
						prefabReleaseInfo.Act = null;
						ResourceManager.prefabRelease.RemoveAt(i);
					}
				}
				base.enabled = false;
			}
		}

		protected void OnDestroy()
		{
			foreach (KeyValuePair<string, AssetBundleRef> current in this.pkgRefList)
			{
				current.Value.CloseHandle(true);
			}
			this.pkgRefList.Clear();
		}

		protected void CheckLoadResource()
		{
			if (this.resourceData.Count > 0)
			{
				for (int i = this.resourceData.Count - 1; i >= 0; i--)
				{
					LoadAssetBundleData loadAssetBundleData = this.resourceData[i];
					if (!loadAssetBundleData.UseToGameObject)
					{
						this.resourceData[i].Dispose();
						this.resourceData.RemoveAt(i);
					}
				}
			}
			if (this.textureSize > 102400)
			{
				int count = this.cacheTextureTTL.Count;
				this.cacheTextureTTL.Sort((TextureCache t1, TextureCache t2) => -t1.ttl.CompareTo(t2.ttl));
				for (int j = this.cacheTextureTTL.Count - 1; j >= 0; j--)
				{
					TextureCache textureCache = this.cacheTextureTTL[j];
					this.textureSize -= textureCache.textureSize;
					this.cacheTextureTTL.RemoveAt(j);
					this.cacheTextureName.Remove(textureCache.resName);
					textureCache.refFileHandle.Decrement(null);
					if (this.textureSize <= 102400)
					{
						break;
					}
				}
				DebugConsole.LogToChannel(78, string.Format("进行图片缓存回收，回收数量：{0}", count - this.cacheTextureTTL.Count));
			}
		}

		public static PrefabReleaseInfo SetGCPrefabRes(MonoBehaviour behaviour, Action destroyAct)
		{
			PrefabReleaseInfo prefabReleaseInfo = new PrefabReleaseInfo(behaviour, destroyAct);
			if (null != ResourceManager.gcCheck)
			{
				ResourceManager.gcCheck.AddData(behaviour, prefabReleaseInfo);
			}
			return prefabReleaseInfo;
		}

		public void StartGCPrefabRes(GCPrefabScript usePrefab)
		{
			if (this.transCache)
			{
				base.enabled = true;
			}
		}

		public static void Dispose(string name, string objectKey)
		{
			ResourceRef resRef = GameManager.GetResRef(name, null, true);
			if (resRef != null)
			{
				resRef.Clear(objectKey);
			}
		}

		public void ClearMemory(bool exec = false)
		{
			if (exec)
			{
				GameManager.GC(false);
				Resources.UnloadUnusedAssets();
			}
			else
			{
				GCMemoryCheck.StartGCCheck();
			}
		}

		public void CreatePanelAsync(bool isGridItem, LuaFunction callback, string panelName, params object[] args)
		{
			base.StartCoroutine(this.CreateAsync(isGridItem, callback, panelName, args));
		}

		public LuaTable CreatePanelSync(bool isGridItem, string panelName, params object[] args)
		{
			return this.CreateSync(isGridItem, panelName, args);
		}

		public LuaTable NewLuaTable(bool isGrid, string luaFileName, GameObject parentObject)
		{
			object[] array = GameManager.LuaManager.DoFile(luaFileName);
			if (array != null)
			{
				LuaTable luaTable = array[0] as LuaTable;
				if (null != parentObject)
				{
					LuaMonoBehaviour luaMonoBehaviour = parentObject.GetComponent<LuaMonoBehaviour>() ?? parentObject.AddComponent<LuaMonoBehaviour>();
					luaMonoBehaviour.AddItemTable = luaTable;
				}
				return luaTable;
			}
			UDebug.Error("不能用于全局table, file name: {0}", new object[]
			{
				luaFileName
			});
			return null;
		}

		public UnityEngine.Object LoadGameResource(string resName, bool instantiate, GameObject useToGameObject, LuaFunction callBack, bool lifeFollowUseObject, string langstr = null)
		{
			if (callBack != null)
			{
				base.StartCoroutine(ResourceManager.LoadResource(resName, instantiate, useToGameObject, callBack, lifeFollowUseObject, langstr));
				return null;
			}
			return ResourceManager.LoadResource(resName, instantiate, useToGameObject, lifeFollowUseObject, langstr);
		}

		[DebuggerHidden]
		private IEnumerator CreateAsync(bool isGridItem, LuaFunction callback, string panelName, params object[] args)
		{
			ResourceManager.<CreateAsync>c__Iterator4 <CreateAsync>c__Iterator = new ResourceManager.<CreateAsync>c__Iterator4();
			<CreateAsync>c__Iterator.panelName = panelName;
			<CreateAsync>c__Iterator.isGridItem = isGridItem;
			<CreateAsync>c__Iterator.args = args;
			<CreateAsync>c__Iterator.callback = callback;
			<CreateAsync>c__Iterator.<$>panelName = panelName;
			<CreateAsync>c__Iterator.<$>isGridItem = isGridItem;
			<CreateAsync>c__Iterator.<$>args = args;
			<CreateAsync>c__Iterator.<$>callback = callback;
			<CreateAsync>c__Iterator.<>f__this = this;
			return <CreateAsync>c__Iterator;
		}

		private LuaTable CreateSync(bool isGridItem, string panelName, params object[] args)
		{
			ABManifest resRef = GameManager.GetResRef(panelName, null, true);
			if (resRef == null)
			{
				return null;
			}
			GameObject gameObject = resRef.Panel;
			LuaTable result = null;
			if (null == gameObject)
			{
				LoadAssetBundleData loadAssetBundleData = ResourceManager.LoadBundle(panelName, null, false);
				gameObject = (loadAssetBundleData.NewObject as GameObject);
				gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				gameObject.name = panelName;
				gameObject.transform.parent = this.Parent;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = Vector3.zero;
				loadAssetBundleData.UnLoadLoadAsset();
				resRef.Panel = ((!isGridItem) ? gameObject : null);
				loadAssetBundleData.NewObject = gameObject;
				string text = gameObject.GetInstanceID().ToString();
				LuaTableInfo luaTableInfo = new LuaTableInfo();
				resRef.TableInfo.Add(text, luaTableInfo);
				LuaMonoBehaviour luaMonoBehaviour = gameObject.AddComponent<LuaMonoBehaviour>();
				bool closeIsDestroy = false;
				if (args != null)
				{
					object[] array = new object[args.Length + 1];
					array[0] = gameObject;
					for (int i = 0; i < args.Length; i++)
					{
						array[i + 1] = args[i];
					}
					object[] array2 = ResourceManager.CallFunction(text, panelName, "Init", array);
					if (array2 != null)
					{
						closeIsDestroy = (bool)array2[0];
					}
				}
				else
				{
					object[] array3 = ResourceManager.CallFunction(text, panelName, "Init", new object[]
					{
						gameObject
					});
					if (array3 != null)
					{
						closeIsDestroy = (bool)array3[0];
					}
				}
				luaMonoBehaviour.OnInit(loadAssetBundleData, closeIsDestroy, text, panelName);
				if (!isGridItem)
				{
					LuaFunction function = GameManager.LuaManager.GetFunction("setFrameworkTableInstance", true);
					if (null != function)
					{
						function.CallNoRet(new object[]
						{
							panelName,
							luaTableInfo.Table
						});
					}
				}
				result = luaTableInfo.Table;
			}
			else
			{
				gameObject.SetActive(true);
				LuaTableInfo luaTableInfo2;
				if (resRef.TableInfo.TryGetValue(gameObject.GetInstanceID().ToString(), out luaTableInfo2))
				{
					result = luaTableInfo2.Table;
				}
			}
			return result;
		}

		public static object[] CallFunction(string objectKey, string luaFileName, string methodName, params object[] args)
		{
			ResourceRef resRef = GameManager.GetResRef(luaFileName, null, true);
			if (resRef == null)
			{
				UDebug.Error("no file, name: {0}", new object[]
				{
					luaFileName
				});
				return null;
			}
			LuaManager luaManager = GameManager.LuaManager;
			LuaFunction luaFunction = null;
			string text = luaFileName + "." + methodName;
			LuaTableInfo luaTableInfo = resRef.GetLuaTableInfo(objectKey);
			if (null != luaTableInfo.Table)
			{
				try
				{
					luaFunction = ((!luaTableInfo.TabelIsGlobal) ? luaTableInfo.Table.RawGetLuaFunction(methodName) : luaManager.GetFunction(text, false));
				}
				catch
				{
					ResourceManager.Dispose(luaFileName, objectKey);
				}
			}
			if (null == luaFunction)
			{
				object[] array = luaManager.DoFile(luaFileName);
				if (array != null)
				{
					luaTableInfo.Table = (array[0] as LuaTable);
					luaTableInfo.TabelIsGlobal = false;
					luaTableInfo.LuaName = luaFileName;
					luaFunction = luaTableInfo.Table.RawGetLuaFunction(methodName);
				}
				else
				{
					luaTableInfo.Table = luaManager.GetTable(luaFileName, true);
					luaTableInfo.TabelIsGlobal = true;
					luaTableInfo.LuaName = luaFileName;
					luaFunction = luaTableInfo.Table.RawGetLuaFunction(text);
					luaTableInfo.SetFunctions(luaFunction);
				}
			}
			object[] result = luaFunction.Call(args);
			if (!luaTableInfo.TabelIsGlobal)
			{
				luaFunction.Dispose();
			}
			return result;
		}

		[DebuggerHidden]
		private static IEnumerator LoadResource(string resName, bool instantiate, GameObject useToGameObject, LuaFunction callBack, bool lifeFollowUseObject, string langstr)
		{
			ResourceManager.<LoadResource>c__Iterator5 <LoadResource>c__Iterator = new ResourceManager.<LoadResource>c__Iterator5();
			<LoadResource>c__Iterator.resName = resName;
			<LoadResource>c__Iterator.instantiate = instantiate;
			<LoadResource>c__Iterator.useToGameObject = useToGameObject;
			<LoadResource>c__Iterator.lifeFollowUseObject = lifeFollowUseObject;
			<LoadResource>c__Iterator.langstr = langstr;
			<LoadResource>c__Iterator.callBack = callBack;
			<LoadResource>c__Iterator.<$>resName = resName;
			<LoadResource>c__Iterator.<$>instantiate = instantiate;
			<LoadResource>c__Iterator.<$>useToGameObject = useToGameObject;
			<LoadResource>c__Iterator.<$>lifeFollowUseObject = lifeFollowUseObject;
			<LoadResource>c__Iterator.<$>langstr = langstr;
			<LoadResource>c__Iterator.<$>callBack = callBack;
			return <LoadResource>c__Iterator;
		}

		private static UnityEngine.Object LoadResource(string resName, bool instantiate, GameObject useToGameObject, bool lifeFollowUseObject, string langstr)
		{
			bool flag = false;
			if (useToGameObject)
			{
				for (int i = 0; i < ResourceManager.manager.resourceData.Count; i++)
				{
					LoadAssetBundleData loadAssetBundleData = ResourceManager.manager.resourceData[i];
					if (loadAssetBundleData.UseToGameObject == useToGameObject && loadAssetBundleData.AssetName == resName)
					{
						flag = true;
						break;
					}
				}
			}
			LoadAssetBundleData loadAssetBundleData2 = ResourceManager.LoadBundle(resName, langstr, flag);
			if (instantiate)
			{
				UnityEngine.Object newObject = UnityEngine.Object.Instantiate(loadAssetBundleData2.NewObject);
				loadAssetBundleData2.UnLoadLoadAsset();
				loadAssetBundleData2.NewObject = newObject;
			}
			if (useToGameObject && !instantiate)
			{
				loadAssetBundleData2.UseToGameObject = useToGameObject;
			}
			else
			{
				loadAssetBundleData2.UseToGameObject = loadAssetBundleData2.NewObject;
			}
			if (!flag)
			{
				loadAssetBundleData2.AssetName = resName;
				ResourceManager.manager.resourceData.Add(loadAssetBundleData2);
			}
			return loadAssetBundleData2.NewObject;
		}

		private static LoadAssetBundleData LoadBundle(string abName, string langstr, bool sameRef = false)
		{
			ABManifest resRef = GameManager.GetResRef(abName, langstr, true);
			LoadAssetBundleData loadAssetBundleData = new LoadAssetBundleData
			{
				MainPKGFile = resRef.PKGFile
			};
			ResourceManager resManager = GameManager.ResManager;
			AssetBundleRef assetBundleRef;
			if (resRef.DependRefList != null)
			{
				loadAssetBundleData.DependResRefList = new List<LoadAssetBundleData.DependRefInfo>();
				for (int i = 0; i < resRef.DependRefList.Count; i++)
				{
					ABManifest.DependRef dependRef = resRef.DependRefList[i];
					if (!resManager.pkgRefList.TryGetValue(dependRef.PKGFile, out assetBundleRef))
					{
						assetBundleRef = new AssetBundleRef();
						resManager.pkgRefList.Add(dependRef.PKGFile, assetBundleRef);
					}
					assetBundleRef.TryLoadAssetBundle(UtilHelper.DataPath(resRef.UseDataDir, false, false) + dependRef.PKGFile);
					AssetBundleRef assetBundleRef2 = assetBundleRef.TryGetDepRefHandle(dependRef.DependName);
					if (assetBundleRef2.RefCnt == 0)
					{
						assetBundleRef.LoadAsset(dependRef.DependName);
					}
					loadAssetBundleData.DependResRefList.Add(new LoadAssetBundleData.DependRefInfo
					{
						PKGFile = dependRef.PKGFile,
						DepName = dependRef.DependName
					});
					assetBundleRef2.Increment();
					assetBundleRef.Increment();
				}
			}
			if (!resManager.pkgRefList.TryGetValue(resRef.PKGFile, out assetBundleRef))
			{
				assetBundleRef = new AssetBundleRef();
				resManager.pkgRefList.Add(resRef.PKGFile, assetBundleRef);
			}
			assetBundleRef.TryLoadAssetBundle(UtilHelper.DataPath(resRef.UseDataDir, false, false) + resRef.PKGFile);
			if (resRef.ResType == ResourceRef.ResFormat.Texture)
			{
				TextureCache textureCache = null;
				ResourceManager.manager.cacheTextureName.TryGetValue(abName, out textureCache);
				if (textureCache != null)
				{
					if (textureCache.refTexture)
					{
						loadAssetBundleData.NewObject = textureCache.refTexture;
					}
					else
					{
						loadAssetBundleData.NewObject = assetBundleRef.LoadAsset(resRef.FullFileName);
						Texture2D refTexture = loadAssetBundleData.NewObject as Texture2D;
						textureCache.refTexture = refTexture;
					}
					textureCache.UpdateTTL();
				}
				else
				{
					loadAssetBundleData.NewObject = assetBundleRef.LoadAsset(resRef.FullFileName);
					Texture2D texture2D = loadAssetBundleData.NewObject as Texture2D;
					textureCache = new TextureCache
					{
						refFileHandle = assetBundleRef,
						resName = abName,
						refTexture = texture2D,
						textureSize = UtilHelper.CalculateTextureSizeBytes(texture2D) / 1024
					};
					ResourceManager.manager.textureSize += textureCache.textureSize;
					ResourceManager.manager.cacheTextureTTL.Add(textureCache);
					ResourceManager.manager.cacheTextureName.Add(abName, textureCache);
				}
				if (!sameRef)
				{
					assetBundleRef.Increment();
				}
			}
			else
			{
				loadAssetBundleData.NewObject = assetBundleRef.LoadAsset(resRef.FullFileName);
				if (!sameRef)
				{
					assetBundleRef.Increment();
				}
			}
			loadAssetBundleData.IsPrefab = resRef.IsPrefab();
			return loadAssetBundleData;
		}
	}
}
