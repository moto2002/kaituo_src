using System;

namespace Assets.Tools.Script.Net.Downloader.Tool
{
	public class UrlLoaderCreator
	{
		public static UrlLoader GetLoader(string url, int ver)
		{
			string[] array = url.Split(new char[]
			{
				'.'
			});
			string text = array[array.Length - 1];
			text = text.ToLower();
			string text2 = text;
			switch (text2)
			{
			case "unity3d":
				return new AssetBundleLoader(url, ver);
			case "assetbundle":
				return new AssetBundleLoader(url, ver);
			case "png":
				return new PictureLoader(url, ver);
			case "jpg":
				return new PictureLoader(url, ver);
			case "txt":
				return new TextLoader(url, ver);
			case "xml":
				return new TextLoader(url, ver);
			}
			return null;
		}
	}
}
