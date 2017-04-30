using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace XQ.Game.Util.File
{
	public static class FileLocker
	{
		private static readonly UTF8Encoding utf8 = new UTF8Encoding(false);

		public static int VerCode = 2;

		public static string EncryptDES(this string pToEncrypt, string sKey)
		{
			string result;
			using (DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider())
			{
				byte[] bytes = FileLocker.utf8.GetBytes(pToEncrypt);
				dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
				dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cryptoStream.Write(bytes, 0, bytes.Length);
						cryptoStream.FlushFinalBlock();
					}
					string text = Convert.ToBase64String(memoryStream.ToArray());
					result = text;
				}
			}
			return result;
		}

		public static string DecryptDES(this string pToDecrypt, string sKey)
		{
			byte[] array = Convert.FromBase64String(pToDecrypt);
			string result;
			using (DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider())
			{
				dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
				dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cryptoStream.Write(array, 0, array.Length);
						cryptoStream.FlushFinalBlock();
					}
					string @string = FileLocker.utf8.GetString(memoryStream.ToArray());
					result = @string;
				}
			}
			return result;
		}
	}
}
