using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.Framework.Lua
{
	public class LoadAssetBundleData
	{
		public struct DependRefInfo
		{
			public string PKGFile;

			public string DepName;
		}

		public string MainPKGFile;

		public string AssetName;

		public bool IsPrefab;

		public UnityEngine.Object UseToGameObject;

		public UnityEngine.Object NewObject;

		public List<LoadAssetBundleData.DependRefInfo> DependResRefList;

		public void Dispose()
		{
			this.NewObject = null;
			ResourceManager resManager = GameManager.ResManager;
			if (resManager.pkgRefList.Count == 0)
			{
				return;
			}
			AssetBundleRef assetBundleRef;
			if (!this.DependResRefList.IsNullOrEmpty<LoadAssetBundleData.DependRefInfo>())
			{
				for (int i = 0; i < this.DependResRefList.Count; i++)
				{
					LoadAssetBundleData.DependRefInfo dependRefInfo = this.DependResRefList[i];
					assetBundleRef = resManager.pkgRefList[dependRefInfo.PKGFile];
					assetBundleRef.Decrement(dependRefInfo.DepName);
				}
				this.DependResRefList.Clear();
			}
			assetBundleRef = resManager.pkgRefList[this.MainPKGFile];
			assetBundleRef.Decrement(null);
		}

		public void UnLoadLoadAsset()
		{
			this.NewObject = null;
		}
	}
}
