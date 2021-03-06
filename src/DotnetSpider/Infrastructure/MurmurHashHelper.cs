using System.Text;
using Murmur;

namespace DotnetSpider.Infrastructure
{
	public static class MurmurHashHelper
	{
		private static readonly Murmur32 MurmurHash3 = MurmurHash.Create32();

		public static string GetMurmurHash(this string str)
		{
			var bytes = Encoding.UTF8.GetBytes(str);
			return bytes.GetMurmurHash();
		}

		public static string GetMurmurHash(this byte[] bytes)
		{
			var hashBytes = MurmurHash3.ComputeHash(bytes);
			var builder = new StringBuilder();
			foreach (var b in hashBytes)
			{
				builder.AppendFormat("{0:x2}", b);
			}

			return builder.ToString();
		}
	}
}
